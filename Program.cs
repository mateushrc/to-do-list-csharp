using System;
using System.Collections.Generic;

namespace ToDoList
{
    public class Program
    {
        static List<string> tasks = new List<string>();

        public static void Main(string[] args) { ShowMenu(); }

        public static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayTasks();

                Console.WriteLine("1 - Add Task");
                Console.WriteLine("2 - Edit Task");
                Console.WriteLine("3 - Delete Task");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("");
                Console.Write("Choose: ");

                string? choiceString = Console.ReadLine();
                int choice;

                if (!int.TryParse(choiceString, out choice))
                {
                    ShowError();
                    continue;
                }

                switch (choice)
                {
                    case 0: return;
                    case 1: AddTask(); break;
                    case 2: EditTask(); break;
                    case 3: DeleteTask(); break;
                    default:
                        ShowError();
                        break;
                }
            }
        }

        public static void DisplayTasks()
        {
            Console.WriteLine("--- TASKS ---");
            Console.WriteLine("");

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet!");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i}. {tasks[i]}");
                }
            }
            Console.WriteLine("");
        }

        public static void AddTask()
        {
            Console.Clear();
            Console.WriteLine("Enter the task you wish to add:");
            Console.WriteLine("");
            string? taskContent = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(taskContent))
            {
                tasks.Add(taskContent!);
                Console.WriteLine("");
                Console.WriteLine("Task successfully added!");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }

            GoBack();
        }

        public static void EditTask()
        {
            Console.Clear();
            DisplayTasks();

            if (tasks.Count == 0)
            {
                GoBack();
                return;
            }

            Console.WriteLine("Which task do you want to edit? (Enter the index number!)");
            Console.WriteLine("");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int index) && index >= 0 && index < tasks.Count)
            {
                Console.Clear();
                Console.WriteLine($"Current Task {index}: {tasks[index]}");
                Console.WriteLine("Enter the new text:");
                Console.WriteLine("");

                string? newContent = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newContent))
                {
                    tasks[index] = newContent!;
                    Console.WriteLine("");
                    Console.WriteLine("Task successfully updated!");
                }
                else
                {
                    Console.WriteLine("Update cancelled: Task content cannot be empty.");
                }
            }
            else
            {
                ShowError();
            }

            GoBack();
        }
        public static void DeleteTask()
        {
            Console.Clear();
            DisplayTasks();

            if (tasks.Count == 0)
            {
                GoBack();
                return;
            }

            Console.WriteLine("Which task do you want to delete? (Enter the index number!)");
            Console.WriteLine("");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int index) && index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("");
                Console.WriteLine("Task successfully removed!");
            }
            else
            {
                ShowError();
            }

            GoBack();
        }

        public static void ShowError()
        {
            Console.WriteLine("Invalid Input, Try again!");
            Console.ReadKey();
        }

        public static void GoBack()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }
    }
}
