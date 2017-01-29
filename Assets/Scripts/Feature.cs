namespace SpencerHaney
{
    using UnityEngine;

    public class Feature
    {
        // Physical features
        public static Feature Forest = new Feature("Forest", 1.25f);
        public static Feature Mountain = new Feature("Mountain", 2);
        public static Feature Volcano = new Feature("Volcano", false);
        public static Feature Lava = new Feature("Lava", false);

        // Benefits
        public static Feature Naquadah = new Feature("Naquadah");
        public static Feature Metal = new Feature("Metal");
        public static Feature RichSoil = new Feature("Rich Soil");
        public static Feature AncientRuins = new Feature("Ancient Ruins");
        public static Feature AvancedRuins = new Feature("Advanced Society Ruins");

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

        public float BuildTimeMultiplier
        {
            set;
            get;
        }

        public bool CanBeBuiltOn
        {
            set;
            get;
        }

        public Feature(string name) : this(name, 1.0f) { }

        public Feature(string name, float buildTimeMultiplier) : this(name, true)
        {
            BuildTimeMultiplier = buildTimeMultiplier;
            if (float.IsPositiveInfinity(buildTimeMultiplier))
            {
                CanBeBuiltOn = false;
            }
        }

        public Feature(string name, bool canBeBuiltOn)
        {
            CanBeBuiltOn = canBeBuiltOn;
            if (!CanBeBuiltOn)
            {
                BuildTimeMultiplier = float.PositiveInfinity;
            }
        }
    }
}