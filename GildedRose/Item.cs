using System;

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

        public SellInDays SellInDays { get; set; }

        public Quality Quality { get; set; }

        public int DaysOverdue
        {
            get { return SellInDays.DaysOverdue; }
        }

        public abstract void HandleDayChange();

        public override string ToString()
        {
            return name;
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
    }
}