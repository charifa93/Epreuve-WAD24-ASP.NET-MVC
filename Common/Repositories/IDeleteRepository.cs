﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IDeleteRepository<TEntity, TId>
    {
        void Delete(TId id);
    }
}
