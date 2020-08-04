using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Views
{
    public class BuildingsQuery
    {
        public AppDb Db { get; }

        public BuildingsQuery(AppDb db)
        {
            Db = db;
        }

        /*public async Task<Buildings> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`,  FROM `buildings` WHERE  `Id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        } */

        public async Task<List<Buildings>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `admin_full_name`, `admin_phone`, `admin_email`, `full_name_STA`, `phone_TA`, `email_TA`, `address_id`, `customer_id` FROM `buildings` JOIN `batteries` `columns` `elevators` WHERE `batteries.status` = `Intervention` || `columns.status` = `Intervention` || `elevators.status` = `Intervention` ORDER BY `Id` DESC LIMIT 9;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        //public async Task DeleteAllAsync()
        //{
        //    using var txn = await Db.Connection.BeginTransactionAsync();
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"DELETE FROM `rocketApp_development`";
        //    await cmd.ExecuteNonQueryAsync();
        //    await txn.CommitAsync();
        //}

        private async Task<List<Buildings>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Buildings>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Buildings(Db)
                    {
                        Id = reader.GetInt32(0),
                        Status = reader.GetString(1),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
