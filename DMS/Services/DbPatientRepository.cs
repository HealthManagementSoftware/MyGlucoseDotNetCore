using DMS.Data;
using DMS.Models;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class DbPatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;
        private IAuditRepository _auditRepo;

        public DbPatientRepository( ApplicationDbContext db,
                                    IAuditRepository auditRepo )
        {
            _db = db;
            _auditRepo = auditRepo;

        } // Injection Constructor


        public async Task<Patient> ReadAsync( string username )
        {
            var patient = await _db.Patients
                //.Select( p => new Patient { p.UserName, p.Doctor, p.SignedHIPAANotice, p.GlucoseEntries, p.ExerciseEntries, p.MealEntries } )
                .Include( d => d.Doctor )
                .Include( o => o.PatientSignedHIPAANotice )
                .Include( g => g.GlucoseEntries )
                .Include( e => e.ExerciseEntries )
                .Include( m => m.MealEntries )
                    .ThenInclude( mi => mi.MealItems )
                .SingleOrDefaultAsync( o => o.UserName == username );
            //patient.PatientSignedHIPAANotice = await _db.PatientSignedHIPAANotices
            //    .FirstOrDefaultAsync( u => u.PatientUserName == patient.UserName );

            return patient;

        } // ReadAsync


        public IQueryable<Patient> ReadAll()
        {
            return _db.Patients;
            //.Include( d => d.Doctor )
            //.Include( o => o.PatientSignedHIPAANotice )
            //.Include( g => g.GlucoseEntries )
            //.Include( e => e.ExerciseEntries )
            //.Include( m => m.MealEntries )
            //    .ThenInclude( mi => mi.MealItems );

        } // ReadAll


        public async Task<Patient> CreateAsync( Patient patient )
        {
            _db.Patients.Add( patient );
            _db.Entry( patient.PatientSignedHIPAANotice ).State = EntityState.Unchanged;
            await _db.SaveChangesAsync();

            if( Config.AuditingOn )
            {
                var auditChange = new AuditChange();
                auditChange.CreateAuditTrail( AuditActionType.CREATE, patient.Id, new Patient(), patient );
                await _auditRepo.CreateAsync( auditChange );

            } // if

            return patient;

        } // Create


        public async Task UpdateAsync( string username, Patient patient )
        {
            if( Exists( username ) )
            {
                var dbPatient = await ReadAsync( username );
                if( Config.AuditingOn )
                {
                    var auditChange = new AuditChange();
                    if( !auditChange.CreateAuditTrail( AuditActionType.UPDATE, patient.Id, dbPatient, patient ) )
                        await _auditRepo.CreateAsync( auditChange );

                } // if

                dbPatient.FirstName = patient.FirstName;
                dbPatient.LastName = patient.LastName;
                dbPatient.Address1 = patient.Address1;
                dbPatient.Address2 = patient.Address2;
                dbPatient.City = patient.City;
                dbPatient.State = patient.State;
                dbPatient.Zip1 = patient.Zip1;
                dbPatient.Zip2 = patient.Zip2;
                if( !String.IsNullOrEmpty( patient.PhoneNumber ) )
                    dbPatient.PhoneNumber = patient.PhoneNumber;
                if( !String.IsNullOrEmpty( patient.Email ) )
                    dbPatient.Email = patient.Email;
                if( patient.CreatedAt != null )
                    dbPatient.CreatedAt = patient.CreatedAt;
                dbPatient.UpdatedAt = DateTime.Now;
                if( !String.IsNullOrEmpty( patient.RemoteLoginToken.ToString() ) )
                    dbPatient.RemoteLoginToken = patient.RemoteLoginToken; // In case it has changed
                if( patient.Height > 0 )
                    dbPatient.Height = patient.Height;
                if( patient.Weight > 0 )
                    dbPatient.Weight = patient.Weight;
                if( patient.PatientSignedHIPAANotice != null )
                    dbPatient.PatientSignedHIPAANotice = patient.PatientSignedHIPAANotice;

                _db.Entry( dbPatient.Doctor ).State = EntityState.Detached;
                //_db.Attach( dbPatient.Doctor );
                //_db.Entry( dbPatient.Doctor ).Property( "Id" ).CurrentValue = patient.Doctor.Id;

                //if ( patient.Doctor != null )
                //{
                //    //dbPatient.DoctorUserName = patient.DoctorUserName;
                //    dbPatient.Doctor = patient.Doctor;
                //    _db.Entry( dbPatient.Doctor ).State = EntityState.Unchanged;
                //}

                //if ( dbPatient?.Doctor?.UserName == patient?.Doctor?.UserName )
                //{
                //}
                //else
                //{
                //    //if( !string.IsNullOrEmpty( patient.DoctorId ) && oldPatient.DoctorId != patient.DoctorId )
                //    //    oldPatient.DoctorId = patient.DoctorId;
                //    //if( !string.IsNullOrEmpty( patient.DrUserName ) && dbPatient.DrUserName != patient.DrUserName )
                //    //    dbPatient.DrUserName = patient.DrUserName;
                //    //if( patient.Doctor != null )
                //    //dbPatient.Doctor = patient.Doctor;
                //}

                _db.Entry( dbPatient ).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            return;

        } // UpdateAsync


        public async Task DeleteAsync( string username )
        {
            if( Exists( username ) )
            {
                var patient = await ReadAsync( username );
                if( Config.AuditingOn )
                {
                    var auditChange = new AuditChange();
                    auditChange.CreateAuditTrail( AuditActionType.DELETE, patient.Id, patient, new Patient() );
                    await _auditRepo.CreateAsync( auditChange );

                } // if

                _db.Patients.Remove( patient );
                await _db.SaveChangesAsync();
            }
            return;

        } // DeleteAsync


        public ApplicationUser ReadPatient( string email )
        {
            return _db.Users.SingleOrDefault( u => u.Email == email );
        }


        public bool Exists( string username )
        {
            return _db.Patients.Any( p => p.UserName == username );
        }

    } // Class

} // Namespace