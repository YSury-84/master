using System.Runtime.InteropServices;

namespace Module5_itog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            cUserInfo yuouser = new cUserInfo();

            Console.WriteLine("Hello, World!");

            yuouser.SetUser();
            yuouser.GetInfo();

            Console.ReadLine();
        }

        private class cUserInfo
        {
            private (string Name, string FIO, int Age) User;
            private int PetCount = 0;
            private string[] PetName;

            private void SetPetName(int PetCount)
            {
                PetName = new string[PetCount];
                for (int i = 0; i < PetCount; i++)
                {
                    Console.WriteLine("Введите имя питомца номер ({0}):",i+1);
                    PetName[i] = Console.ReadLine();
                }
            }

            private static (string Name, string Fio, int Age) SetUserKey()
            {
                string Name = "";
                string Fio = "";
                string sAge = "";
                int Age = -1;
                Console.WriteLine("Здравствуйте! Давайте знакомиться.");
                Console.WriteLine("Как вас зовут:");
                while (Name == "")
                {
                    Name = Console.ReadLine();
                    if (Name == "") Console.WriteLine("Для продолжения необходимо обязательно ввести Имя! Как вас зовут:");
                }
                Console.WriteLine("Ваша фамилия:");
                while (Fio == "")
                {
                    Fio = Console.ReadLine();
                    if (Fio == "") Console.WriteLine("Для продолжения необходимо обязательно ввести Фамилию! Ваша фамилия:");
                }
                Console.WriteLine("Сколько вам лет:");
                while (Age <= 0)
                {
                    sAge = Console.ReadLine();
                    int.TryParse(sAge, out Age);
                    if (Age <=0) Console.WriteLine("Для продолжения необходимо обязательно ввести Возраст цифрами! Сколько вам лет:");
                }
                return (Name, Fio, Age);
            }

            public void SetUser()
            {
                User = SetUserKey();
                Console.WriteLine("");
                Console.WriteLine("Есть ли у вас добашние питомцы (yes/no):");
                string bPet = "";
                while (bPet != "yes" && bPet != "no")
                { 
                    bPet = Console.ReadLine();
                    if (bPet != "yes" && bPet != "no") { Console.WriteLine("Ответ не распознан, думаю у вас нет домашних животных."); bPet = "no"; }
                }
                if (bPet == "yes")
                {
                    Console.WriteLine("Сколько у вас домашних животных:");
                    int.TryParse(Console.ReadLine(), out PetCount);
                    SetPetName(PetCount);
                }

            }

            public void GetInfo()
            {
                Console.WriteLine("");
                Console.WriteLine("Собранные данные!");
                Console.WriteLine("Ваши Имя и Фамилия: "+ User.Name+ " "+ User.FIO);
                Console.WriteLine("Вам: " + User.Age + " лет.");
                if (PetCount == 0) 
                { 
                    Console.WriteLine("У вас нет домашних животных!"); 
                }
                else 
                {
                    Console.WriteLine("Ваших домашних животних зовут:");
                    for (int i = 0; i < PetCount; i++)
                        Console.Write(PetName[i]+",");
                }
            }

        }

    }
}