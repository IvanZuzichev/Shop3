using Newtonsoft.Json;
using Shop;

namespace Shop
{
    internal class Program
    {
        public static void Main()
        {
            json.jsn();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine("Добро пожаловать в информационную систему магазина Shop");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("  Логин:");
            Console.WriteLine("  Пароль:");
            Console.WriteLine("  Авторизоваться:");
            strelki_menu(" ", " ");
        }
        public static void strelki_menu(string login, string parol)
        {
            string t = File.ReadAllText("C:\\Users\\79671\\Desktop\\user.json");
            List<users> role = JsonConvert.DeserializeObject<List<users>>(t);
            int position = 2;
            for (ConsoleKeyInfo strelka = Console.ReadKey(); strelka.Key != (ConsoleKey)keys.Enter;)
            {
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                if (strelka.Key == (ConsoleKey)keys.Up)
                {
                    position--;
                }
                else if (strelka.Key == (ConsoleKey)keys.Down)
                {
                    position++;
                }
                if (position <= 1)
                {
                    position = 4;
                }
                if (position >= 5)
                {
                    position = 2;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                strelka = Console.ReadKey();
            }
            switch (position)
            {
                case 2:
                    Console.SetCursorPosition(9, 2);
                    Console.WriteLine("                                                                                                  ");
                    login = worklogin();
                    strelki_menu(login, parol);
                    break;
                case 3:
                    Console.SetCursorPosition(10, 3);
                    Console.WriteLine("                                                                                                  ");
                    parol = password();
                    strelki_menu(login, parol);
                    break;
                case 4:
                    int i = 0;
                    foreach (users nick in role)
                    {
                        if (login == nick.login)
                        {
                            if (parol == role[i].parol)
                            {
                                if (role[i].role == "admin")
                                {
                                    admin.Interface(login, parol, i);
                                }
                                else if (role[i].role == "personal manager")
                                {
                                    // роль не сделана, но авторизация работает
                                    admin.Interface(login, parol, i);
                                }
                                else if (role[i].role == "warehouse manager")
                                {
                                    // роль не сделана, но авторизация работает
                                    admin.Interface(login, parol, i);
                                }
                                else if (role[i].role == "cashier")
                                {
                                    // роль не сделана, но авторизация работает
                                    admin.Interface(login, parol, i);
                                }
                                else if (role[i].role == "buhgalter")
                                {
                                    // роль не сделана, но авторизация работает
                                    admin.Interface(login, parol, i);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка при вводе пароля");
                                Main();
                            }
                        }
                        i++;
                    }
                    Console.Clear();
                    Console.WriteLine("Ошибка при вводе логина");
                    Main();
                    break;
            }
        }

        public static string worklogin()
        {
            Console.SetCursorPosition(9, 2);
            string login1 = Console.ReadLine();
            return login1;
        }
        public static string password()
        {
            int position = 10;
            string pasword = "";
            for (ConsoleKeyInfo txt = Console.ReadKey(true); txt.Key != (ConsoleKey)keys.Enter;)
            {
                if (txt.Key == (ConsoleKey)keys.back)
                {
                    if (pasword.Length != 0)
                    {
                        pasword = pasword.Remove(pasword.Length - 1);
                        position--;
                        Console.SetCursorPosition(position, 3);
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    pasword = pasword + txt.KeyChar;
                    Console.SetCursorPosition(position, 3);
                    Console.WriteLine("*");
                    position++;
                }
                txt = Console.ReadKey(true);
            }
            return pasword;
        }
    }
}