namespace GildedRose
{
    public class Sulfuras : Item
    {
        public Sulfuras(SellInDays sellIn, Quality quality)
            : base("Sulfuras, Hand of Ragnaros", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
        }
    }
}