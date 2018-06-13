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
    public delegate void Message(string message, string name);

    public class UserRepository
    {
        public event Message NewMessage;

        public List<User> Users { get; set; }

        public UserRepository()
        {
            Users = Deserialize();
        }

        public void Serialize(List<User> users)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("../../../users.json"))
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
            using (StreamReader sr = new StreamReader("../../../users.json"))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    users = serializer.Deserialize<List<User>>(reader);
                }
            }
            return users;
        }

        public bool CheckUserLogin(string login)
        {
            return Users.Any(user => user.Login == login);
        }

        public bool CheckUserPassword(string login, string password)
        {
            var currentUser = Users.First(user => user.Login == login);
            return currentUser.Password == Hasher.GetHash(password);
        }

        public bool CheckUser(string login, string password)
        {
            if (CheckUserLogin(login))
            {
                if (CheckUserPassword(login, password))
                {
                    return true;
                }
                else
                {
                    NewMessage?.Invoke("Неправильный пароль!", "Ошибка");
                }
            }
            else
            {
                NewMessage?.Invoke("Неверный логин!", "Ошибка");
            }
            return false;

        }

        public bool AddUser(string login, string email, string password)
        {
            if (login != "")
            {
                if (!Users.Any(user => user.Login == login))
                {
                    if (email != "" && !Users.Any(user => user.Email == email))
                    {
                        if (password != "")
                        {
                            Users.Add(new User(login, email, password));
                            Serialize(Users);
                            return true;
                        }
                        else
                        {
                            NewMessage?.Invoke("Пустое поле пароля", "Ошибка");
                        }
                    }
                    else if (email == "")
                    {
                        NewMessage?.Invoke("Пустое поле Email", "Ошибка");
                    }
                    else if (Users.Any(user => user.Email == email))
                    {
                        NewMessage?.Invoke("Данный Email занят", "Ошибка");
                    }
                }
                else if (Users.Any(user => user.Login == login))
                {
                    NewMessage?.Invoke("Данный логин занят", "Ошибка");
                }
            }
            else if (login == "")
            {
                NewMessage?.Invoke("Пустое поле имени", "Ошибка");
            }
            return false;
        }
    }
}
