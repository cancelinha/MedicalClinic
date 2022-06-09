using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Data
{
    public class Module : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string endPoint { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in MongoDataAccess namespace
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("Repositories"))
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("baseEndpoint", endPoint)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
