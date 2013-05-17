namespace GildedRose
{
    public struct SellInDays
    {
        private readonly int value;

        public SellInDays(int value)
        {
            this.value = value;
        }

        public static implicit operator SellInDays(int value)
        {
            return new SellInDays(value);
        }

        public static bool operator ==(SellInDays left, SellInDays right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SellInDays left, SellInDays right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(SellInDays left, SellInDays right)
        {
            return left.value < right.value;
        }

        public static bool operator >(SellInDays left, SellInDays right)
        {
            return left.value > right.value;
        }

        public bool IsOverdue
        {
            get { return value < 0; }
        }

        public bool Equals(SellInDays other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SellInDays && Equals((SellInDays)obj);
        }

        public override int GetHashCode()
        {
            return (int)value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public SellInDays Decrement()
        {
            return new SellInDays(value - 1);
        }

        public SellInDays Increment()
        {
            return new SellInDays(value + 1);
        }
    }
}