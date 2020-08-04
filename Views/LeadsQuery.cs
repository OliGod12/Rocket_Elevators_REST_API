using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Views
{
    public class LeadsQuery
    {
        public AppDb Db { get; }

        public LeadsQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Leads> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `status` FROM `leads` WHERE `Id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Leads>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `status` FROM `leads` ORDER BY `Id` DESC LIMIT 10;";
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

        private async Task<List<Leads>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Leads>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Leads(Db)
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
