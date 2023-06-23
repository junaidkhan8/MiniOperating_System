
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace JunaidProject_OS
{
    class Program
    {
        static void Main(string[] args)
        {
            TitlePage.yes();
            admin.userlogindetail();

        }
    }

    class TitlePage
    {
        static public void yes()
        {
            Console.WriteLine("\n\nWELCOME TO THE PROJECT: 'CONSOLE OPERATED COMPUTER CONTROLLING AND DETAILS DETECTION SYSTEM' \n\n ");
            Console.WriteLine("GROUP MEMBERS                   S.ID                    MOBILE NO                      EMAIL\n");
            Console.WriteLine("MUHAMAMD RASHID SHAFIQUE        11446                   03302911375                    rashidarain910@gmail.com");
            Console.WriteLine("MUHAMMAD JUNAID KHAN            11003                   03214340476                    junaidkhan4340@gmail.com");
            Console.ReadKey();
            Console.Clear();
            TitlePage.securityLogin();
        }
        static public void securityLogin()
        {
            Console.WriteLine("login as: \n1: user\n2: admin");
            string enter = Console.ReadLine();
            Console.Clear();
            if (enter == "user" || enter == "USER" || enter == "User" || enter == "1" || enter == "01")
            {
                string filepath = @"D:\Summer Semester 2021\Junaid\VisitorsListDetails.txt";
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filepath).ToList();
                Console.WriteLine("write you name and ID in 1 line and make sure you can write correct..\nFor example: 11446 M.Rashid");
                string x = Console.ReadLine();
                lines.Add(x);
                File.WriteAllLines(filepath, lines);
                userMenu.yes();
            }
            else if (enter == "admin" || enter == "ADMIN" || enter == "Admin" || enter == "2" || enter == "02")
            {
                Console.WriteLine("ENTER YOUR NAME...");
                string user = Console.ReadLine();
                Console.WriteLine("ENTER USER PASWORD...");
                string pass = Console.ReadLine();
            }
            else
            {
                Console.WriteLine(@"Invalid input!\n\n\n\t\tdo you want to enter again? press 'y' for yes ");
                string x = Console.ReadLine();
                if (x == "y" || x == "yes" || x == "Y")
                {
                    TitlePage.securityLogin();
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
    class admin
    {
        public static void userlogindetail()
        {
            string filepath = @"D:\Summer Semester 2021\Junaid\VisitorsListDetails.txt";

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }

    //*****************************************************************USER************************************************************************************

    class userMenu
    {
        public static void yes()
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO THE MENU:\n");
            Console.WriteLine(" 1: File and Directory details system\n 2: Browsing Internet");
            Console.WriteLine(" 3: See available WIFI's\n 4: See previously connected Wifi Details");
            Console.WriteLine(" 5: Your Processor detail and Speed \n 6: Show complete IP configration");
            Console.WriteLine(" 7: See System (Info / spex)");
            Console.WriteLine(" 8: Close the programme");
            string choice = Console.ReadLine();
            Console.Clear();
            if (choice == "1")
            {
                USER_FileAndDirectory.ChoiceFileAndDirectory();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter what do you want to browse through google");
                string query = Console.ReadLine();
                internet.searchGoogle(query);
            }
            else if (choice == "3")
            {
                WIFI.present();
            }
            else if (choice == "4")
            {
                WIFI.previous();
            }
            else if (choice == "5")
            {
                processor.info();
            }
            else if (choice == "6")
            {
                IP.CompleteConfigration();
            }
            else if (choice == "7")
            {
                systemInfo.open();
            }
            else
            {
                userMenu.yes();
            }
        }
    }
    class USER_FileAndDirectory
    {
        public static void ChoiceFileAndDirectory()
        {
            Console.WriteLine(@"
                                            
                                

                                        WELCOME TO FILE DETAILS SYSTEM");
            Console.WriteLine(@"                        ''WE HAVE FIOLLOWING OPTIONS IN 'FILE DETAILS SYSTEM''
1: JUST DIRECTORY DETAILS OF 'JUNAID' 
2: See the whole files present in the Available Directory 
3: see the name of files along with the last accessed
4: see files with complete address of each
5: go to main menu");
            string CHOICE3 = Console.ReadLine();

            if (CHOICE3 == "1")
            {
                Console.Clear();
                USER_FileAndDirectory.choice1();


            }
            else if (CHOICE3 == "2")
            {
                Console.Clear();
                USER_FileAndDirectory.choice2();


            }
            else if (CHOICE3 == "3")
            {
                Console.Clear();
                USER_FileAndDirectory.choice3();


            }
            else if (CHOICE3 == "4")
            {
                Console.Clear();
                USER_FileAndDirectory.choice4();


            }
            else if (CHOICE3 == "5")
            {
                userMenu.yes();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t........Invalid Input Try again latter........");
                Console.ReadKey();
                Console.Clear();
                USER_FileAndDirectory.ChoiceFileAndDirectory();
            }
        }
        public static void choice1()
        {
            string rootpath = @"D:\Summer Semester 2021\Junaid";
            string[] dirs = Directory.GetDirectories(rootpath, "*", SearchOption.AllDirectories);
            var files = Directory.GetFiles(rootpath, "*.*", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
            Console.ReadKey();
            Console.Clear();
            USER_FileAndDirectory.ChoiceFileAndDirectory();
        }
        public static void choice2()
        {
            string rootpath = @"D:\Summer Semester 2021\Junaid";
            var files = Directory.GetFiles(rootpath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));//it'll just show the names of files                                                               
            }
            Console.ReadKey();
            Console.Clear();
            USER_FileAndDirectory.ChoiceFileAndDirectory();
        }
        public static void choice3()
        {
            string rootpath = @"D:\Summer Semester 2021\Junaid";
            var files = Directory.GetFiles(rootpath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                var info = new FileInfo(file);
                Console.WriteLine(); //complete information of the filees(size, last seen, etc)(we can)
            }
            Console.ReadKey();
            Console.Clear();
            USER_FileAndDirectory.ChoiceFileAndDirectory();
        }
        public static void choice4()
        {
            string rootpath = @"D:\Summer Semester 2021\Junaid";
            var files = Directory.GetFiles(rootpath, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Console.WriteLine(file);//file with complete address
                var info = new FileInfo(file);
            }
            Console.ReadKey();
            Console.Clear();
            USER_FileAndDirectory.ChoiceFileAndDirectory();
        }

    }
    class internet
    {

        public static void searchGoogle(string query)
        {
            Process.Start("http://google.com/search?q=" + query);
            Console.WriteLine("Do you want another browsing?     (y/n)");
            string c = Console.ReadLine();
            if (c == "yes" || c == "YES" || c == "y" || c == "Y")
            {
                Console.WriteLine("Enter what do you want to browse through google");
                string q = Console.ReadLine();
                internet.searchGoogle(q);
            }
            else if (c == "no" || c == "NO" || c == "n" || c == "N")
            {
                userMenu.yes();
            }
            else
            {
                userMenu.yes();
            }
        }
    }
    class WIFI
    {
        public static void present()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true; // new window open krny s mana kia h
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("netsh wlan show network");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
            userMenu.yes();
        }
        public static void previous()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true; // new window open krny s mana kia h
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("netsh wlan show profile key=clear");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
            userMenu.yes();
        }
    }
    class processor
    {
        public static void info()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true; // new window open krny s mana kia h
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            //to see the processor speed and processor info
            process.StandardInput.WriteLine("wmic cpu get name, maxclockspeed, currentclockspeed");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
            userMenu.yes();
        }
    }
    class systemInfo
    {
        public static void open()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true; // new window open krny s mana kia h
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("systeminfo");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
            userMenu.yes();
        }
    }

    class IP
    {
        public static void CompleteConfigration()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true; // new window open krny s mana kia h
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("ipconfig /all");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
            Console.Clear();
            userMenu.yes();
        }

    }





}

