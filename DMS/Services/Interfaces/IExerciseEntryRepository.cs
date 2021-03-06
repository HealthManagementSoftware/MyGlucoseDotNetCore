using DMS.Models;
using DMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*********************************************/
//  Created by J.T. Blevins
//  Modified by Heather Harvey with advice from Natash Ince and J.T. Blevins
/*********************************************/
namespace DMS.Services.Interfaces
{
    public interface IExerciseEntryRepository
    {
        Task<ExerciseEntry> ReadAsync( Guid id );
        IQueryable<ExerciseEntry> ReadAll();
        Task<ExerciseEntry> CreateAsync( ExerciseEntry exerciseEntry );
        Task UpdateAsync( Guid id, ExerciseEntry exerciseEntry );
        Task DeleteAsync( Guid id );
        ExerciseEntry Create(ExerciseEntry exerciseEntry );
        Task CreateOrUpdateEntries( ICollection<ExerciseEntry> exerciseEntries );
        bool Exists( Guid id );

    } // Interface

} // Namespace