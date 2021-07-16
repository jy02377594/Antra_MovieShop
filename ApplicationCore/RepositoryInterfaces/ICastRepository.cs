﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    interface ICastRepository:IAsyncRepository<Cast>
    {
        Task<List<Cast>> GetAllCasts();
        Task<Cast> GetCastById();
    }
}