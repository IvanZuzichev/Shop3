namespace Shop
{
    public class users
    {
        public int ID;
        public string login;
        public string parol;
        public string role;
    }
    internal enum keys
    {
        Up = ConsoleKey.UpArrow,
        Down = ConsoleKey.DownArrow,
        back = ConsoleKey.Escape,
        edit = ConsoleKey.F1,
        find = ConsoleKey.F2,
        Delete = ConsoleKey.F3,
        Enter = ConsoleKey.Enter,
        Save = ConsoleKey.S
    }
    internal enum roles
    {
        admin,
        personal_manager,
        warehouse_manager,
        cashier,
        buhgalter
    }
}
