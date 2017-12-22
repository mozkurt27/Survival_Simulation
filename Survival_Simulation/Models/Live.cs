namespace Survival_Simulation.Models
{
    public class Live
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _hp;

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        private int _attack;

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        private int _location;

        public int Location
        {
            get { return _location; }
            set { _location = value; }
        }
    }
}
