using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Models
{
    public class Leaderboard : IComparer<Leaderboard.Item>
    {
        private const string StorageKey = "Leaderboard";
        private const int MaxCount = 9;

        List<Item>  Items = new List<Item>();

        public Leaderboard()
        {
           
        }

       
        public int Compare(Item x, Item y)
        {
            return x.CompareTo(y);
        }

        public void Add(Item leaderboardItem)
        {
            // Add new item to the original list
            var originalList = Items.ToList();
            originalList.Add(leaderboardItem);

            // Order items and update leaderboard
            var orderedList = originalList.OrderByDescending(x => x, this).Take(MaxCount).ToList();

            // Update leaderboard
            if (orderedList != null)
                UpdateLeaderboard(orderedList);
        }

        public void Save()
        {
            
        }

        public void Load()
        {
           
        }

        private void UpdateLeaderboard(IList<Item> items)
        {
           
        }

        private void Close()
        {
           
        }

        [Serializable]
        public class Item : IComparable<Item>
        {
            public int Points;
            public string Date;

            public int CompareTo(Item other)
            {
                var comparePoints = Points.CompareTo(other.Points);

                if (comparePoints == 0)
                    return Date.CompareTo(other.Date);

                return comparePoints;
            }
        }

        [Serializable]
        public class Data
        {
            public List<Item> Items;
        }
    }
}
