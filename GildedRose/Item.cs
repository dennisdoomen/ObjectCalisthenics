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

        public bool IsExpired
        {
            get { return shelfLife < new Days(0); }
        }

        public Days DaysOverdue
        {
            get { return (shelfLife > new Days(0)) ? new Days(0) : -shelfLife; }
        }

        public static IComparer<Item> ByQualityComparer
        {
            get { return new QualityComparer(); }
        }

        public bool HasMaximumQuality
        {
            get { return quality.HasMaximumQuality; }
        }

        public abstract void OnDayHasPassed();

        public override string ToString()
        {
            return string.Format("{0} (quality {1}, sell in {2} days)", name, quality, shelfLife);
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

        private class QualityComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                return x.quality.CompareTo(y.quality);
            }
        }

        protected void IncreaseQuality()
        {
            quality = quality.Increase();
        }

        protected void ReduceShelfLife()
        {
            shelfLife = shelfLife.ReduceByOneDay();
        }

        protected void DecreaseQuality()
        {
            quality = quality.Decrease();
        }

        protected bool IsDueWithin(Days days)
        {
            return shelfLife < days;
        }

        protected void Devaluate()
        {
            quality = new Quality(0);
        }
    }
}