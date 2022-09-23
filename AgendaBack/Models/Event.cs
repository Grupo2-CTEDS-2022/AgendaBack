using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBack.Models
{
    internal class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string addedUsersString { get; set; }
        public List<int> addedUsers;

        public void addUser(User user)
        {
            addedUsers.Add(user.Id);
        }

        public void StringToList()
        {
            List<int> addedUsers = new List<int>();

            string[] ids = addedUsersString.Split(',');
            foreach (string id in ids)
            {
                addedUsers.Add(Convert.ToInt32(id));
            }

        }
    }

}
