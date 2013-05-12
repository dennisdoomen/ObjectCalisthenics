using System;

public class Item
{
    private String name;

    public Item(string name, int sellIn, int quality)
    {
        this.name = name;
        this.Quality = quality;
        this.SellIn = sellIn;
    }

    public int SellIn { get; set; }

    public int Quality { get; set; }

    public string Name
    {
        get { return name; }
    }
}