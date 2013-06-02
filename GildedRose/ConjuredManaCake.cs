namespace GildedRose
{
    public class ConjuredManaCake : Item
    {
        public ConjuredManaCake(Days shelfLife, Quality quality)
            : base("Conjured Mana Cake", shelfLife, quality)
        {
        }

        public override void OnDayHasPassed()
        {
            DecreaseQuality();

            ReduceShelfLife();
            if (IsExpired)
            {
                DecreaseQuality();
            }
        }
    }
}