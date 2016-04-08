using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using SOLID.Global.Interfaces.Context;
using SOLID.Global.Models;

namespace SOLID.Context
{
    public class SOLIDContext: DbContext, ISOLIDContext
    {
        public SOLIDContext()
             : base("name=SOLIDContext")
        {
            
        }

        public IDbSet<First> Firsts { get; set; }
        public IDbSet<Second> Seconds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
