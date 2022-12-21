using Newtonsoft.Json;

namespace Shop
{
    internal interface ICrud
    {
        void Create(string login, string parol, int i, List<users> list);
        void Read(string login, string parol, int i, List<users> list, int num);
        void Update(string login, string parol, int i, List<users> list, int num);
        void Delete(string login, string parol, int i, List<users> list, int num);
        void search(string login, string parol, int i, List<users> list, int num);

    }
    internal class admin : ICrud
    {
        public static void Interface(string login, string parol, int i)
        {
            Console.Clear();
            string t;
            int pozition = 4;
            int icount = 0;
            t = File.ReadAllText("C:\\Users\\79671\\Desktop\\user.json");
            List<users> list = JsonConvert.DeserializeObject<List<users>>(t);
            string name_user = list[i].login;
            Console.WriteLine($"Добро пожаловать, {name_user}!                                     роль:администратор");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("      ID                Логин                Пароль                  роль               | F1 - добавить запись");
            Console.WriteLine($"->                                                                  admin               | F2 - Найти запись");
            Console.WriteLine("                                                                                        | F3 - удалить запись");
            Console.SetCursorPosition(24, 3);
            Console.WriteLine(list[i].login);
            Console.SetCursorPosition(45, 3);
            Console.WriteLine(list[i].parol);
            Console.SetCursorPosition(6, 3);
            Console.WriteLine(list[i].ID);
            for (int z = 4; z < 14; z++)
            {
                Console.SetCursorPosition(88, z);
                Console.Write("|");
            }
            foreach (users item in list)
            {
                if (i != icount)
                {
                    Console.SetCursorPosition(24, pozition);
                    Console.WriteLine(item.login);
                    Console.SetCursorPosition(45, pozition);
                    Console.WriteLine(item.parol);
                    Console.SetCursorPosition(6, pozition);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(68, pozition);
                    Console.WriteLine(item.role);
                    pozition++;
                }
                icount++;
            }
            pozition = 3;
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (true)
            {
                Console.SetCursorPosition(0, pozition);
                Console.WriteLine("  ");
                if (key.Key == (ConsoleKey)keys.Down)
                {
                    pozition++;
                }
                else if (key.Key == (ConsoleKey)keys.Up)
                {
                    pozition--;
                }
                if (pozition == 2)
                {
                    pozition = list.Count + 2;
                }
                else if (pozition == list.Count + 3)
                {
                    pozition = 3;
                }
                Console.SetCursorPosition(0, pozition);
                Console.WriteLine("->");
                key = Console.ReadKey(true);
                if (key.Key == (ConsoleKey)keys.Enter || key.Key == (ConsoleKey)keys.edit || key.Key == (ConsoleKey)keys.Delete || key.Key == (ConsoleKey)keys.find || key.Key == (ConsoleKey)keys.back)
                {
                    break;
                }
            }
            admin admin = new admin();
            if (key.Key == (ConsoleKey)keys.edit)
            {
                admin.Create(name_user, parol, i, list);
            }
            else if (key.Key == (ConsoleKey)keys.Delete)
            {
                admin.Delete(name_user, parol, i, list, pozition - 3);
            }
            else if (key.Key == (ConsoleKey)keys.find)
            {
                admin.search(name_user, parol, i, list, pozition - 3);
            }
            else if (key.Key == (ConsoleKey)keys.Enter)
            {
                admin.Read(name_user, parol, i, list, pozition - 3);
            }
            else
            {
                Console.Clear();
                Program.Main();
            }
        }
        public void Create(string login, string parol, int i, List<users> list)
        {
            int ID = 0;
            string password = "";
            string log = "";
            int role = 0;
            Console.Clear();
            Console.WriteLine($"Добро пожаловать, {login}.");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            for (int i2 = 2; i2 < 14; i2++)
            {
                Console.SetCursorPosition(88, i2);
                Console.Write("|");
            }
            Console.SetCursorPosition(90, 2);
            Console.WriteLine("S - Сохранять");
            Console.SetCursorPosition(90, 3);
            Console.WriteLine("0 - admin");
            Console.SetCursorPosition(90, 4);
            Console.WriteLine("1 - personal manager");
            Console.SetCursorPosition(90, 5);
            Console.WriteLine("2 - warehouse manager");
            Console.SetCursorPosition(90, 6);
            Console.WriteLine("3 - cashier");
            Console.SetCursorPosition(90, 7);
            Console.WriteLine("4 - buhgalter");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID:");
            Console.WriteLine("  пароль:");
            Console.WriteLine("  логин:");
            Console.WriteLine("  роль:");
            Console.SetCursorPosition(0, 2);
            Console.Write("->");
            ConsoleKeyInfo strl = Console.ReadKey(true);
            int pozition = 2;
            while (strl.Key != (ConsoleKey)keys.Save)
            {
                while (strl.Key != (ConsoleKey)keys.Enter)
                {
                    Console.SetCursorPosition(0, pozition);
                    Console.Write("  ");
                    if (strl.Key == (ConsoleKey)keys.Up)
                    {
                        pozition--;
                    }
                    else if (strl.Key == (ConsoleKey)keys.Down)
                    {
                        pozition++;
                    }
                    if (pozition <= 1)
                    {
                        pozition = 5;
                    }
                    else if (pozition >= 6)
                    {
                        pozition = 2;
                    }
                    Console.SetCursorPosition(0, pozition);
                    Console.Write("->");
                    strl = Console.ReadKey(true);
                    if (strl.Key == (ConsoleKey)keys.Save)
                    {
                        break;
                    }
                }
                switch (pozition)
                {
                    case 2:
                        Console.SetCursorPosition(5, 2);
                        Console.WriteLine("                               ");
                        Console.SetCursorPosition(5, 2);
                        ID = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.SetCursorPosition(10, 3);
                        Console.WriteLine("                                ");
                        Console.SetCursorPosition(10, 3);
                        password = Console.ReadLine();
                        break;
                    case 4:
                        Console.SetCursorPosition(9, 4);
                        Console.WriteLine("                                ");
                        Console.SetCursorPosition(9, 4);
                        log = Console.ReadLine();
                        break;
                    case 5:
                        Console.SetCursorPosition(8, 5);
                        Console.WriteLine("                                ");
                        Console.SetCursorPosition(8, 5);
                        role = Convert.ToInt32(Console.ReadLine());
                        break;
                }
                strl = Console.ReadKey(true);
            }
            users newuser = new users();
            newuser.ID = ID;
            newuser.parol = password;
            newuser.login = log;
            if (role == (int)roles.admin)
            {
                newuser.role = "admin";
            }
            if (role == (int)roles.personal_manager)
            {
                newuser.role = "personal manager";
            }
            if (role == (int)roles.warehouse_manager)
            {
                newuser.role = "warehouse manager";
            }
            if (role == (int)roles.cashier)
            {
                newuser.role = "cashier";
            }
            if (role == (int)roles.buhgalter)
            {
                newuser.role = "buhgalter";
            }

            list.Add(newuser);
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("C:\\Users\\79671\\Desktop\\user.json", json);
            Interface(login, parol, i);
        }
        public void Read(string login, string parol, int i, List<users> list, int num)
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать, {login}.                                 роль:Администратор");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"  ID:{list[num].ID}");
            Console.WriteLine($"  логин:{list[num].login}");
            Console.WriteLine($"  пароль:{list[num].parol}");
            Console.WriteLine($"  роль:{list[num].role}");
            for (int i2 = 2; i2 < 14; i2++)
            {
                Console.SetCursorPosition(88, i2);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(90, 3);
            Console.WriteLine("Esc - выйти в меню");
            Console.SetCursorPosition(90, 4);
            Console.WriteLine("F1 - редактировать");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != (ConsoleKey)keys.back || key.Key != (ConsoleKey)keys.edit)
            {
                if (key.Key == (ConsoleKey)keys.back)
                {
                    Interface(login, parol, i);
                }
                else if (key.Key == (ConsoleKey)keys.edit)
                {
                    Update(login, parol, i, list, num);
                }
                key = Console.ReadKey(true);
            }
        }
        public void Update(string login, string parol, int i, List<users> list, int num)
        {
            int rol;
            for (int q = 2; q < 14; q++)
            {
                Console.SetCursorPosition(88, q);
                Console.Write("|");
            }
            Console.SetCursorPosition(90, 2);
            Console.WriteLine("S - сохранить");
            Console.SetCursorPosition(90, 3);
            Console.WriteLine("0 - admin");
            Console.SetCursorPosition(90, 4);
            Console.WriteLine("1 - personal manager");
            Console.SetCursorPosition(90, 5);
            Console.WriteLine("2 - warehouse manager");
            Console.SetCursorPosition(90, 6);
            Console.WriteLine("3 - cashier");
            Console.SetCursorPosition(90, 7);
            Console.WriteLine("4 - buhgalter");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("->");
            int pozition = 2;
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != (ConsoleKey)keys.Save)
            {
                while (key.Key != (ConsoleKey)keys.Enter)
                {
                    if (key.Key == (ConsoleKey)keys.Save)
                    {
                        break;
                    }
                    Console.SetCursorPosition(0, pozition);
                    Console.WriteLine("  ");
                    if (key.Key == (ConsoleKey)keys.Up)
                    {
                        pozition--;
                    }
                    else if (key.Key == (ConsoleKey)keys.Down)
                    {
                        pozition++;
                    }
                    if (pozition <= 1)
                    {
                        pozition = 5;
                    }
                    else if (pozition >= 6)
                    {
                        pozition = 2;
                    }
                    Console.SetCursorPosition(0, pozition);
                    Console.WriteLine("->");
                    key = Console.ReadKey(true);
                }
                if (pozition == 2)
                {
                    Console.SetCursorPosition(5, 2);
                    Console.WriteLine("                                        ");
                    Console.SetCursorPosition(5, 2);
                    list[num].ID = Convert.ToInt32(Console.ReadLine());
                }
                if (pozition == 3)
                {
                    Console.SetCursorPosition(8, 3);
                    Console.WriteLine("                                         ");
                    Console.SetCursorPosition(8, 3);
                    list[num].login = Console.ReadLine();
                }
                if (pozition == 4)
                {
                    Console.SetCursorPosition(9, 4);
                    Console.WriteLine("                                         ");
                    Console.SetCursorPosition(9, 4);
                    list[num].parol = Console.ReadLine();
                }
                if (pozition == 5)
                {
                    Console.SetCursorPosition(7, 5);
                    Console.WriteLine("                                          ");
                    Console.SetCursorPosition(7, 5);
                    rol = Convert.ToInt32(Console.ReadLine());
                    switch (rol)
                    {
                        case 0: list[num].role = "admin"; break;
                        case 1: list[num].role = "personal manager"; break;
                        case 2: list[num].role = "warehouse manager"; break;
                        case 3: list[num].role = "cashier"; break;
                        case 4: list[num].role = "buhgalter"; break;

                    }
                }
                key = Console.ReadKey(true);
            }
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("C:\\Users\\79671\\Desktop\\user.json", json);
            Interface(login, parol, i);
        }
        public void Delete(string login, string parol, int i, List<users> list, int num)
        {
            list.RemoveAt(num);
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("C:\\Users\\79671\\Desktop\\user.json", json);
            Interface(login, parol, i);
        }
        public void search(string login, string parol, int i, List<users> list, int num)
        {
            int ID;
            string password;
            string log;
            string role;
            int ind = 0;
            Console.Clear();
            Console.WriteLine($"Добро пожаловать, {login}.                                 роль:Администратор");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            for (int i3 = 2; i3 < 14; i3++)
            {
                Console.SetCursorPosition(88, i3);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID:");
            Console.WriteLine("  login:");
            Console.WriteLine("  parol:");
            Console.WriteLine("  role:");
            int pozition = 2;
            ConsoleKeyInfo strelk = Console.ReadKey(true);
            while (strelk.Key != (ConsoleKey)keys.Enter)
            {
                Console.SetCursorPosition(0, pozition);
                Console.Write("  ");
                if (strelk.Key == (ConsoleKey)keys.Up)
                {
                    pozition--;
                }
                else if (strelk.Key == (ConsoleKey)keys.Down)
                {
                    pozition++;
                }
                if (pozition <= 1)
                {
                    pozition = 5;
                }
                else if (pozition >= 6)
                {
                    pozition = 2;
                }
                Console.SetCursorPosition(0, pozition);
                Console.Write("->");
                strelk = Console.ReadKey(true);
                if (strelk.Key == (ConsoleKey)keys.back)
                {
                    break;
                }
            }
            switch (pozition)
            {
                case 2:
                    ind = 0;
                    int check = 0;
                    Console.SetCursorPosition(5, 2);
                    ID = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Добро пожаловать, {login}.                                 роль:Администратор");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("      ID                Логин                Пароль                  роль               | F1 - добавить запись");
                    Console.WriteLine($"                                                                                        | F2 - Найти запись");
                    Console.WriteLine("                                                                                        | F3 - удалить запись");
                    foreach (users item in list)
                    {
                        if (item.ID == ID)
                        {
                            check++;
                            break;
                        }
                        ind++;
                    }
                    if (check != 0)
                    {
                        Console.SetCursorPosition(6, 3); Console.WriteLine(ID); Console.SetCursorPosition(24, 3); Console.WriteLine(list[ind].login); Console.SetCursorPosition(45, 3); Console.WriteLine(list[ind].parol); Console.SetCursorPosition(69, 3); Console.WriteLine(list[ind].role);
                    }
                    break;
                case 3:
                    ind = 0;
                    int check1 = 0;
                    Console.SetCursorPosition(9, 3);
                    login = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Добро пожаловать, {login}.                                 роль:Администратор");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("      ID                Логин                Пароль                  роль               | F1 - добавить запись");
                    Console.WriteLine($"                                                                                        | F2 - Найти запись");
                    Console.WriteLine("                                                                                        | F3 - удалить запись");
                    foreach (users item in list)
                    {
                        if (item.login == login)
                        {
                            check1++;
                            break;
                        }
                        ind++;
                    }
                    if (check1 != 0)
                    {
                        Console.SetCursorPosition(6, 3); Console.WriteLine(list[ind].ID); Console.SetCursorPosition(24, 3); Console.WriteLine(list[ind].login); Console.SetCursorPosition(45, 3); Console.WriteLine(list[ind].parol); Console.SetCursorPosition(69, 3); Console.WriteLine(list[ind].role);
                    }
                    break;
                case 4:
                    ind = 0;
                    int check2 = 0;
                    Console.SetCursorPosition(10, 4);
                    password = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Добро пожаловать, {login}.                                 роль:Администратор");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("      ID                Логин                Пароль                  роль               | F1 - добавить запись");
                    Console.WriteLine($"                                                                                        | F2 - Найти запись");
                    Console.WriteLine("                                                                                        | F3 - удалить запись");
                    foreach (users item in list)
                    {
                        if (item.parol == password)
                        {
                            check2++;
                            break;
                        }
                        ind++;
                    }
                    if (check2 != 0)
                    {
                        Console.SetCursorPosition(6, 3); Console.WriteLine(list[ind].ID); Console.SetCursorPosition(24, 3); Console.WriteLine(list[ind].login); Console.SetCursorPosition(45, 3); Console.WriteLine(list[ind].parol); Console.SetCursorPosition(69, 3); Console.WriteLine(list[ind].role);
                    }
                    break;
                case 5:
                    int check3 = 0;
                    Console.SetCursorPosition(8, 5);
                    role = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Добро пожаловать, {login}.                                 роль:Администратор");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("      ID                Логин                Пароль                  роль               | F1 - добавить запись");
                    Console.WriteLine($"                                                                                        | F2 - Найти запись");
                    Console.WriteLine("                                                                                        | F3 - удалить запись");
                    foreach (users item in list)
                    {
                        if (item.role == role)
                        {
                            check3++;
                            break;
                        }
                        ind++;
                    }
                    if (check3 != 0)
                    {
                        Console.SetCursorPosition(6, 3);
                        Console.WriteLine(list[ind].ID);
                        Console.SetCursorPosition(24, 3);
                        Console.WriteLine(list[ind].login);
                        Console.SetCursorPosition(45, 3);
                        Console.WriteLine(list[ind].parol);
                        Console.SetCursorPosition(69, 3);
                        Console.WriteLine(list[ind].role);
                    }
                    break;
            }
            admin admin = new admin();
            strelk = Console.ReadKey(true);
            while (strelk.Key != (ConsoleKey)keys.edit || strelk.Key != (ConsoleKey)keys.Delete || strelk.Key != (ConsoleKey)keys.find || strelk.Key != (ConsoleKey)keys.Enter || strelk.Key != (ConsoleKey)keys.back)
            {
                if (strelk.Key == (ConsoleKey)keys.edit)
                {
                    admin.Create(login, parol, i, list);
                }
                else if (strelk.Key == (ConsoleKey)keys.Delete)
                {
                    admin.Delete(login, parol, i, list, ind);
                }
                else if (strelk.Key == (ConsoleKey)keys.find)
                {
                    search(login, parol, i, list, ind);
                }
                else if (strelk.Key == (ConsoleKey)keys.Enter)
                {
                    admin.Read(login, parol, i, list, ind);
                }
                else if (strelk.Key == (ConsoleKey)keys.back)
                {
                    Interface(login, parol, i);
                }
                strelk = Console.ReadKey(true);
            }
        }
    }
}

