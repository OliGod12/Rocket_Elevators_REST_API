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

        //public async Task<Leads> FindOneAsync(int id)
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"SELECT `Id`, `status` FROM `leads` WHERE `Id` = @id";
        //    cmd.Parameters.Add(new MySqlParameter
        //    {
        //        ParameterName = "@id",
        //        DbType = DbType.Int32,
        //        Value = id,
        //    });
        //    var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
        //    return result.Count > 0 ? result[0] : null;
        //}

        public async Task<List<Leads>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT DISTINCT leads.Id, leads.Full_Name, leads.Compagny_Name, leads.Email, leads.Phone, leads.Project_Name, leads.Project_Description, leads.Department, leads.Message, leads.File_name, leads.created_at, leads.updated_at  FROM leads JOIN customers ON customers.company_contact_email != leads.Email WHERE DATEDIFF(NOW(), leads.created_at) <= 30  ORDER BY leads.created_at ;";
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
                        LeadId = reader.GetInt32(0),
                        Full_Name = reader.GetString(1),
                        Compagny_Name = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        Project_Name = reader.GetString(5),
                        Project_Description = reader.GetString(6),
                        Department = reader.GetString(7),
                        Message = reader.GetString(8),
                        File_name = reader.GetString(9),
                        Created_at = reader.GetDateTime(10),
                        Updated_at = reader.GetDateTime(11),

                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
