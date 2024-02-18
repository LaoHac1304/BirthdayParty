﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Repository.Common
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
    }
}
