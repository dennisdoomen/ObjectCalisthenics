namespace GildedRose
{
    public class BackstagePass : Item
    {
        public BackstagePass(Days shelfLife, Quality quality)
            : base("Backstage passes to a TAFKAL80ETC concert", shelfLife, quality)
        {
        }

        public override void OnDayHasPassed()
        {
            ReduceShelfLife();
            if (IsExpired)
            {
                Devaluate();
            }
            else
            {
                IncreaseQuality();

                if (IsDueWithin(new Days(10)))
                {
                    IncreaseQuality();
                }

                if (IsDueWithin(new Days(5)))
                {
                    IncreaseQuality();
                }
            }
        }
    }
}