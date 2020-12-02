using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_4.SortingMethods
{
    class BubbleSort
    {
        private static bool less(int value1, int value2) => value1 < value2;
        private static bool more(int value1, int value2) => value1 > value2;

        public static List<TShirt> SortShirtsByColorAsc(List<TShirt> shirts)
        {
            int size = shirts.Count();
            bool isSorted = false;
            int lastUnsorted = size - 1;
            TShirt temp;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < lastUnsorted; i++)
                {
                    if (more((int)shirts[i].Color, (int)shirts[i + 1].Color))
                    {
                        temp = shirts[i];
                        shirts[i] = shirts[i + 1];
                        shirts[i + 1] = temp;
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }

            return shirts;
        }

        public static List<TShirt> SortShirtsBySizeAsc(List<TShirt> shirts)
        {
            int size = shirts.Count();
            bool isSorted = false;
            int lastUnsorted = size - 1;
            TShirt temp;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < lastUnsorted; i++)
                {
                    if (more((int)shirts[i].Size, (int)shirts[i + 1].Size))
                    {
                        temp = shirts[i];
                        shirts[i] = shirts[i + 1];
                        shirts[i + 1] = temp;
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }

            return shirts;
        }

        public static List<TShirt> SortShirtsByFabricrAsc(List<TShirt> shirts)
        {
            int size = shirts.Count();
            bool isSorted = false;
            int lastUnsorted = size - 1;
            TShirt temp;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < lastUnsorted; i++)
                {
                    if (more((int)shirts[i].Fabric, (int)shirts[i + 1].Fabric))
                    {
                        temp = shirts[i];
                        shirts[i] = shirts[i + 1];
                        shirts[i + 1] = temp;
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }

            return shirts;
        }
    }
}
