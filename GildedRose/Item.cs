using System;

namespace GildedRose
{
    public abstract class Item
    {
        private String name;

        protected Item(string name, int sellIn, Quality quality)
        {
            this.name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public int SellIn { get; set; }

        public Quality Quality { get; set; }

        public string Name
        {
            get { return name; }
        }

        public abstract void UpdateQuality();
    }
}