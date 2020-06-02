using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueJSAspNetCoreWeb.Models;

namespace VueJSAspNetCoreWeb.Services
{
    public class ProjectstoreDatabaseSettings : IProjectstoreDatabaseSettings
    {
        public string ProjectsCollectionName { get; set; }
        public string PipelinesCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProjectstoreDatabaseSettings
    {
        string ProjectsCollectionName { get; set; }
        string PipelinesCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
