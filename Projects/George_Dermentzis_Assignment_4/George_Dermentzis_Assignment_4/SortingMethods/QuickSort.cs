using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_4.SortingMethods
{
    class QuickSort
    {
        public static List<TShirt> SortShirts(List<TShirt> shirts, string s)
        {
            switch (s)
            {
                case "color":
                    return QuickSortByColorAsc(shirts, 0, shirts.Count() - 1);
                case "size":
                    return QuickSortBySizeAsc(shirts, 0, shirts.Count() - 1);
                default:
                    return QuickSortByFabricAsc(shirts, 0, shirts.Count() - 1);
            }
        }

        private static List<TShirt> QuickSortByColorAsc(List<TShirt> shirts, int left, int right)
        {
            int i = left;
            int j = right;
            var pivot = shirts[(left + right) / 2].Color;
            while (i <= j)
            {
                while (shirts[i].Color < pivot)
                    i++;
                while (shirts[j].Color > pivot)
                    j--;
                if (i <= j)
                {
                    var temp = shirts[i];
                    shirts[i] = shirts[j];
                    shirts[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                QuickSortByColorAsc(shirts, left, j);
            if (i < right)
                QuickSortByColorAsc(shirts, i, right);

            return shirts;
        }

        private static List<TShirt> QuickSortBySizeAsc(List<TShirt> shirts, int left, int right)
        {
            int i = left;
            int j = right;
            var pivot = shirts[(left + right) / 2].Size;
            while (i <= j)
            {
                while (shirts[i].Size < pivot)
                    i++;
                while (shirts[j].Size > pivot)
                    j--;
                if (i <= j)
                {
                    var temp = shirts[i];
                    shirts[i] = shirts[j];
                    shirts[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                QuickSortBySizeAsc(shirts, left, j);
            if (i < right)
                QuickSortBySizeAsc(shirts, i, right);

            return shirts;
        }

        private static List<TShirt> QuickSortByFabricAsc(List<TShirt> shirts, int left, int right)
        {
            int i = left;
            int j = right;
            var pivot = shirts[(left + right) / 2].Fabric;
            while (i <= j)
            {
                while (shirts[i].Fabric < pivot)
                    i++;
                while (shirts[j].Fabric > pivot)
                    j--;
                if (i <= j)
                {
                    var temp = shirts[i];
                    shirts[i] = shirts[j];
                    shirts[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                QuickSortByFabricAsc(shirts, left, j);
            if (i < right)
                QuickSortByFabricAsc(shirts, i, right);

            return shirts;
        }
    }
}
