using System;
using System.Collections.Generic;

namespace GildedRose
{
    public abstract class Item
    {
        private readonly string name;
        private Days shelfLife;
        private Quality quality;

        protected Item(string name, Days shelfLife, Quality quality)
        {
            this.name = name;
            this.quality = quality;
            this.shelfLife = shelfLife;
        }

        public bool IsExpired => (shelfLife < new Days(0));

        public Days DaysOverdue => (shelfLife > new Days(0)) ? new Days(0) : -shelfLife;

        public static IComparer<Item> ByQualityComparer => new QualityComparer();

        public abstract void OnDayHasPassed();

        public override string ToString()
        {
            return $"{name} (quality {quality}, sell in {shelfLife} days)";
        }

        protected bool Equals(Item other)
        {
            return shelfLife.Equals(other.shelfLife) && string.Equals(name, other.name) && quality.Equals(other.quality);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals((Item)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = shelfLife.GetHashCode();
                hashCode = (hashCode * 397) ^ name.GetHashCode();
                hashCode = (hashCode * 397) ^ quality.GetHashCode();
                return hashCode;
            }
        }

        protected void IncreaseQuality()
        {
            quality = quality.Increase();
        }

        protected void DecreaseQuality()
        {
            quality = quality.Decrease();
        }

        protected void Devaluate()
        {
            quality = new Quality(0);
        }

        protected void ReduceShelfLife()
        {
            shelfLife = shelfLife.ReduceByOneDay();
        }

        protected bool IsDueWithin(Days days)
        {
            return shelfLife < days;
        }

        private class QualityComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                return x.quality.CompareTo(y.quality);
            }
        }
    }
}