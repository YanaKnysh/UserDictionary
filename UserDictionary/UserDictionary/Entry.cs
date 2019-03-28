using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDictionary
{
    public class Entry
    {
        public string Key { get; set; }
        public int Value { get; set; }

        public Entry(string key, int value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Key + " " + Value;
        }
    }
}
