using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal class Program
    {  static string[] fio = new string[100]; // массив фио
            static string[] position = new string[100]; // массив должностей
            static int count = 0; // количество записей в массивах
        static void Main(string[] args)
        {
            fio[count] = "Иванов Иван Иванович";
            position[count] = "Главный инженер";
            count++;

            fio[count] = "Петров Петр Петрович";
            position[count] = "Разработчик";
            count++;

            int choice = 0;
                while (choice != 5)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Добавить досье");
                    Console.WriteLine("2. Вывести все досье");
                    Console.WriteLine("3. Удалить досье");
                    Console.WriteLine("4. Поиск по фамилии");
                    Console.WriteLine("5. Выход");
                    Console.Write("Введите номер действия: ");
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            AddDossier();
                            break;
                        case 2:
                            PrintDossiers();
                            break;
                        case 3:
                            DeleteDossier();
                            break;
                        case 4:
                            SearchByLastName();
                            break;
                        case 5:
                            Console.WriteLine("До свидания!");
                        
                            break;
                        default:
                            Console.WriteLine("Некорректный выбор действия.");
                            break;
                    }

                    Console.ReadLine();
                }
            }

            static void AddDossier()
            {
                Console.Write("Введите ФИО: ");
                string newFio = Console.ReadLine();
                Console.Write("Введите должность: ");
                string newPosition = Console.ReadLine();

                fio[count] = newFio;
                position[count] = newPosition;
                count++;

                Console.WriteLine("Досье добавлено.");
            }

            static void PrintDossiers()
            {
                if (count == 0)
                {
                    Console.WriteLine("Нет записей в досье.");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine("{0}. {1} - {2}", i + 1, fio[i], position[i]);
                    }
                }
            }

            static void DeleteDossier()
            {
                Console.Write("Введите номер записи для удаления: ");
                int index = int.Parse(Console.ReadLine());

                if (index < 1 || index > count)
                {
                    Console.WriteLine("Некорректный номер записи.");
                }
                else
                {
                    for (int i = index - 1; i < count - 1; i++)
                    {
                        fio[i] = fio[i + 1];
                        position[i] = position[i + 1];
                    }
                    count--;

                    Console.WriteLine("Досье удалено.");
                }
            }

            static void SearchByLastName()
            {
                Console.Write("Введите фамилию для поиска: ");
                string lastName = Console.ReadLine();

                bool found = false;
                for (int i = 0; i < count; i++)
                {
                    if (fio[i].Split(' ')[0] == lastName)
                    {
                        Console.WriteLine("{0}. {1} - {2}", i + 1, fio[i], position[i]);
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Нет записей с такой фамилией.");
                }
            }
    }
}
