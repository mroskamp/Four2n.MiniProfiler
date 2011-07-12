﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfiledSqlServerDataServicesProvider.cs" company="Daniel Dabrowski - rod.42n.pl">
//   Copyright (c) 2008 Daniel Dabrowski - 42n. All rights reserved.
// </copyright>
// <summary>
//   Defines the ProfiledSqlServerDataServicesProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Four2n.Orchard.MiniProfiler.Data.Providers
{
    using FluentNHibernate.Cfg.Db;

    using global::Orchard.Environment.Extensions;

    [OrchardSuppressDependency("Orchard.Data.Providers.SqlServerDataServicesProvider")]
    public class ProfiledSqlServerDataServicesProvider : global::Orchard.Data.Providers.SqlServerDataServicesProvider
    {
        public ProfiledSqlServerDataServicesProvider(string dataFolder, string connectionString)
            : base(dataFolder, connectionString)
        {
        }

        public override IPersistenceConfigurer GetPersistenceConfigurer(bool createDatabase)
        {
            var persistence = (MsSqlConfiguration)base.GetPersistenceConfigurer(createDatabase);
            return persistence.Driver(typeof(ProfiledSqlClientDriver).AssemblyQualifiedName);
        }
    }
}