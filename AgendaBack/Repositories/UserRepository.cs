using AgendaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Data.SqlClient;

namespace AgendaBack.Repositories
{
    public static class UserRepository
    {
        private static string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog = db_16; User id=usuario_16; pwd=51068523824";
        //private readonly string stringConexao = "Data source=MP\\SQLEXPRESS; Initial Catalog=Catalog; integrated security=true;";
        public static User Get(string name, string password)
        {

            User user = new();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM Accounts";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        Models.User usuario = new()
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Name = rdr[1].ToString(),
                            Email = rdr[2].ToString(),
                            Password = rdr[3].ToString()
                        };

                        if (usuario.Name == name && usuario.Password == password) user = usuario;
                    }
                }
            }

            return user;
        }

        private static string listToJson(List<User> listUsers)
        {

            var json = JsonSerializer.Serialize(listUsers);
            return json;

        }

        public static void addUser(User user)
        {

            // não revisado
            using (SqlConnection con = new SqlConnection(stringConexao))
            {


                string queryInsert = "INSERT INTO Accounts (Id, Name, Email, Password) VALUES (@Id, @Name, @Email, @Password)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
