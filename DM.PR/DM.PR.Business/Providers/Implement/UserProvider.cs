﻿using DM.PR.Data.SpecificationCreators;
using DM.PR.Common.Entities.Account;
using System.Collections.Generic;
using DM.PR.Data.Specifications;
using DM.PR.Data.Repositories;
using DM.PR.Common.Helpers;
using System.Linq;

namespace DM.PR.Business.Providers.Implement
{
    internal class UserProvider : IUserProvider
    {
        private readonly IRepository<User> _rep;
        private readonly IUserSpecificationCreator _specificCreator;

        public UserProvider(IRepository<User> rep, IUserSpecificationCreator specificCreator)
        {
            Inspector.ThrowExceptionIfNull(rep, specificCreator);
            _specificCreator = specificCreator;
            _rep = rep;
        }

        public User GetById(int id)
        {
            Inspector.ThrowExceptionIfZeroOrNegative(id);
            return _rep.GetById(id);
        }

        public User GetByLogin(string login)
        {
            ISpecification findByLoginSpecification = _specificCreator.CreateFindByLoginSpecification(login);
            return _rep.FindBy(findByLoginSpecification).FirstOrDefault();
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _rep.GetAll();
        }
    }
}
