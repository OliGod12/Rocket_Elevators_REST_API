using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Views
{
    public class ListElevatorsQuery
    {
        public AppDb Db { get; }

        public ListElevatorsQuery(AppDb db)
        {
            Db = db;
        }

        //public async Task<ListElevators> FindOneAsync(int id)
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"SELECT `Id`, `status` FROM `elevators` WHERE `Id` = @id";
        //    cmd.Parameters.Add(new MySqlParameter
        //    {
        //        ParameterName = "@id",
        //        DbType = DbType.Int32,
        //        Value = id,
        //    });
        //    var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
        //    return result.Count > 0 ? result[0] : null;
        //}

        //public async Task<List<ListElevators>> LatestPostsAsync()
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"SELECT `Id`, `status` FROM `elevators` ORDER BY `Id` DESC LIMIT 10;";
        //    return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        //}
        public async Task<List<ListElevators>> InactiveElevatorsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `elevators` WHERE `status` != 'active' ;";
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

        private async Task<List<ListElevators>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<ListElevators>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new ListElevators(Db)
                    {
                        Id = reader.GetInt32(0),
                        Serial_Number = reader.GetInt64(1),
                        Model = reader.GetString(2),
                        Elevator_Type = reader.GetString(3),
                        Status = reader.GetString(4),
                        Commission_Date = reader.GetDateTime(5),
                        Date_Of_Last_Inspection = reader.GetDateTime(6),
                        Certificat_Of_Inspection = reader.GetString(7),
                        Informations = reader.GetString(8),
                        Notes = reader.GetString(9),
                        Column_Id = reader.GetInt32(10),
                        Created_at = reader.GetDateTime(11),
                        Updated_at = reader.GetDateTime(12),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
