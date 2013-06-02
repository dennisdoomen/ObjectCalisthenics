using System;

namespace GildedRose
{
    public struct Days : IComparable
    {
        private readonly int value;

        public Days(int value)
        {
            this.value = value;
        }

        public static bool operator ==(Days left, Days right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Days left, Days right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Days left, Days right)
        {
            return left.value < right.value;
        }

        public static bool operator >(Days left, Days right)
        {
            return left.value > right.value;
        }

        public static Days operator -(Days left)
        {
            return new Days(-left.value);
        }

        public bool Equals(Days other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Days && Equals((Days)obj);
        }

        public override int GetHashCode()
        {
            return (int)value;
        }

        public int CompareTo(object obj)
        {
            return value.CompareTo(((Days)obj).value);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public Days ReduceByOneDay()
        {
            return new Days(value - 1);
        }
    }
}