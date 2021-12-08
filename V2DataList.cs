using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace Lab_3
{
    // V2DataList
    class V2DataList : V2Data
    {
        // List of measurements
        public List<DataItem> Contents { get; }

        // Constructor
        public V2DataList(string instr, DateTime intime) : base(instr, intime)
        {
            Contents = new();
        }

        // Properties
        public override int Count
        {
            get
            {
                return Contents.Count;
            }
        }

        public override float MinDistance
        {
            get
            {
                if (Contents.Count < 2)
                {
                    return -1;
                }
                float minDist = Vector2.Distance(Contents[0].Coords, Contents[1].Coords);
                foreach (DataItem item_1 in Contents)
                {
                    foreach (DataItem item_2 in Contents)
                    {
                        float cDist = Vector2.Distance(item_1.Coords, item_2.Coords);
                        if (minDist > cDist && cDist != 0)
                        {
                            minDist = cDist;
                        }
                    }
                }
                return minDist;
            }
        }

        // Methods
        public bool Add(DataItem NewItem)
        {
            foreach (DataItem item in Contents)
            {
                if (item.Coords == NewItem.Coords)
                {
                    return false;
                }
            }
            Contents.Add(NewItem);
            return true;
        }

        public int AddDefaults(int nItems, Fv2Complex F)
        {
            int ReallyAdded = 0;
            for (int i = 0; i < nItems; i++)
            {
                DataItem dataItem = new() { };
                dataItem.Coords = new(i, i);
                dataItem.Value = F(dataItem.Coords);
                bool res = Add(dataItem);
                if (res == true)
                {
                    ReallyAdded++;
                }
            }
            return ReallyAdded;
        }

        // File operations
        public bool SaveAsText(string filename)
        {
            try
            {
                StreamWriter writer = new(filename, false);
                try
                {
                    writer.WriteLine(Contents.Count);
                    foreach (DataItem item in Contents)
                    {
                        writer.WriteLine(item.Coords.X);
                        writer.WriteLine(item.Coords.Y);
                        writer.WriteLine(item.Value.Real);
                        writer.WriteLine(item.Value.Imaginary);
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("Error have occurred: {0}", e.Message);
                    return false;
                }
                finally
                {
                    writer.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error have occurred: {0}", e.Message);
                return false;
            }
            return true;
        }

        public bool LoadAsText(string filename, ref V2DataList v2)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                try
                {
                    Contents.Clear();
                    int count = Int32.Parse(reader.ReadLine());
                    for(int i = 0; i < count; i++)
                    {
                        DataItem dataItem = new() { };
                        float CoordX = float.Parse(reader.ReadLine());
                        float CoordY = float.Parse(reader.ReadLine());
                        dataItem.Coords = new(CoordX, CoordY);
                        double ValueRe = Double.Parse(reader.ReadLine());
                        double ValueIm = Double.Parse(reader.ReadLine());
                        dataItem.Value = new(ValueRe, ValueIm);
                        Contents.Add(dataItem);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error have occurred: {0}", e.Message);
                    return false;
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error have occurred: {0}", e.Message);
                return false;
            }
            return true;
        }

        // IEnumerable
        override public IEnumerator<DataItem> GetEnumerator()
        {
            return Contents.GetEnumerator();
        }

        // Output
        override public string ToLongString(string format)
        {
            string output = string.Format($"Type: V2DataList, Characteristics: {Str},  Date/Time: {DateAndTime}, ItemCount: {Contents.Count}\n");
            foreach (DataItem item in Contents)
            {
                output += string.Format($"DataItem Contents: " + item.ToLongString(format));
            }
            return output;
        }

        override public string ToString()
        {
            return string.Format($"Type: V2DataList, Characteristics: {Str},  Date/Time: {DateAndTime}, ItemCount: {Contents.Count}\n");
        }
    }
}
