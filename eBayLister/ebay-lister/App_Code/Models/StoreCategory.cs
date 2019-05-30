using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class StoreCategory
{
    public string ID { get; set; }
    public string Name { get; set; }

    public struct SQLCommands
    {
        public static string GetAll
        {
            get
            {
                string command = null;
                command += string.Format("SELECT [ID] AS [{0}]", nameof(ID));
                command += string.Format(",[Name] AS [{0}] ", nameof(Name));
                command += string.Format("FROM [StoreCategories]");

                return command;
            }
        }

        public static string GetOne
        {
            get
            {
                string command = GetAll;
                command += string.Format(" WHERE [ID] = @{0}", nameof(ID));

                return command;
            }
        }
    }
}