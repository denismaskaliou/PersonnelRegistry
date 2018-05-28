﻿using DM.PR.Common.Entities;
using DM.PR.Common.Helpers;
using DM.PR.Data.Core.Converters;
using DM.PR.Data.Core.Data;
using DM.PR.Data.Core.Procedures;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DM.PR.Data.Repositories.Implement
{
    internal class MaritalStatusRepository : IMaritalStatusRepository
    {
        private readonly IDbExecutor _dbExecutor;

        public MaritalStatusRepository(IDbExecutor dbExecutor)
        {
            Helper.ThrowExceptionIfNull(dbExecutor);
            _dbExecutor = dbExecutor;
        }

        public IReadOnlyCollection<MaritalStatus> GetAll()
        {
            var result = _dbExecutor.Execute(MaritalStatusProcedure.GetAll);

            return result.IsNull ? null : MaritalStatusConverter.Convert(result.Result as DataSet).ToList();
        }
    }
}