using AgendaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Data.SqlClient;
using AgendaBack.StaticFunction;

namespace AgendaBack.Repositories
{
    public class UserRepository
    {
        private static string stringConexao = System.Environment.GetEnvironmentVariable("stringConexao");
        public static User Get(string email, string password)
        {
            User user = null;
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlDataReader rdr;
                string querySelect = "SELECT * FROM Accounts where Email = @Email";
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string decryptedPassword = UtilsFunctions.Decrypt(rdr[3].ToString());
                        Console.WriteLine(rdr[3].ToString());
                        Console.WriteLine("password");
                        Console.WriteLine(password);
                        Console.WriteLine(decryptedPassword);
                        Models.User usuario = new()
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Name = rdr[1].ToString(),
                            Email = rdr[2].ToString(),
                            Password = rdr[3].ToString()
                        };
                        if (usuario.Email == email && decryptedPassword == password) user = usuario;
                    }
                }
            }

            return user;
        }

        public static User GetByEmail(string email)
        {
            User user = null;
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlDataReader rdr;
                string querySelect = "SELECT * FROM Accounts where Email = @email";
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                        Console.WriteLine(rdr[1]);
                        Models.User usuario = new()
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Name = rdr[1].ToString(),
                            Email = rdr[2].ToString(),
                            Password = rdr[3].ToString()
                        };
                        Console.WriteLine("Verificando usuario");
                        if (usuario.Email == email) user = usuario;
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
                string queryInsert = "INSERT INTO Accounts (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
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
