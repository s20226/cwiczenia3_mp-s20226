using Cw4.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cw4.Services
{
    public class SqlDbService : IDbService
    {
        private readonly string _connectionString = @"Server=localhost,1433; Database=Master; User Id = SA; Password=Pass@word";

        public void AddAnimal(Animal animal)
        {
            using (var con = new SqlConnection(_connectionString)) {
                var com = new SqlCommand(
                    $"INSERT INTO Animal (Name, Description, Category, Area)" +
                    $"VALUES (@param1, @param2, @param3, @param4)", con);
                com.Parameters.AddWithValue("@param1", animal.Name);
                com.Parameters.AddWithValue("@param2", animal.Description);
                com.Parameters.AddWithValue("@param3", animal.Category);
                com.Parameters.AddWithValue("@param4", animal.Area);
                con.Open();
                com.ExecuteNonQuery();
            }

        }
        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            var res = new List<Animal>();
            //System.Data.SqlClient
            using (var con = new SqlConnection(_connectionString)) {
                var com = new SqlCommand($"SELECT * FROM Animal ORDER BY {orderBy}", con);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read()) {
                    res.Add(new Animal {
                        IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString(),
                    }); ;
                }
            }
            return res;
        }


        public void PutAnimal(Animal animal)
        {
            using (var con = new SqlConnection(_connectionString)) {
                var com = new SqlCommand(
                    $"UPDATE Animal " +
                    $"SET Name = @param1, Description=@param2, Category=@param3, Area=@param4 " +
                    $"where idAnimal=@param5", con);
                com.Parameters.AddWithValue("@param1", animal.Name);
                com.Parameters.AddWithValue("@param2", animal.Description);
                com.Parameters.AddWithValue("@param3", animal.Category);
                com.Parameters.AddWithValue("@param4", animal.Area);
                com.Parameters.AddWithValue("@param5", animal.IdAnimal);
                con.Open();
                com.ExecuteNonQuery();
            }

        }

        public void RemoveAnimal(string idAnimal)
        {
            using (var con = new SqlConnection(_connectionString)) {
                var com = new SqlCommand(
                    $"DELETE FROM Animal " +
                    $"where idAnimal=@param1", con);
                com.Parameters.AddWithValue("@param1", idAnimal);
                con.Open();
                com.ExecuteNonQuery();
            }

        }


    }
}
