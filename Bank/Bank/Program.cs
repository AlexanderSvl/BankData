using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(new string('-', Console.WindowWidth));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(new string('-', Console.WindowWidth / 2));
                Console.Write(" Bank ");
                Console.WriteLine(new string('-', Console.WindowWidth / 2));
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(new string('-', Console.WindowWidth));
                Console.WriteLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter one of the following options: \n\n" +
                    "\"readInfo\" - Read user info from a .txt file;  \n" +
                    "\"printInfo\" - Prints all the records in the database;  \n" +
                    "\"searchUser\" - Searches for a user with the given parameter;  \n" +
                    "\"addUser\" - Adds an user to the database;  \n" +
                    "\"removeUser\" - Removes an user from the database;  \n" +
                    "\"addMoney\" - Adds money to a user from the database;  \n" +
                    "\"removeMoney\" - Removes money from a user from the database;  \n" +
                    "\"emptyDatabase\" - Cleares the database. \n" +
                    "\"sortByAscending\" - Sorts the database by property (Ascending);  \n" +
                    "\"sortByDescending\" - Sorts the database by property (Descending);  \n" +
                    "\"createFile\" - Creates a .txt file, containing the data from the database;  \n" +
                    "\"END\" - Prints the database in the console and the program stops;  \n");
                Console.ResetColor();
                string option = Console.ReadLine();
                CustomArrayList<User> users = new CustomArrayList<User>();

                while (true)
                {
                    if (option == "readInfo")
                    {
                        ReadInfo(users);
                    }
                    else if (option == "createFile")
                    {
                        CreateFile(users);
                    }
                    else if (option == "printInfo")
                    {
                        PrintInfo(users);
                    }
                    else if (option == "searchUser")
                    {
                        SearchUser(users);
                    }
                    else if (option == "addUser")
                    {
                        AddUser(users);
                    }
                    else if (option == "removeUser")
                    {
                        RemoveUser(users);
                    }
                    else if (option == "addMoney")
                    {
                        AddBalance(users);
                    }
                    else if (option == "removeMoney")
                    {
                        RemoveBalance(users);
                    }
                    else if (option == "emptyDatabase")
                    {
                        Empty(users);
                    }
                    else if (option == "sortByAscending")
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Enter property to sort by: ");
                        string targetProp = Console.ReadLine();
                        SortUsersAscending(ref users, targetProp);
                    }
                    else if (option == "sortByDescending")
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Enter property to sort by: ");
                        string targetProp = Console.ReadLine();
                        SortUsersDescending(ref users, targetProp);
                    }
                    else if (option == "END")
                    {
                        PrintDatabase(users);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid command. Please enter one of the following commands:");
                        Console.WriteLine();
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter an option: \n" +
                        "\"readInfo\" - Read user info from a .txt file;  \n" +
                        "\"printInfo\" - Prints all the records in the database;  \n" +
                        "\"searchUser\" - Searches for a user with the given parameter;  \n" +
                        "\"addUser\" - Adds an user to the database;  \n" +
                        "\"removeUser\" - Removes an user from the database;  \n" +
                        "\"addMoney\" - Adds money to a user from the database;  \n" +
                        "\"removeMoney\" - Removes money from a user from the database;  \n" +
                        "\"emptyDatabase\" - Cleares the database. \n" +
                        "\"sortByAscending\" - Sorts the database by property (Ascending);  \n" +
                        "\"sortByDescending\" - Sorts the database by property (Descending);  \n" +
                        "\"createFile\" - Creates a .txt file, containing the data from the database;  \n" +
                        "\"END\" - Prints the database in the console and the program stops;  \n");
                    Console.ResetColor();
                    option = Console.ReadLine();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        static void ReadInfo(CustomArrayList<User> users)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write("Enter .txt file name, from which to read: ");
                Console.ForegroundColor = ConsoleColor.White;
                string filename = Console.ReadLine();

                if (!File.Exists(filename))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("File ЙОК.");
                    Console.ResetColor();
                }
                else
                {
                    using (StreamReader stream = new StreamReader(filename))
                    {
                        string line = stream.ReadLine();

                        while (line != null)
                        {
                            string[] currentUserInfo = line.Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

                            int ID = int.Parse(currentUserInfo[0]);
                            string name = currentUserInfo[1] + " " + currentUserInfo[2] + " " + currentUserInfo[3];
                            int age = int.Parse(currentUserInfo[4]);
                            string EGN = currentUserInfo[5];
                            string phoneNumber = currentUserInfo[6];
                            decimal balance = decimal.Parse(currentUserInfo[7]);
                            string email = currentUserInfo[8];

                            users.Add(new User(ID, name, age, EGN, phoneNumber, balance, email));

                            line = stream.ReadLine();
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Command executed successfuly.");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        static void PrintInfo(CustomArrayList<User> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("WARNING: There are currently no users in the database.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;

                foreach (User user in users)
                {
                    Console.WriteLine(user.ToString());
                }
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        static void SearchUser(CustomArrayList<User> users)
        {
            Console.WriteLine();
            Console.WriteLine("Enter search parameter: 1 - ID, 2 - Name, 3 - Phone number, 4 - E-mail");

            string parameter = "";

            try
            {
                parameter = Console.ReadLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }

            bool isFound = false;

            if (parameter == "1")
            {
                try
                {
                    Console.Write("Enter ID: ");
                    string idToSearchFor = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();

                    foreach (User user in users)
                    {
                        if (user.ID == int.Parse(idToSearchFor))
                        {
                            isFound = true;
                            Console.WriteLine(user.ToString());
                        }
                    }

                    if (!isFound)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No match.");
                        Console.ResetColor();
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }
                catch (Exception exp)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(exp.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            else if(parameter == "2")
            {
                try
                {
                    Console.Write("Enter Name: ");
                    string nameToSearchFor = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();

                    foreach (User user in users)
                    {
                        if (user.name == nameToSearchFor)
                        {
                            isFound = true;
                            Console.WriteLine(user.ToString());
                        }
                    }

                    if (!isFound)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No match.");
                        Console.ResetColor();
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }
                catch (Exception exp)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(exp.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            else if (parameter == "3")
            {
                try
                {
                    Console.Write("Enter phone number: ");
                    string phoneToSearchFor = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();

                    foreach (User user in users)
                    {
                        if (user.phoneNumber == phoneToSearchFor)
                        {
                            isFound = true;
                            Console.WriteLine(user.ToString());
                        }
                    }

                    if (!isFound)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No match.");
                        Console.ResetColor();
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }
                catch (Exception exp)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(exp.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            else if (parameter == "4")
            {
                try
                {
                    Console.Write("Enter e-mail: ");
                    string emailToSearchFor = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();

                    foreach (User user in users)
                    {
                        if (user.email == emailToSearchFor)
                        {
                            isFound = true;
                            Console.WriteLine(user.ToString());
                        }
                    }

                    if (!isFound)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No match.");
                        Console.ResetColor();
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }
                catch (Exception exp)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(exp.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

        }

        public static void AddUser(CustomArrayList<User> users)
        {
            try
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter user info in the following format: [ID] [Name] [Age] [EGN] [Phone number] [Balance] [Email]");
                Console.ForegroundColor = ConsoleColor.White;
                string[] info = Console.ReadLine().Split();
                Console.ResetColor();

                User userToAdd = new User(int.Parse(info[0]), info[1] + " " + info[2] + " " + info[3], int.Parse(info[4]), info[5], info[6], decimal.Parse(info[7]), info[8]);
                users.Add(userToAdd);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("User added. Info: " + userToAdd.ToString());
                Console.WriteLine();
                Console.ResetColor();
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void RemoveUser(CustomArrayList<User> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("WARNING: There are currently no users in the database.");
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                bool isFound = false;

                Console.WriteLine();
                Console.Write("Enter user ID: ");
                string ID = Console.ReadLine();

                foreach (User user in users)
                {
                    if (user.ID == int.Parse(ID))
                    {
                        isFound = true;
                        users.Remove(user);
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("There is no user with such ID!");
                    Console.WriteLine();
                }
            }
        }

        public static void CreateFile(CustomArrayList<User> users)
        {
            try
            {
                if (users.Count == 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("WARNING: There are currently no users in the database.");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter("userInformation.txt"))
                    {
                        foreach (User user in users)
                        {
                            writer.WriteLine(user.ToString());
                        }
                    }

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File created. File location: C:\\Users\\User\\source\\repos\\Bank\\Bank\\bin\\Debug\\netcoreapp3.1\\userInformation.txt");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void AddBalance(CustomArrayList<User> users)
        {
            try
            {
                bool isFound = false;

                Console.WriteLine();
                Console.Write("Enter user ID: ");
                string ID = Console.ReadLine();

                foreach (User user in users)
                {
                    if (user.ID == int.Parse(ID))
                    {
                        isFound = true;

                        Console.WriteLine();
                        Console.Write("Enter money to add: ");
                        decimal balanceToAdd = decimal.Parse(Console.ReadLine());

                        user.AddMoney(balanceToAdd);
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("There is no user with such ID!");
                    Console.WriteLine();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void RemoveBalance(CustomArrayList<User> users)
        {
            try
            {
                bool isFound = false;

                Console.WriteLine();
                Console.Write("Enter user ID: ");
                string ID = Console.ReadLine();

                foreach (User user in users)
                {
                    if (user.ID == int.Parse(ID))
                    {
                        isFound = true;

                        Console.WriteLine();
                        Console.Write("Enter money to remove: ");
                        decimal balanceToRemove = decimal.Parse(Console.ReadLine());

                        user.RemoveMoney(balanceToRemove);
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("There is no user with such ID!");
                    Console.WriteLine();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void Empty(CustomArrayList<User> users)
        {
            try
            {
                users.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cleared the database.");
                Console.WriteLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void SortUsersAscending(ref CustomArrayList<User> users, string targetProp)
        {
            try
            {
                if (users.Count == 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("WARNING: There are currently no users in the database.");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    CustomArrayList<User> sorted = new CustomArrayList<User>();
                    users.OrderBy(x => x.GetType().GetProperty(targetProp).GetValue(x)).ToList().ForEach(y => sorted.Add(y));
                    users = sorted;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sorted by " + targetProp + " ascendingly successfuly.");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void SortUsersDescending(ref CustomArrayList<User> users, string targetProp)
        {
            try
            {
                if (users.Count == 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("WARNING: There are currently no users in the database.");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    CustomArrayList<User> sorted = new CustomArrayList<User>();
                    users.OrderByDescending(x => x.GetType().GetProperty(targetProp).GetValue(x)).ToList().ForEach(y => sorted.Add(y));
                    users = sorted;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sorted by " + targetProp + " descendingly successfuly.");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void PrintDatabase(CustomArrayList<User> users)
        {
            try
            {
                if (users.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Database is empty.");
                    Console.ResetColor();
                }
                else
                {
                    Bank bank = new Bank(users);

                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var item in bank)
                    {
                        Console.WriteLine(item);
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}
 