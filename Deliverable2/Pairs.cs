using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable2
{
    class Pairs
    {
        private string key;
        private int value;

        public Pairs(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
        
        public string Key { get { return key; } }
        public int Value { get { return value; } }
    }
}
