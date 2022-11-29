using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.Functions
{
    public class JsonManagement
    {
        public static void JsonCon(int count)
        {
            string Path = $@"D:\VisualStudioProject\Store\Store\Cart\cart.json";
          
            if (count == 2)
            {
                var linesList = System.IO.File.ReadAllLines(Path).ToList();
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, ",{");
                   System.IO.File.WriteAllLines(Path, linesList.ToArray());
                }
            }
            else
            {
                var linesList = System.IO.File.ReadAllLines(Path).ToList();
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, "{");
                   System.IO.File.WriteAllLines(Path, linesList.ToArray());
                }
            }
           
        }
    }
}