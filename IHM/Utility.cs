using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IHM
{
    class Utility
    {
        internal static string GetConnectionString()
        {
            string returnValue = null;
            ConnectionStringSettings settings = 
                ConfigurationManager.ConnectionStrings["IHM.Properties.Settings.Gsb_prod"];

            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

    }
}
