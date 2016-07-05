using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MotorOrdenesVenta
{
    public class Connection
    {
        public static string ConnectionString
        {
            get
            {


                Mastercon.Masterconnect oConn = new Mastercon.Masterconnect();
                //"metadata=res://*/SPContext.csdl|res://*/SPContext.ssdl|res://*/SPContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=.\dev;Initial Catalog=LP;Integrated Security=True;MultipleActiveResultSets=True"
                //metadata=res://*/Ventas.csdl|res://*/Ventas.ssdl|res://*/Ventas.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=nmxsvw13;Initial Catalog=navimex_ventas;Integrated Security=True;MultipleActiveResultSets=True&quot;

                string s = "metadata=res://*/DMC.csdl|res://*/DMC.ssdl|res://*/DMC.msl;provider=System.Data.SqlClient;provider connection string=\"";
                string sConn = oConn.GetDataConn("Ventas", "Datamart_cmi");

                //return s + sConn + ";Trusted_Connection=false;Max Pool Size=600;MultipleActiveResultSets=True\"";
                //prepro
                return "metadata=res://*/Navimex_Mo.csdl|res://*/Navimex_Mo.ssdl|res://*/Navimex_Mo.msl;provider=System.Data.SqlClient;provider connection string=\"Data source=nmxsvp27;initial catalog=Navimex_Mo;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework\"";
                //prod
                //return "metadata=res://*/DMC.csdl|res://*/DMC.ssdl|res://*/DMC.msl;provider=System.Data.SqlClient;provider connection string=\"Data source=nmxsvw03;initial catalog=Datamart_CMI;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework\"";

            }
        }
    }

    public partial class Datamart_CMIEntities : DbContext
    {
        public Datamart_CMIEntities()
            : base(Connection.ConnectionString)
        {
            System.Diagnostics.Debug.WriteLine(base.Database.Connection.ConnectionString);
        }
        
    }

    public partial class Navimex_Mo2Entities : DbContext
    {
        public Navimex_Mo2Entities()
            : base(Connection.ConnectionString)
        {
            System.Diagnostics.Debug.WriteLine(base.Database.Connection.ConnectionString);
        }
    }

    //public partial class navimex_ventasEntities : DbContext
    //{
    //    public navimex_ventasEntities()
    //        : base(Connection.ConnectionString)
    //    {

    //        // base.Configuration.LazyLoadingEnabled = false;
    //        System.Diagnostics.Debug.WriteLine(base.Database.Connection.ConnectionString);
    //    }
    //}
}
