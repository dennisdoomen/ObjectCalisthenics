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
            Quality = Quality.Decrease();

            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                Quality = Quality.Decrease();
            }
        }
    }
}