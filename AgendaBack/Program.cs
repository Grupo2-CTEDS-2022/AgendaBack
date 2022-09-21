using AgendaBack.Models;
using AgendaBack.Repositories;

namespace AgendaBack
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int id = 123456;
            User usuario = new User()
            {
                Id = id,
            };
            var json = EventRepository.ReadEvents(usuario);
            Console.WriteLine(json);
        }
    }
}