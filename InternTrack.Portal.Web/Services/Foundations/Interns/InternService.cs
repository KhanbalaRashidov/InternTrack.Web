﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InternTrack.Portal.Web.Brokers.Apis;
using InternTrack.Portal.Web.Brokers.Loggings;
using InternTrack.Portal.Web.Models.Interns;

namespace InternTrack.Portal.Web.Services.Foundations.Interns
{
    public partial class InternService : IInternService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public InternService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Intern> AddInternAsync(Intern intern) =>
        TryCatch(async () =>
        {
            ValidateInternOnAdd(intern);

            return await this.apiBroker.PostInternAsync(intern);
        });

        public ValueTask<Intern> RetrieveInternByIdAsync(Guid internId) =>
        TryCatch(async () =>
        {
            ValidateInternId(internId);

            return await this.apiBroker.GetInternByIdAsync(internId);
        });

        public ValueTask<List<Intern>> RetrieveAllInternsAsync() =>
            TryCatch(async () => await apiBroker.GetAllInternsAsync());

        public ValueTask<Intern> RemoveInternByIdAsync(Guid internId) =>
        TryCatch(async () =>
        {
            ValidateInternId(internId);

            return await this.apiBroker.DeleteInternByIdAsync(internId);
        });

        public ValueTask<Intern> ModifyInternAsync(Intern intern) =>
        TryCatch(async () =>
        {
            ValidateInternOnModify(intern);

            return await this.apiBroker.PutInternAsync(intern);
        });
    }
}