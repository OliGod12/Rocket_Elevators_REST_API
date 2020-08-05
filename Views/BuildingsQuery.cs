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
            cmd.CommandText = @"SELECT DISTINCT buildings.Id, buildings.admin_full_name, buildings.admin_phone, buildings.admin_email, buildings.full_name_STA, buildings.phone_TA, buildings.email_TA, buildings.address_id, buildings.customer_id, buildings.created_at, buildings.updated_at FROM `buildings` 
                JOIN `batteries`
                ON buildings.id = batteries.building_id
                JOIN `columns`
                ON batteries.id = columns.battery_id
                JOIN `elevators`
                ON columns.id = elevators.column_id
                WHERE batteries.status = 'intervention' OR columns.status = 'intervention' OR elevators.status = 'intervention';";
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
                        BuildingId = reader.GetInt32(0),
                        Admin_Full_Name = reader.GetString(1),
                        Admin_Phone = reader.GetString(2),
                        Admin_Email = reader.GetString(3),
                        Full_Name_STA = reader.GetString(4),
                        Phone_TA = reader.GetString(5),
                        Email_TA = reader.GetString(6),
                        Address_Id = reader.GetInt32(7),
                        Customer_Id = reader.GetInt32(8),
                        Created_at = reader.GetDateTime(9),
                        Updated_at = reader.GetDateTime(10),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
