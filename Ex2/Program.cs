using System;

namespace Ex2 ////  Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
              ////  Создайте структуру Account, содержащую Login и Password.
{
    class Program
    {
        struct Account
        {
            public string Login;
            public string Password;
            public void loadFromFile(string filename)
            {
                filename = "..\\..\\" + filename;
                System.IO.StreamReader sr = new System.IO.StreamReader(filename);

                Login = sr.ReadLine();

                Password = sr.ReadLine();

                sr.Close();
            }

        }
        static bool CheckLogAndPass(Account toCheck)
        {
            if (toCheck.Login == "root" && toCheck.Password == "GeekBrains")
                return true;
            else
                return false;
        }

         static string RightTryWord(int x)
        {
            string s = "";
            
            if (x % 10 == 1 && x != 11) s += " попытка";
            else
               
                if ((x >= 2 && x <= 4) || (x >= 22 && x <= 24) || (x >= 32 && x <= 34) || (x > 41 && x < 45)) s += " попытки";
            else
                    
                    if ((x == 11) || (x >= 5 && x <= 20) || (x >= 25 && x <= 30) || (x >= 35 && x < 41) || (x > 44 && x < 51)) s += " попыток";
            return s;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Программа проверки логина и пароля");
            int AmountOfTries = 3;

            string[] fileName = { "data.txt", "tryData.txt", "reallyTryData.txt" };

            Account account;
            account.Login = "";
            account.Password = "";

            int i = 0;

            do
            {
                Console.WriteLine("\nЗагруза файла: " + fileName[i]);
                account.loadFromFile(fileName[i]);

                Console.Write("Попытка авторизации: ");

                if (CheckLogAndPass(account))
                {

                    break;
                }
                else
                {
                    AmountOfTries--;
                    Console.WriteLine("Неверный ввод логина или пароля." +
                        Environment.NewLine + "У Вас осталось " + AmountOfTries + RightTryWord(AmountOfTries));
                }
                i++;
            } while (AmountOfTries > 0);

            Console.Write("Авторизация прошла успешна!");
        }
        }
    }


