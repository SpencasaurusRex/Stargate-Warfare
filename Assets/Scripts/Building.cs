namespace SpencerHaney
{
    using UnityEngine;

    public class Building
    {

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }

        public Building(string name)
        {
            Name = name;
        }
    }
}
