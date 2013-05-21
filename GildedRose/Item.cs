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

        public string Name
        {
            get { return name; }
        }

        public int DaysOverdue
        {
            get { return SellInDays.DaysOverdue; }
        }

        public abstract void HandleDayChange();

        public override string ToString()
        {
            return name;
        }
    }
}