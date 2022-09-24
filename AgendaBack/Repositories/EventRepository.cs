using AgendaBack.Models;
using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Data.SqlClient;

using AgendaBack.Models;
using System.Net;
using System.Collections;
using System.Xml.Linq;
using AgendaBack;

namespace AgendaBack.Repositories
{
    internal class EventRepository
    {

        private static string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog = db_16; User id=usuario_16; pwd=51068523824";
        //private readonly string stringConexao = "Data source=MP\\SQLEXPRESS; Initial Catalog=Catalog; integrated security=true;";

      

   

        //**
        public static string ReadInInterval(int id, DateTime start, DateTime end)
        {

            List<Event> listEvents = new();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM Eventos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        Models.Event evento = new()
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Name = rdr[1].ToString(),
                            Description = rdr[2].ToString(),
                            Start = Convert.ToDateTime(rdr[3]),
                            End = Convert.ToDateTime(rdr[4]),
                            addedUsersString = rdr[5].ToString(),
                            addedUsers = new List<int>()

                        };

                        string[] ids = evento.addedUsersString.Split(',');
                        foreach (string i in ids)
                        {

                            evento.addedUsers.Add(int.Parse(i));
                        }




                        if (evento.addedUsers.Contains(id) && DateTime.Compare(evento.Start, start) > 0 && DateTime.Compare(evento.Start, end) < 0)
                        {
                            listEvents.Add(evento);
                        }


                    }
                }
            }

            return JsonSerializer.Serialize(listEvents);
        }

        

        public static void AddUserToEvent(Event evento, User user)
        {
            throw new NotImplementedException();
        }
       

        // **
        public static void CreateEvent(int creatorId, int IdEvent, string Name, string Description, DateTime Start, DateTime End)
        {

            
            using (SqlConnection con = new SqlConnection(stringConexao))
            {


                string queryInsert = "INSERT INTO Eventos (Id, [Name], [Description], [Start], [End], Users) VALUES (@Id, @Name, @Description, @Start, @End, @Users)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", IdEvent);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@Start", Start);
                    cmd.Parameters.AddWithValue("@End",  End);
                    cmd.Parameters.AddWithValue("@Users", creatorId.ToString());

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //**
        public static void DeleteEvent(int IdEvent)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {


                string queryInsert = "DELETE FROM Eventos WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", IdEvent);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //**
        public static void EditEvent(int IdEvent, string Name, string Description, DateTime Start, DateTime End)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {


                string queryInsert = "UPDATE Eventos SET [Name] = @Name, [Description] = @Description, [Start] = @Start, [End] = @End WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", IdEvent);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@Start", Start);
                    cmd.Parameters.AddWithValue("@End", End);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }







    }
}
