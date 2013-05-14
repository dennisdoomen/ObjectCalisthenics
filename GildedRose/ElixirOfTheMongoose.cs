using System;

namespace GildedRose
{
    public class ElixirOfTheMongoose : Item
    {
        public ElixirOfTheMongoose(int sellIn, int quality)
            : base("Elixir of the Mongoose", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Quality > 0)
                {
                    if (Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Quality = Quality - 1;
                    }
                }
            }
            else
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }

            if (!Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                SellIn = SellIn - 1;
            }

            if (SellIn < 0)
            {
                if (Name != "Aged Brie")
                {
                    if (Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Quality > 0)
                        {
                            if (Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Quality = Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Quality = Quality - Quality;
                    }
                }
                else
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }
            }

        }
    }
}