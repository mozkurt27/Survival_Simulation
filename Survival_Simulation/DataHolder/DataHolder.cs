using Survival_Simulation.Models;
using System.Collections.Generic;

namespace Survival_Simulation.DataHolder
{
    public static class DataHolder
    {
        public static int Target { get; set; }
        public static List<Live> Lives = new List<Live>();
    }
}
