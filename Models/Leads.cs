using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace Rocket_Elevators_REST_API.Models
{
    public class Leads
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }

        internal AppDb Db { get; set; }

        public Leads()
        {
        }

        internal Leads(AppDb db)
        {
            Db = db;
        }

        //public async Task InsertAsync()
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"INSERT INTO `Leads` (`status`) VALUES (@status);";
        //    BindParams(cmd);
        //    await cmd.ExecuteNonQueryAsync();
        //    Id = (int)cmd.LastInsertedId;
        //}

        //public async Task UpdateAsync()
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"UPDATE `leads` SET `status` = @status WHERE `Id` = @id;";
        //    BindId(cmd);
        //    await cmd.ExecuteNonQueryAsync();
        //}

        //public async Task DeleteAsync()
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"DELETE FROM `rocketApp_development` WHERE `Id` = @id;";
        //    BindId(cmd);
        //    await cmd.ExecuteNonQueryAsync();
        //}

        //private void BindId(MySqlCommand cmd)
        //{
        //    cmd.Parameters.Add(new MySqlParameter
        //    {
        //        ParameterName = "@id",
        //        DbType = DbType.Int32,
        //        Value = Id,
        //    });
        //}
    }
}
