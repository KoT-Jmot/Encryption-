using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗКИ_Лаба1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "\\\\server\\UserData$\\1194871\\Desktop\\ЗКИ Лаба 1";
            FileInfo fi1 = new FileInfo(path+"\\1.txt");
            Random rnd = new Random();
            int a;
            bool cont = true;
            string FIO;
            string login;
            string Password ="";
            string keyWord;
            string inputLogin;
            string inputPassword;
            int schet = 0;
            string ProwerkaL ="";
            string ProwerkaP ="";
            string name = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1)Войти\n2)Создать\n3)Выйти");
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        while (a!=3)
                        {
                            Console.Clear();
                            Console.WriteLine("1)Войти\n2)Восстановить\n3)Назад");
                            a = Convert.ToInt32(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.Write("Введите Логин: ");
                                    inputLogin = Console.ReadLine();
                                    Console.Write("Введите Пароль: ");
                                    inputPassword = Console.ReadLine();
                                    using (StreamReader sr = fi1.OpenText())
                                    {
                                        string s = "";
                                        schet = 0;
                                        while ((s = sr.ReadLine()) != null)
                                        {
                                            if (schet == 0)
                                                name = s;
                                            if(schet==1)
                                                ProwerkaL = s;
                                            if (schet == 2)
                                                ProwerkaP = s;
                                            if(ProwerkaL == inputLogin && ProwerkaP == inputPassword)
                                            {
                                                a = 3;
                                                Console.WriteLine($"Привет, {name}!");
                                                Console.ReadKey();
                                                break;
                                            }
                                            schet++;
                                            if (schet == 4)
                                                schet = 0;
                                        }
                                    }
                                    if (a != 3)
                                    {
                                        Console.WriteLine("Неверные данные!");
                                        Console.ReadKey();
                                    }
                                    ProwerkaL = "";
                                    ProwerkaP = "";
                                    break;
                                case 2:



                                    Console.Write("Введите Логин: ");
                                    inputLogin = Console.ReadLine();
                                    Console.Write("Введите код: ");
                                    inputPassword = Console.ReadLine();
                                    using (StreamReader sr = fi1.OpenText())
                                    {
                                        string s = "";
                                        schet = 0;
                                        while ((s = sr.ReadLine()) != null)
                                        {
                                            if (schet == 3)
                                                ProwerkaP = s;
                                            if (schet == 1)
                                                ProwerkaL = s;
                                            if (schet == 2)
                                                name = s;
                                            if (ProwerkaL == inputLogin && ProwerkaP == inputPassword)
                                            {
                                                a = 3;
                                                Console.WriteLine($"Ваш пароль: {name}");
                                                Console.ReadKey();
                                                break;
                                            }
                                            schet++;
                                            if (schet == 4)
                                                schet = 0;
                                        }
                                    }
                                    if (a != 3)
                                    {
                                        Console.WriteLine("Неверные данные!");
                                        Console.ReadKey();
                                    }
                                    ProwerkaL = "";
                                    ProwerkaP = "";
                                    break;




                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Введите ФИО: ");
                        FIO = Console.ReadLine();
                        Console.Write("Введите Логин: ");
                        login = Console.ReadLine();
                        Console.Write("Ваш Пароль: ");
                        cont = true;
                        while (cont)
                        {
                            Password = "";
                            for (int i=0;i<5;i++)
                                Password = Password + Convert.ToChar(rnd.Next(48, 122));
                            if (!Char.IsPunctuation(Password[0]))
                                cont = false;

                        }
                        Console.WriteLine(Password);
                        Console.ReadKey();
                        Console.Write("Введите Ключивое слово: ");
                        keyWord = Console.ReadLine();
                        if (Char.IsPunctuation(FIO[0]) || FIO[0] == ' ' || Char.IsPunctuation(login[0]) || login[0] == ' ' || Char.IsPunctuation(keyWord[0]) || keyWord[0] == ' ')
                        {
                            Console.Write("Вы ввели неверные данные!");
                            Console.ReadKey();
                        }
                        else
                        {

                                //Create a file to write to.
                                using (StreamWriter sw = fi1.AppendText())
                                {
                                    sw.WriteLine(FIO);
                                    sw.WriteLine(login);
                                    sw.WriteLine(Password);
                                    sw.WriteLine(keyWord);
                                }
                        }
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
