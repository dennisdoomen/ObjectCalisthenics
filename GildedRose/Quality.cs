namespace GildedRose
{
    public struct Quality
    {
        private readonly uint value;

        public Quality(uint value)
        {
            this.value = value;
        }

        public static implicit operator Quality(uint value)
        {
            return new Quality(value);
        }

        public static bool operator ==(Quality left, Quality right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Quality left, Quality right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Quality x, uint y)
        {
            return x.value < y;
        }

        public static bool operator >(Quality x, uint y)
        {
            return x.value > y;
        }

        public static Quality operator +(Quality x, uint y)
        {
            return new Quality(x.value + y);
        }
        public static Quality operator -(Quality x, uint y)
        {
            return new Quality(x.value - y);
        }
        public static Quality operator -(Quality x, Quality y)
        {
            return new Quality(x.value - y.value);
        }

        public bool Equals(Quality other)
        {
            return value == other.value;
        }

        public bool Equals(uint other)
        {
            return value == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return ((obj is Quality) && Equals((Quality) obj)) || 
                ((obj is uint) && Equals((uint)obj));
        }

        public override int GetHashCode()
        {
            return (int) value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}