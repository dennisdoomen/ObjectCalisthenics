namespace GildedRose
{
    public class ElixirOfTheMongoose : Item
    {
        public ElixirOfTheMongoose(int sellIn, Quality quality)
            : base("Elixir of the Mongoose", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0 && Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}