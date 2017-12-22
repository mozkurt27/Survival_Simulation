using Survival_Simulation.Managers;
using Survival_Simulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival_Simulation
{
    class Program
    {
        static DataManager manager = new DataManager();
        static void Main(string[] args)
        {
            Console.WriteLine("Press '1' to enter the parameters,\nPress '2' to read the parameters from the file.");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Clear();
                EnterTheParameters();

            }
            else if (choice == 2)
            {
                Console.Clear();
                ReadToFile("input.txt");
            }
            else
            {
                Console.WriteLine("Wrong Choice !!");
            }
            Console.ReadKey();
        }
        static void ReadToFile(string path)
        {
            
            manager.Read(path);
            WarManager war = new WarManager();
            war.Simulation_War(manager);
            //war.Alternative_Simulation_War(manager);
        }
        static void EnterTheParameters()
        {
            Live newLive = new Live();

            Console.Write("Distance from the Resource: ");
            DataHolder.DataHolder.Target = int.Parse(Console.ReadLine());

            Console.Write("Hero Name: ");
            newLive.Name = Console.ReadLine();
            Console.Write("Hero HP: ");
            newLive.HP = int.Parse(Console.ReadLine());
            Console.Write("Hero attack: ");
            newLive.Attack = int.Parse(Console.ReadLine());
            newLive.Location = 0;
            DataHolder.DataHolder.Lives.Add(newLive);

            Console.Write("How many Enemies are out there? : ");
            int enemiesCount = int.Parse(Console.ReadLine());

            for(int i = 0; i < enemiesCount; i++)
            {
                newLive = new Live();
                Console.Write("Enemy Name: ");
                newLive.Name = Console.ReadLine();
                Console.Write("Enemy HP: ");
                newLive.HP = int.Parse(Console.ReadLine());
                Console.Write("Enemy attack: ");
                newLive.Attack = int.Parse(Console.ReadLine());
                Console.Write("Enemy location: ");
                newLive.Location = int.Parse(Console.ReadLine());
                DataHolder.DataHolder.Lives.Add(newLive);
            }
            Console.Clear();
            WarManager war = new WarManager();
            war.Simulation_War(manager);
           // war.Alternative_Simulation_War(manager);

        }
    }
}
