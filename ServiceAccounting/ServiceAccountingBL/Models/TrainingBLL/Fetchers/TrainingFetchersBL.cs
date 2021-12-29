﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Fetchers
{
    public class TrainingFetchersBL : ITrainingFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public TrainingFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetTrainingDtoBL>> GetTrainingAll()
        {
            if (!await context.Set<Training>().AnyAsync())
                return new List<ResponseGetTrainingDtoBL>();

            var allClients = await context.Set<Training>()
                .Include(x => x.Trainer)
                .Include(x => x.Service)
                .ToListAsync();

            return ReadTrainingMapperBL.Map<ICollection<ResponseGetTrainingDtoBL>>(allClients);
        }
    }
}
