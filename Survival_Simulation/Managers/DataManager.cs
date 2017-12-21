using Survival_Simulation.Models;
using System;
using System.IO;

namespace Survival_Simulation.Managers
{
    public class DataManager
    {
        public void Read(string path)
        {
            string fullpath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\","") +"Files\\"+path;
            using (StreamReader sr = new StreamReader(fullpath))
            {
                string temp = "";
                bool state = false;
                while (!sr.EndOfStream)
                {
                    if (!state)
                    {
                        temp = sr.ReadLine();
                        DataHolder.DataHolder.Target = int.Parse(temp);
                        state = true;
                    }
                    else
                    {
                        temp = sr.ReadLine();
                        Creator_Live(temp);
                    }
                }
            }
        }
        public void Write(string result) {
            string fullpath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "") + "Files\\output.txt";
            using (StreamWriter sw = new StreamWriter(fullpath,true))
            {
                sw.WriteLine(result);
            }
        }
        private void Creator_Live(string info)
        {
            string[] infos = info.Split(' ');
            int length = infos.Length;
            if (length == 4)
            {
                Live newLive = new Live()
                {
                    Name = infos[0],
                    HP = int.Parse(infos[1]),
                    Attack = int.Parse(infos[2]),
                    Location = int.Parse(infos[3])
                };
                if (newLive.Location < DataHolder.DataHolder.Target)
                    DataHolder.DataHolder.Lives.Add(newLive);
            }
            else
            {
                for (int i = 3; i < length; i++)
                {
                    Live newLive = new Live()
                    {
                        Name = infos[0],
                        HP = int.Parse(infos[1]),
                        Attack = int.Parse(infos[2]),
                        Location = int.Parse(infos[i])
                    };
                    if (newLive.Location < DataHolder.DataHolder.Target)
                        DataHolder.DataHolder.Lives.Add(newLive);
                }
            }
        }
    }
}
