using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    // V2Data - abstract
    abstract class V2Data : IEnumerable<DataItem>
    {
        // LogData
        public string Str { get; protected set; }
        public DateTime DateAndTime { get; protected set; }

        // Constructor
        public V2Data(string instr, DateTime intime)
        {
            Str = instr;
            DateAndTime = intime;
        }

        // Properties
        abstract public int Count
        {
            get;
        }

        abstract public float MinDistance
        {
            get;
        }

        // IEnumerable
        abstract public IEnumerator<DataItem> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }

        // Output
        abstract public string ToLongString(string format);

        abstract override public string ToString();
    }
}