using Newtonsoft.Json;

namespace Shop
{
    internal class json
    {
        public static void jsn()
        {
            string path = "C:\\Users\\79671\\Desktop\\user.json";
            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
                users admin = new users();
                admin.login = "ivan";
                admin.parol = "100";
                admin.ID = 0;
                admin.role = "admin";
                List<users> usersList = new List<users>();
                usersList.Add(admin);
                string json = JsonConvert.SerializeObject(usersList);
                File.WriteAllText(path, json);
            }
        }
    }
}

