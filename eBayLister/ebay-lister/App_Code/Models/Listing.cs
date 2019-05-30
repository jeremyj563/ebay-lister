using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Listing
{
    public int ID { get; set; }
    public string StoreCategoryID { get; set; }
    public string Title { get; set; }
    public string Photo1Path { get; set; }
    public string Photo2Path { get; set; }
    public decimal Price { get; set; }
    public bool Listed { get; set; }
    public bool Sold { get; set; }
    public int Condition { get; set; }
    public int WeightLBS { get; set; }
    public int WeightOZ { get; set; }
    public string Description { get; set; }

    public struct SQLCommands
    {
        public static string GetAll
        {
            get
            {
                string command = null;
                command += string.Format("SELECT [ID] AS [{0}]", nameof(ID));
                command += string.Format(",[StoreCategoryID] AS [{0}]", nameof(StoreCategoryID));
                command += string.Format(",[Title] AS [{0}]", nameof(Title));
                command += string.Format(",[Photo1Path] AS [{0}]", nameof(Photo1Path));
                command += string.Format(",[Photo2Path] AS [{0}]", nameof(Photo2Path));
                command += string.Format(",[Price] AS [{0}]", nameof(Price));
                command += string.Format(",[Listed] AS [{0}]", nameof(Listed));
                command += string.Format(",[Sold] AS [{0}]", nameof(Sold));
                command += string.Format(",[Condition] AS [{0}]", nameof(Condition));
                command += string.Format(",[WeightLBS] AS [{0}]", nameof(WeightLBS));
                command += string.Format(",[WeightOZ] AS [{0}]", nameof(WeightOZ));
                command += string.Format(",[Description] AS [{0}] ", nameof(Description));
                command += string.Format("FROM [Listings]");

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

        public static string Edit
        {
            get
            {
                string command = null;
                command += string.Format("UPDATE [Listings] SET ");
                command += string.Format("[StoreCategoryID] = @{0}", nameof(StoreCategoryID));
                command += string.Format(",[Title] = @{0}", nameof(Title));
                command += string.Format(",[Photo1Path] = @{0}", nameof(Photo1Path));
                command += string.Format(",[Photo2Path] = @{0}", nameof(Photo2Path));
                command += string.Format(",[Price] = @{0}", nameof(Price));
                command += string.Format(",[Listed] = @{0}", nameof(Listed));
                command += string.Format(",[Sold] = @{0}", nameof(Sold));
                command += string.Format(",[Condition] = @{0}", nameof(Condition));
                command += string.Format(",[WeightLBS] = @{0}", nameof(WeightLBS));
                command += string.Format(",[WeightOZ] = @{0}", nameof(WeightOZ));
                command += string.Format(",[Description] = @{0} ", nameof(Description));
                command += string.Format("WHERE [ID] = @{0}", nameof(ID));

                return command;
            }
        }
        
        public static string Remove
        {
            get
            {
                string command = null;
                command += string.Format("DELETE FROM [Listings] ");
                command += string.Format("WHERE [ID] = @{0}", nameof(ID));

                return command;
            }
        }

        public static string New
        {
            get
            {
                string command = null;
                command += string.Format("INSERT INTO [Listings] ");
                command += string.Format("VALUES ");
                command += string.Format("(@{0}", nameof(StoreCategoryID));
                command += string.Format(",@{0}", nameof(Title));
                command += string.Format(",@{0}", nameof(Photo1Path));
                command += string.Format(",@{0}", nameof(Photo2Path));
                command += string.Format(",@{0}", nameof(Price));
                command += string.Format(",@{0}", nameof(Listed));
                command += string.Format(",@{0}", nameof(Sold));
                command += string.Format(",@{0}", nameof(Condition));
                command += string.Format(",@{0}", nameof(WeightLBS));
                command += string.Format(",@{0}", nameof(WeightOZ));
                command += string.Format(",@{0})", nameof(Description));

                return command;
            }
        }
    }

    public object List()
    {
        throw new NotImplementedException();
    }

    public object Remove()
    {
        throw new NotImplementedException();
    }
}