using System;
using System.Collections.Generic;

namespace GildedRose.Specs
{
    internal static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action action)
        {
            foreach (var value in source)
            {
                action();
            }
        }
    }
}