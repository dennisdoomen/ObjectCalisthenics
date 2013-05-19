namespace GildedRose
{
    public class ElixirOfTheMongoose : Item
    {
        public ElixirOfTheMongoose(SellInDays sellIn, Quality quality)
            : base("Elixir of the Mongoose", sellIn, quality)
        {
        }

        public override void HandleDayChange()
        {
            Quality = Quality.Decrease();

            SellInDays = SellInDays.Decrement();

            if (SellInDays.IsOverdue)
            {
                Quality = Quality.Decrease();
            }
        }
    }
}