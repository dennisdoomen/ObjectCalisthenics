using System;

namespace GildedRose
{
    public abstract class Item
    {
        private readonly String name;

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

        public abstract void UpdateQuality();
    }
}