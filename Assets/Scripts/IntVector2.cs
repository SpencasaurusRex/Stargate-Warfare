namespace SpencerHaney
{
    public class IntVector2
    {
        private const int HashPrime = 486187739;

        private int x;
        private int y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is IntVector2)
            {
                IntVector2 other = obj as IntVector2;
                return other.GetType() == GetType() && other.X == X && other.Y == Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked // Ignore overflow
            {
                int hash = GetType().GetHashCode();
                hash = hash * HashPrime + x.GetHashCode();
                hash = hash * HashPrime + y.GetHashCode();
                return hash;
            }
        }
    }
}