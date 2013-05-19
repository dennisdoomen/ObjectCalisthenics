using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class Inventory : IEnumerable<Item>
    {
        private readonly HashSet<Item> items = new HashSet<Item>();

        public Item HighestValued
        {
            get { return items.OrderBy(i => i.Quality).Last(); }
        }

        public IEnumerable<Item> Overdue
        {
            get { return items.Where(i => i.SellInDays.IsOverdue).ToArray(); }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void HandleDayChanges(int nrOfDays)
        {
            for (int i = 0; i < nrOfDays; i++)
            {
                foreach (var item in items)
                {
                    item.HandleDayChange();
                }
            }
        }
    }
}