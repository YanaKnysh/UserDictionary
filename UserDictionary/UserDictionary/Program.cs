using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDictionary userDict = new UserDictionary();
            userDict.Add("one", 1);
            userDict.Add(new Entry("two", 2));
            userDict.Add(new Entry("three", 3));
            userDict.Add("four", 4);

            var a = userDict.ContainsKey("four");
            var b = userDict.ContainsValue(4);
            var c = userDict.TryGetValue("one", out int value);
            userDict.Remove("three");
            userDict.Remove("two");

            foreach (var item in userDict)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
