namespace GildedRose
{
    public class DexterityVest : Item
    {
        public DexterityVest(Days shelfLife, Quality quality)
            : base("+5 Dexterity Vest", shelfLife, quality)
        {
        }

        public override void OnDayHasPassed()
        {
            ReduceShelfLife();
            if (IsExpired)
            {
                DecreaseQuality();
            }

            DecreaseQuality();
        }
    }
}