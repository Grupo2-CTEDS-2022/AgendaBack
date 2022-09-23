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

namespace AgendaBack.Repositories
{
    internal class EventRepository
    {

        private static string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog = Eventos; User id=usuario_16; pwd=";
        //private readonly string stringConexao = "Data source=MP\\SQLEXPRESS; Initial Catalog=Catalog; integrated security=true;";
        public static string ReadEvents(User user)
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
                            End = Convert.ToDateTime(rdr[4])
                        };
                        // atribuir o addedUsers do event 
                        if (evento.addedUsers.Contains(user.Id)) listEvents.Add(evento);
                    }
                }
            }

            return EventRepository.listToJson(listEvents);
        }

        private static string listToJson(List<Event> listEventos)
        {

            var json = JsonSerializer.Serialize(listEventos);
            return json;

        }

        public static void AddUserToEvent(Event evento, User user)
        {
            throw new NotImplementedException();
        }

        public static void addEvent(User user, Event evento)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {


                string queryInsert = "INSERT INTO Products (IdProduct, Name, Description, Price) VALUES (@IdProduct, @Name, @Description, @Price)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", evento.Id);
                    cmd.Parameters.AddWithValue("@Date", evento.Start);
                    cmd.Parameters.AddWithValue("@Description", evento.Description);
                    cmd.Parameters.AddWithValue("@Price", evento.End);

                    // como registrar os usuarios de um evento?

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
