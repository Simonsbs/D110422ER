using System.Data;
using System.Data.SqlClient;

namespace MyFirstAPI.Models {
    public class Manufacturer {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        internal static Manufacturer Create(SqlDataReader reader) {
            var result = new Manufacturer();

            //result.ID = reader.GetInt32(reader.GetOrdinal("ID"));
            //result.Name = reader.GetFieldValue<string>(reader.GetOrdinal("Name"));
            //result.Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? "None" : reader.GetString(reader.GetOrdinal("Address"));
            //result.Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? "N/A" : reader.GetString(reader.GetOrdinal("Country"));

            result.ID = reader.GetVal<int>("ID");
            result.Name = reader.GetVal<string>("Name");
            result.Address = reader.GetVal<string>("Address");
            result.Country = reader.GetVal<string>("Country");

            return result;
        }

    }

    internal static class MyExtensions {
        public static T GetVal<T>(this SqlDataReader reader, string colName, T defaultValue = default(T)) {
            if (reader[colName].Equals(DBNull.Value)) {
                return defaultValue;
            } else {
                return (T)reader[colName];
            }
        }

        public static T GetVal<T>(this DataRow row, string colName, T defaultValue = default(T)) {
            if (row[colName].Equals(DBNull.Value)) {
                return defaultValue;
            } else {
                return (T)row[colName];
            }
        }
    }
}
