using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Individual_Project_Part_A.Interfaces;

namespace Individual_Project_Part_A.Validations
{
    class ModelComparer : IEqualityComparer<IModel>
    {
        public bool Equals(IModel x, IModel y)
        {
            var propertiesX = x.GetType().GetRuntimeProperties().OrderByDescending(p => p.Name == "Id").ToArray();
            var propertiesY = y.GetType().GetRuntimeProperties().OrderByDescending(p => p.Name == "Id").ToArray();
            var flag = true;
            for (int i = 1; i < propertiesX.Length; i++)
            {
                if (!propertiesX[i].GetValue(x).Equals(propertiesY[i].GetValue(y)))
                {
                    flag = false;
                    break;
                }                  
            }

            return flag;
        }

        public int GetHashCode(IModel obj) => obj.GetHashCode();
    }
}