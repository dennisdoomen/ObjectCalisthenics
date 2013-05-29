using System;
using System.Collections.Generic;

namespace GildedRose
{
    public abstract class Item
    {
        private readonly string name;

        protected Item(string name, SellInDays sellIn, Quality quality)
        {
            this.name = name;
            Quality = quality;
            SellInDays = sellIn;
        }

        protected SellInDays SellInDays { get; set; }

        protected Quality Quality { get; set; }

        public bool IsOverdue
        {
            get { return SellInDays.IsOverdue; }
        }

        public int DaysOverdue
        {
            get { return SellInDays.DaysOverdue; }
        }

        public static IComparer<Item> ByQualityComparer
        {
            get { return new QualityComparer(); }
        }

        public abstract void HandleDayChange();

        public override string ToString()
        {
            return string.Format("{0} (quality {1}, sell in {2} days)", name, Quality, SellInDays);
        }

        protected bool Equals(Item other)
        {
            return SellInDays.Equals(other.SellInDays) && string.Equals(name, other.name) && Quality.Equals(other.Quality);
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
                int hashCode = SellInDays.GetHashCode();
                hashCode = (hashCode * 397) ^ name.GetHashCode();
                hashCode = (hashCode * 397) ^ Quality.GetHashCode();
                return hashCode;
            }
        }

        private class QualityComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                return x.Quality.CompareTo(y.Quality);
            }
        }
    }
}