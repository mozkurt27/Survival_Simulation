using Survival_Simulation.Models;
using System;
using System.Linq;

namespace Survival_Simulation.Managers
{
    public class WarManager
    {
        public void Alternative_Simulation_War(DataManager manager)
        {
            int length = DataHolder.DataHolder.Lives.Count;

            if (length > 1)
            {
                Live hero = DataHolder.DataHolder.Lives.FirstOrDefault();
                bool survived = true;

                Console.WriteLine(hero.Name + " started journey with " + hero.HP + " HP!");
                manager.Write(hero.Name + " started journey with " + hero.HP + " HP!");

                for (int i = 1; i < length; i++)
                {
                    Live enemy = DataHolder.DataHolder.Lives[i];
                    bool state = Alternative_Attack(hero, enemy);
                    
                    if (state)
                    {
                        Console.WriteLine(hero.Name + " defeated " + enemy.Name + " with " + hero.HP + " HP remaining");
                        manager.Write(hero.Name + " defeated " + enemy.Name + " with " + hero.HP + " HP remaining");
                        
                    }
                    else
                    {
                        Console.WriteLine(hero.Name + " is Dead! Last seen at position " + hero.Location + "!!");
                        manager.Write(hero.Name + " is Dead! Last seen at position " + hero.Location + "!!");
                        survived = false;
                        break;
                    }

                }
                if (survived)
                {
                    Console.WriteLine(hero.Name + " Survived!");
                    manager.Write(hero.Name + " Survived!");
                }
            }
        }
        public void Simulation_War(DataManager manager)
        {
            
            int Target = DataHolder.DataHolder.Target;
            Live hero = DataHolder.DataHolder.Lives.FirstOrDefault();

            Console.WriteLine(hero.Name + " started journey with " + hero.HP + " HP!");
            manager.Write(hero.Name + " started journey with " + hero.HP + " HP!");
            for (int i = 1; i <= Target; i++)
            {
                Live enemy = Search_Enemy(i);
                if (enemy != null)
                {
                    //int tempHP = hero.HP;
                    bool state = Attack(hero, enemy);
                    if (state)
                    {
                        hero.Location = i;
                        Console.WriteLine(hero.Name + " defeated " + enemy.Name + " with " + hero.HP + " HP remaining");
                        manager.Write(hero.Name + " defeated " + enemy.Name + " with " + hero.HP + " HP remaining");
                    }
                    else
                    {
                        hero.Location = i;
                        Console.WriteLine(hero.Name + " is Dead! Last seen at position " + hero.Location + "!!");
                        manager.Write(hero.Name + " is Dead! Last seen at position " + hero.Location + "!!");
                        break;
                    }

                    if (hero.Location == Target)
                    {
                        Console.WriteLine(hero.Name + " Survived!");
                        manager.Write(hero.Name + " Survived!");
                        break;
                    }
                }
                else
                {
                    hero.Location = i;
                    if (hero.Location == Target)
                    {
                        Console.WriteLine(hero.Name + " Survived!");
                        manager.Write(hero.Name + " Survived!");
                        break;
                    }
                }

            }
        }
        private Live Search_Enemy(int location)
        {
            int length = DataHolder.DataHolder.Lives.Count();

            for (int i = 1; i < length; i++)
            {
                if (location == DataHolder.DataHolder.Lives[i].Location)
                {
                    return DataHolder.DataHolder.Lives[i];
                }
            }

            return null;

        }

        private bool Attack(Live hero, Live enemy)
        {
            /*
            Hp Function
                1.First Hero Attack
                    attack_count = enemy.HP/hero.Attack
                    hp = (attack_count - 1) * enemy.Attack
                2.First Enemy Attack
                    attack_count = enemy.HP/hero.Attack
                    hp = attack_count*enemy.Attack
                3. Same time Attack
                    attack_count = enemy.HP/hero.Attack
                    hp = (attack_count-1)*enemy.Attack
            */

            int attack_count = (int)Math.Ceiling((decimal)enemy.HP / hero.Attack);
            int hp = (attack_count - 1) * enemy.Attack;

            if (hp >= hero.HP)
            {
                hero.HP = 0;
                hero.Location = enemy.Location;
                return false;
            }

            DataHolder.DataHolder.Lives.Remove(enemy);
            hero.HP -= hp;
            hero.Location = enemy.Location;


            return true;
        }

        private bool Alternative_Attack(Live hero, Live enemy)
        {
            /*
           Hp Function
               1.First Hero Attack
                   attack_count = enemy.HP/hero.Attack
                   hp = (attack_count - 1) * enemy.Attack
               2.First Enemy Attack
                   attack_count = enemy.HP/hero.Attack
                   hp = attack_count*enemy.Attack
               3. Same time Attack
                   attack_count = enemy.HP/hero.Attack
                   hp = (attack_count-1)*enemy.Attack
           */

            int attack_count = (int)Math.Ceiling((decimal)enemy.HP / hero.Attack);
            int hp = (attack_count - 1) * enemy.Attack;

            if (hp >= hero.HP)
            {
                hero.HP = 0;
                hero.Location = enemy.Location;
                return false;
            }

            //DataHolder.DataHolder.Lives.Remove(enemy);
            hero.HP -= hp;
            hero.Location = enemy.Location;


            return true;
        }
    }
}
