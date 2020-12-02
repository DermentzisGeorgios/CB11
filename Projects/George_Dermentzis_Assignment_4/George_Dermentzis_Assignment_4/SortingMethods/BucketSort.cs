using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_4.SortingMethods
{
    class BucketSort
    {
        public static List<TShirt> SortShirtsByColorAsc(List<TShirt> shirts)
        {
            List<TShirt> sortedList = new List<TShirt>();
            int numOfBuckets = 4;
            List<TShirt>[] buckets = new List<TShirt>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<TShirt>();
            }

            for (int i = 0; i < shirts.Count(); i++)
            {
                int bucket = (int)shirts[i].Color;
                if (bucket == 0 || bucket == 1)
                    bucket = 0;
                else if (bucket == 2 || bucket == 3)
                    bucket = 1;
                else if (bucket == 4 || bucket == 5)
                    bucket = 2;
                else
                    bucket = 3;

                buckets[bucket].Add(shirts[i]);
            }

            for (int i = 0; i < numOfBuckets; i++)
            {
                List<TShirt> temp = InsertionSortBucketByColor(buckets[i]);
                sortedList.AddRange(temp);
            }

            return sortedList;
        }

        private static List<TShirt> InsertionSortBucketByColor(List<TShirt> shirts)
        {
            TShirt temp;
            for (int i = 1; i < shirts.Count(); i++)
            {
                int currentValue = (int)shirts[i].Color;
                int pointer = i - 1;

                while (pointer >= 0)
                {
                    if (currentValue < (int)shirts[pointer].Color)
                    {
                        temp = shirts[pointer + 1];
                        shirts[pointer + 1] = shirts[pointer];
                        shirts[pointer] = temp;
                        pointer--;
                    }
                    else
                        break;
                }
            }

            return shirts;
        }

        public static List<TShirt> SortShirtsBySizeAsc(List<TShirt> shirts)
        {
            List<TShirt> sortedList = new List<TShirt>();
            int numOfBuckets = 4;
            List<TShirt>[] buckets = new List<TShirt>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<TShirt>();
            }

            for (int i = 0; i < shirts.Count(); i++)
            {
                int bucket = (int)shirts[i].Size;
                if (bucket == 0 || bucket == 1)
                    bucket = 0;
                else if (bucket == 2 || bucket == 3)
                    bucket = 1;
                else if (bucket == 4 || bucket == 5)
                    bucket = 2;
                else
                    bucket = 3;

                buckets[bucket].Add(shirts[i]);
            }

            for (int i = 0; i < numOfBuckets; i++)
            {
                List<TShirt> temp = InsertionSortBucketBySize(buckets[i]);
                sortedList.AddRange(temp);
            }

            return sortedList;
        }

        private static List<TShirt> InsertionSortBucketBySize(List<TShirt> shirts)
        {
            TShirt temp;
            for (int i = 1; i < shirts.Count(); i++)
            {
                int currentValue = (int)shirts[i].Size;
                int pointer = i - 1;

                while (pointer >= 0)
                {
                    if (currentValue < (int)shirts[pointer].Size)
                    {
                        temp = shirts[pointer + 1];
                        shirts[pointer + 1] = shirts[pointer];
                        shirts[pointer] = temp;
                        pointer--;
                    }
                    else
                        break;
                }
            }

            return shirts;
        }

        public static List<TShirt> SortShirtsByFabricAsc(List<TShirt> shirts)
        {
            List<TShirt> sortedList = new List<TShirt>();
            int numOfBuckets = 4;
            List<TShirt>[] buckets = new List<TShirt>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<TShirt>();
            }

            for (int i = 0; i < shirts.Count(); i++)
            {
                int bucket = (int)shirts[i].Fabric;
                if (bucket == 0 || bucket == 1)
                    bucket = 0;
                else if (bucket == 2 || bucket == 3)
                    bucket = 1;
                else if (bucket == 4 || bucket == 5)
                    bucket = 2;
                else
                    bucket = 3;

                buckets[bucket].Add(shirts[i]);
            }

            for (int i = 0; i < numOfBuckets; i++)
            {
                List<TShirt> temp = InsertionSortBucketByFabric(buckets[i]);
                sortedList.AddRange(temp);
            }

            return sortedList;
        }

        private static List<TShirt> InsertionSortBucketByFabric(List<TShirt> shirts)
        {
            TShirt temp;
            for (int i = 1; i < shirts.Count(); i++)
            {
                int currentValue = (int)shirts[i].Fabric;
                int pointer = i - 1;

                while (pointer >= 0)
                {
                    if (currentValue < (int)shirts[pointer].Fabric)
                    {
                        temp = shirts[pointer + 1];
                        shirts[pointer + 1] = shirts[pointer];
                        shirts[pointer] = temp;
                        pointer--;
                    }
                    else
                        break;
                }
            }

            return shirts;
        }
    }
}
