using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Transversal.common.Utilities
{
   public static class ProcessDataFile
    {
    
   
        public static string WorkDayProcessing(List<string> file, int id)
        {
            List<int> initialList = new List<int>();
            initialList = file.Select(s => Convert.ToInt32(s)).ToList();
            StringBuilder objectForDaySb = new StringBuilder();
            int day = 1;
            for (int i=1; i< initialList.Count; i++ )
            {
                int objectquantity = initialList[i];
                List<int> elementList = initialList.Skip(i+1).Take(objectquantity).ToList();
                int tripForDay = CalculateTrips(elementList);
                objectForDaySb.Append("Case #" + day + ":"+ tripForDay + "\n");
                i = i + objectquantity;
                day++;
            };

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(objectForDaySb.ToString());
            return Convert.ToBase64String(plainTextBytes);
        }

        private static int CalculateTrips(List<int> elementList)
        {
            int apparentWeight = 1;
            int weigth = 0;
            int trips = 0;

            foreach (int element in elementList.ToList())
            {
                if (elementList.Count > 0) {
                    
                    int minWeight = elementList.OrderBy(w => w <= 50).Min();
                    int maxWeight = elementList.OrderBy(w => w <= 50).Max();
                    var maxRemove = elementList.Remove(maxWeight);
                    var minRemove = elementList.Remove(minWeight);
                    apparentWeight ++;
               
                    weigth = maxWeight * apparentWeight;

                    if (weigth >= 50 || element >= 50) 
                        trips++;
                }
            }
            return trips;
        }
    }
}
