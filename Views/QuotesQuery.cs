using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Views
{
    public class QuotesQuery
    {
        public AppDb Db { get; }

        public QuotesQuery(AppDb db)
        {
            Db = db;
        }

        //public async Task<Quotes> FindOneAsync(int id)
        //{
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = @"SELECT `Id`, `status` FROM `quotes` WHERE `Id` = @id";
        //    cmd.Parameters.Add(new MySqlParameter
        //    {
        //        ParameterName = "@id",
        //        DbType = DbType.Int32,
        //        Value = id,
        //    });
        //    var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
        //    return result.Count > 0 ? result[0] : null;
        //}

        // public async Task<List<Quotes>> LatestPostsAsync()
        // {
        //     using var cmd = Db.Connection.CreateCommand();
        //     cmd.CommandText = @"SELECT `Id`, `Full_Name`, `Compagny_Name`, `Email`, `Phone`, `Project_Name`, `Project_Description`, `Department`, `Message`, `File_name`, `created_at`, `updated_at`  FROM `quotes` WHERE DATEDIFF(NOW(), `created_at`) <= 30  ORDER BY `created_at` ;";
        //     return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        // }

        public async Task<List<Quotes>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT quotes.Id, quotes.Full_Name, quotes.Company_Name, quotes.Building_Type, quotes.Product_Quality, quotes.Nb_Appartement  FROM `quotes` ORDER BY `Id` LIMIT 10;";
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

        private async Task<List<Quotes>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Quotes>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    
                    var post = new Quotes(Db)
                    {
                        QuoteId = reader.GetInt32(0),
                        Full_Name = reader.GetString(1),
                        Company_Name = reader.GetString(2),
                        Building_Type = reader.GetString(3),
                        Product_Quality = reader.GetString(4),
                        Nb_Appartement = reader.GetInt32(5),
                        // Nb_Business = reader.GetInt32(6),
                        // Nb_Company = reader.GetInt32(7),
                        // Nb_Floor = reader.GetInt32(8),
                        // Nb_Basement = reader.GetInt32(9),
                        // Nb_Cage = reader.GetInt32(10),
                        // Nb_Parking = reader.GetInt32(11),
                        // Nb_OccupantPerFloor = reader.GetInt32(12),
                        // Nb_OperatingHour = reader.GetString(13),
                        // Nb_Ele_Suggested = reader.GetString(14),
                        // Subtotal = reader.GetString(15),
                        // Install_Fee = reader.GetString(16),
                        // Final_Price = reader.GetString(17)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
