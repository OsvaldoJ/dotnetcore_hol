﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SpyStore_HOL.DAL.EfStructures
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            var path = Environment.GetEnvironmentVariable("APPDATA");
            var connectionString =
                $@"Data Source=(localdb)\mssqllocaldb2017;Initial Catalog=SpyStore_HOL2.1_2017;Trusted_Connection=True;MultipleActiveResultSets=true;AttachDbFileName={path}\SpyStore_HOL_2017.mdf;";
            //var connectionString =
            //    $@"Data Source=(localdb)\mssqllocaldb2017;Initial Catalog=SpyStore_HOL2.1_2017;Trusted_Connection=True;MultipleActiveResultSets=true;AttachDbFileName={path}\SpyStore_HOL_2017.mdf;";
            //AttachDbFileName=|DataDirectory|\<DatabaseFileName>.mdf
            optionsBuilder
                .UseSqlServer(connectionString, options => options.EnableRetryOnFailure())
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new StoreContext(optionsBuilder.Options);
        }
    }
}