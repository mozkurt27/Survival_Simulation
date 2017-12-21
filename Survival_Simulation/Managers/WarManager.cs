using Survival_Simulation.Models;
using System;
using System.Linq;

namespace Survival_Simulation.Managers
{
    public class WarManager
    {
        public void Start_War(DataManager menager)
        {

            int Target = DataHolder.DataHolder.Target;
            Live hero = DataHolder.DataHolder.Lives.FirstOrDefault();

            Console.WriteLine(hero.Name + " started journey with " + hero.HP + " HP!");
            menager.Write(hero.Name + " started journey with " + hero.HP + " HP!");
            for (int i = 1; i <= Target; i++)
            {
                Live enemy = Search_Enemy(i);
                if (enemy != null)
                {
                    int tempHP = hero.HP;
                    bool state = Attack(hero, enemy);
                    if (state)
                    {
                        hero.Location = i;
                        Console.WriteLine(hero.Name + " defeated "+ enemy.Name +" with "+ hero.HP+" HP remaining");
                        menager.Write(hero.Name + " defeated " + enemy.Name + " with " + hero.HP + " HP remaining");
                    }
                    else
                    {
                        hero.Location = i;
                        Console.WriteLine(hero.Name + " is Dead! Last seen at position " + hero.Location + "!!");
                        menager.Write(hero.Name + " is Dead! Last seen at position " + hero.Location + "!!");
                        break;
                    }

                    if (hero.Location == Target)
                    {
                        Console.WriteLine(hero.Name + " Survived!");
                        menager.Write(hero.Name + " Survived!");
                        break;
                    }
                }
                else
                {
                    hero.Location = i;
                    if (hero.Location == Target)
                    {
                        Console.WriteLine(hero.Name + " Survived!");
                        menager.Write(hero.Name + " Survived!");
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
            int attack_count = (int)Math.Ceiling((decimal)enemy.HP / hero.Attack);
            int hp = (attack_count - 1) * enemy.Attack;

            if (hp >= hero.HP)
            {
                hero.HP = 0;
                return false;
            }

            hero.HP -= hp;
            return true;
        }

    }
}
