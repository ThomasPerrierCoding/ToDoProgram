using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class Program
    {
        const int ARRAYSIZE = 10;
        static int c = 0;
        static int i = 0;
        static int j = 0;
        static int k = 0;
        static string[] tasks = new string[ARRAYSIZE];
        static string[] date = new string[ARRAYSIZE];
        static int[] importance = new int[ARRAYSIZE];

        static void Main(string[] args)
        {
            for (; ; )
            {
                presentMenu();
            }
        }
        static void displayImportant()
        {
            Console.WriteLine("\nAll Important Tasks:\n");
            for(int j=0;j<10;j++)
            {
                if(importance[j]==1)
                {
                    Console.WriteLine(tasks[j]);
                }
            }
        }
        static void displayNonImportant()
        {
            Console.WriteLine("\nAll Non-Important Tasks:\n");
            for (int j = 0; j < 10; j++)
            {
                if (importance[j] == 2)
                {
                    Console.WriteLine(tasks[j]);
                }
            }
        }
        static void displayTasks()
        {
            Console.WriteLine();
            for(int i=0;i<10;i++)
            {
                if (importance[i] == 1)
                {
                    Console.WriteLine("Task " + (i + 1) + ": " + tasks[i] + " | Importance: Important | Due Date: " + date[i]);
                }
                else if (importance[i] == 2)
                {
                    Console.WriteLine("Task " + (i + 1) + ": " + tasks[i] + " | Importance: Non-Important | Due Date: " + date[i]);
                }
                else
                {
                    Console.WriteLine("Task " + (i + 1) + ": N/A | Importance: N/A | Due Date: N/A");
                }
            }
        }
        static void addTask()
        {
            if(i==10)
            {
                Console.WriteLine("\nYou have reached the max number of tasks you can add to the list!\n");
            }
            else
            {
                Console.WriteLine("\nPlease enter the task you would like to add: ");
                tasks[i] = Console.ReadLine();
                i++;
            }
        }
        static void setImportance()
        {
            string choice = "";
            Console.WriteLine("\nPlease enter the importance of the task (1=important, 2=non-important): ");
            choice = Console.ReadLine();
            if(choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid input! Input must be either a 1 or a 2!");
                setImportance();
            }
            else if(choice=="1")
            {
                importance[j] = 1;
                j++;
            }
            else
            {
                importance[j] = 2;
                j++;
            }
        }
        static void setDueDate()
        {
            Console.WriteLine("\nPlease enter the Due Date of the task: ");
            date[k] = Console.ReadLine();
            k++;
        }
        static void removeTask()
        {
            string choice_ = "";
            int choice = 0;
            Console.WriteLine("\nPlease enter the number of the task you want to remove: ");
            choice_ = Console.ReadLine();
            if (int.TryParse(choice_, out choice))
            {
                choice = Convert.ToInt16(choice_);
                if(choice < 1 || choice > 10)
                {
                    Console.WriteLine("ERROR! Input is out of range! Must be a number 1 - 10!");
                    removeTask();
                }
                else
                {
                    tasks[choice - 1] = "";
                    importance[choice - 1] = 0;
                }
            }
            else
            {
                Console.WriteLine("ERROR! Input is non-numeric or was left blank!");
                removeTask();
            }

        }
        static void removeAll()
        {
            for(int i=0;i<10;i++)
            {
                tasks[i] = "";
                importance[i] = 0;
            }
            Console.WriteLine("\nAll Tasks Removed.");
        }
        static void presentMenu()
        {
            int menueChoice = 0;

            if(c==0)
            {
                Console.WriteLine("\t\tTo Do List Program");
                c++;
            }
            
            Console.WriteLine("\nEnter a 1 add a task");
            Console.WriteLine("Enter a 2 to show all tasks");
            Console.WriteLine("Enter 3 to show all important tasks");
            Console.WriteLine("Enter a 4 to show all non-important tasks");
            Console.WriteLine("Enter a 5 to remove a single task");
            Console.WriteLine("Enter a 6 to remove all tasks");
            Console.WriteLine("Enter a 7 to quit the program");
            Console.Write("Enter a 1, 2, 3, 4, 5, 6, or 7 now: ");
            menueChoice = Convert.ToInt16(Console.ReadLine());

            while ((menueChoice != 1) && (menueChoice != 2) && (menueChoice != 3) && (menueChoice != 4) && (menueChoice != 5) && (menueChoice != 6) && (menueChoice != 7))
            {
                Console.Clear();
                presentMenu();
            }
            switch (menueChoice)
            {
                case 1:
                    addTask();
                    if(j!=10)
                    {
                        setImportance();
                    }
                    if (k != 10)
                    {
                        setDueDate();
                    }
                    break;

                case 2:
                    displayTasks();
                    break;

                case 3:
                    displayImportant();
                    break;

                case 4:
                    displayNonImportant();
                    break;

                case 5:
                    removeTask();
                    break;

                case 6:
                    removeAll();
                    break;

                case 7:
                    Console.WriteLine("\nAre you sure you want to close the program?? (1=yes, anything else=no) ");
                    if(Console.ReadLine()=="1")
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    break;
                    
                default:
                    break;
            }
        }
    }
}
