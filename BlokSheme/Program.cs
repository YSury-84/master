using System;

namespace BlokSheme
{
    internal class Program
    {
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
        class User
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public bool IsPremium { get; set; }
        }

        class Module_12_1_5
        {
            private User[] userdb;
            public Module_12_1_5()
            {
                //Формирование БД Пользователей
                userdb = new User[5];
                userdb[0] = new User();
                userdb[0].Login = "petrov";
                userdb[0].Name = "Петр";
                userdb[0].IsPremium = false;
                userdb[1] = new User();
                userdb[1].Login = "smirnov";
                userdb[1].Name = "Женя";
                userdb[1].IsPremium = false;
                userdb[2] = new User();
                userdb[2].Login = "ivanov";
                userdb[2].Name = "Вася";
                userdb[2].IsPremium = true;
                userdb[3] = new User();
                userdb[3].Login = "sidorov";
                userdb[3].Name = "Александр";
                userdb[3].IsPremium = false;
                userdb[4] = new User();
                userdb[4].Login = "avdalyan";
                userdb[4].Name = "Саят";
                userdb[4].IsPremium = true;
            }

            public bool FindUserPremium(string username)
            {
                for (int i = 0; i < userdb.Length; i++)
                    if (userdb[i].Login == username)
                    {
                        Console.WriteLine("Здравствуйте: "+userdb[i].Name);
                        if (userdb[i].IsPremium = true)
                        { 
                            Console.WriteLine("Вы наш премиум пользователь!");
                            return true;
                        };
                        ShowAds();
                        return true;
                    }
                return false;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Представьтесь пожалуйста:");
            string username = Console.ReadLine();
            Module_12_1_5 premiumData = new Module_12_1_5();
            if (premiumData.FindUserPremium(username)==false)
            { 
                Console.WriteLine("Вы не наш пользователь!"); 
            }
            Console.ReadKey();
        }
    }
}