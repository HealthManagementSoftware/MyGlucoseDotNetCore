﻿using DMS.Models;
using DMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class DummyAuditRepository : IAuditRepository
    {
        public Task<AuditChange> ReadAsync( string auditId )
        {
            return null;
        }


        public IQueryable<AuditChange> ReadAll()
        {
            return null;
        }


        public Task<AuditChange> CreateAsync( AuditChange auditChange )
        {
            return null;

        }

    } // class

} // namespace
