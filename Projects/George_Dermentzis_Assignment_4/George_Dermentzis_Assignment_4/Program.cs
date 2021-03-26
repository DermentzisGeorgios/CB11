using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using George_Dermentzis_Assignment_4.SortingMethods;

namespace George_Dermentzis_Assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();
            var newList = new List<TShirt>(db.TShirts);
            
            //All BubbleSort 
            //AllBubbleSort(newList);

            //All QuickSort
            //AllQuickSort(newList);

            //All BucketSort
            //AllBucketSort(newList);


            //The Reverse method takes about the same time as the sorting algorithm to sort the list. The difference is 1-6 ms in average so it is suitable to reverse sort a list of 40 elements.

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            var sortedList = BubbleSort.SortShirtsByColorAsc(newList);
            ShowList(sortedList);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            Console.WriteLine("Color in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        static void ShowList(List<TShirt> newList)
        {
            foreach (var shirt in newList)
            {
                shirt.Print();
            }
            Console.WriteLine("-------------------------------------------------");
        }

        static void AllBubbleSort(List<TShirt> newList)
        {
            //Color Asc
            Console.WriteLine("Color in Ascending\n");
            var sortedList = BubbleSort.SortShirtsByColorAsc(newList);
            ShowList(sortedList);
            //Color Desc
            Console.WriteLine("Color in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
            //Size Asc
            Console.WriteLine("Size in Ascending\n");
            sortedList = BubbleSort.SortShirtsBySizeAsc(newList);
            ShowList(sortedList);
            //Size Desc
            Console.WriteLine("Size in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
            //Fabric Asc
            Console.WriteLine("Fabric in Ascending\n");
            sortedList = BubbleSort.SortShirtsByFabricrAsc(newList);
            ShowList(sortedList);
            //Fabric Desc
            Console.WriteLine("Fabric in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
        }

        static void AllQuickSort(List<TShirt> newList)
        {
            //Color Asc
            Console.WriteLine("Color in Ascending\n");
            var sortedList = QuickSort.SortShirts(newList, "color");
            ShowList(sortedList);
            //Color Desc
            Console.WriteLine("Color in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
            //Size Asc
            Console.WriteLine("Size in Ascending\n");
            sortedList = QuickSort.SortShirts(newList, "size");
            ShowList(sortedList);
            //Size Desc
            Console.WriteLine("Size in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
            //Fabric Asc
            Console.WriteLine("Fabric in Ascending\n");
            sortedList = QuickSort.SortShirts(newList, "fabric");
            ShowList(sortedList);
            //Fabric Desc
            Console.WriteLine("Fabric in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
        }

        static void AllBucketSort(List<TShirt> newList)
        {
            //Color Asc
            Console.WriteLine("Color in Ascending\n");
            var sortedList = BucketSort.SortShirtsByColorAsc(newList);
            ShowList(sortedList);
            //Color Desc
            Console.WriteLine("Color in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
            //Size Asc
            Console.WriteLine("Size in Ascending\n");
            sortedList = BucketSort.SortShirtsBySizeAsc(newList);
            ShowList(sortedList);
            //Size Desc
            Console.WriteLine("Size in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
            //Fabric Asc
            Console.WriteLine("Fabric in Ascending\n");
            sortedList = BucketSort.SortShirtsByFabricAsc(newList);
            ShowList(sortedList);
            //Fabric Desc
            Console.WriteLine("Fabric in Descending\n");
            sortedList.Reverse();
            ShowList(sortedList);
        }
    }
}
