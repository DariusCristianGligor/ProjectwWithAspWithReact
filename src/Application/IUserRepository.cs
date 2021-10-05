﻿using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IUsersRepository
    {
        IQueryable<User> GetAll();

        void Delete(Guid userId);
        Task<EntityEntry<User>> AddAsync(User user);
        bool Find(Guid userId);
    }
}
