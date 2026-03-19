using System;
using System.Collections.Generic;

namespace To_do_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
            int choice;

            do
            {
                Console.WriteLine("\nTo-Do List Manager.");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(task))
                        {
                            Console.WriteLine("Task cannot be empty.");
                        }
                        else
                        {
                            tasks.Add(task);
                            Console.WriteLine("Task added!");
                        }
                        break;

                    case 2:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks available.");
                        }
                        else
                        {
                            Console.WriteLine("Tasks:");
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                        }
                        break;

                    case 3:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks to remove.");
                            break;
                        }
                        Console.Write("Enter task number to remove: ");
                        if (!int.TryParse(Console.ReadLine(), out int index))
                        {
                            Console.WriteLine("Invalid input. Enter a number.");
                        }
                        else if (index < 1 || index > tasks.Count)
                        {
                            Console.WriteLine("Invalid task number.");
                        }
                        else
                        {
                            string removedTask = tasks[index - 1];
                            tasks.RemoveAt(index - 1);
                            Console.WriteLine($"Removed: {removedTask}");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 4);
        }
    }
}
