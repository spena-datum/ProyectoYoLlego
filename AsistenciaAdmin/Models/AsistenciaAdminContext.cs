using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AsistenciaAdmin.Models
{
    public class AsistenciaAdminContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AsistenciaAdminContext() : base("AsistenciaDBConn")
        {
        }

        public System.Data.Entity.DbSet<AsistenciaAdmin.Models.Aulas> Aulas { get; set; }

        public System.Data.Entity.DbSet<AsistenciaAdmin.Models.EstadosClase> EstadosClase { get; set; }

        public System.Data.Entity.DbSet<AsistenciaAdmin.Models.Materias> Materias { get; set; }
    }
}
