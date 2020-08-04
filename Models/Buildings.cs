using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace Rocket_Elevators_REST_API.Models
{
    public class Buildings
    {
        public int Id { get; set; }
        public string Status { get; set; }

        internal AppDb Db { get; set; }

        public Buildings()
        {
        }

        internal Buildings(AppDb db)
        {
            Db = db;
        }

        //public async Task InsertAsync()
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"INSERT INTO `Buildings` (`status`) VALUES (@status);";
        //    BindParams(cmd);
        //    await cmd.ExecuteNonQueryAsync();
        //    Id = (int)cmd.LastInsertedId;
        //}

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `buildings` SET `status` = @status WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        //public async Task DeleteAsync()
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"DELETE FROM `rocketApp_development` WHERE `Id` = @id;";
        //    BindId(cmd);
        //    await cmd.ExecuteNonQueryAsync();
        //}

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@status",
                DbType = DbType.String,
                Value = Status,
            });
        }
    }
}