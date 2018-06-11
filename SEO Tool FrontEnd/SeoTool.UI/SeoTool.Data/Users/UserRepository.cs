using SeoTool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SeoTool.Data
{
    public class UserRepository
    {
        public List<User> Users {get;set;}

        public UserRepository()
        {
            Users = Deserialize();
        }

        public void Serialize(List<User> users)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("users.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, users);
                }
            }
        }

        public List<User> Deserialize()
        {
            var users = new List<User>();
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader("users.json"))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    users = serializer.Deserialize<List<User>>(reader);
                }
            }
            return users;
        }


    }
}
