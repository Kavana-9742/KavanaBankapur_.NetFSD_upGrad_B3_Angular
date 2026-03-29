using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    internal class ConfigurationManager
    {
        private static ConfigurationManager instance;

        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string DatabaseConnectionString { get; set; }

        private ConfigurationManager()
        {
            ApplicationName = "Inventory Management System";
            Version = "1.0";
            DatabaseConnectionString = "Server=.;Database=InventoryDB;Trusted_Connection=True;";
        }

        public static ConfigurationManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }
}
