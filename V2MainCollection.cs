using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_3
{
    // V2MainCollection
    class V2MainCollection
    {
        // List of lists and Arrays
        private System.Collections.Generic.List<V2Data> Collection;

        // Constructor
        public V2MainCollection()
        {
            Collection = new();
        }

        // Properties
        public int Count
        {
            get
            {
                return Collection.Count;
            }
        }

        public float MaxDistance
        {
            get
            {
                if (Collection.Count == 0)
                {
                    return float.NaN;
                }
                var Items = from item1 in Collection
                            from item2 in item1
                            select item2.Coords;
                Items = Items.Distinct();
                var Distances = from item1 in Items
                                from item2 in Items
                                select Vector2.Distance(item1, item2);
                if (Distances.Any())
                {
                    return Distances.Max();
                }
                else
                {
                    return float.NaN;
                }
            }
        }

        public IEnumerable<Vector2> UniquePoints
        {
            get
            {
                if (Collection.Count == 0)
                {
                    return null;
                }
                var res = from item1 in Collection
                          from item2 in item1
                          select item2.Coords;
                res = from coords in res
                      group coords by coords into cGroup
                      where cGroup.Count() == 1
                      select cGroup.Key;
                if (res.Any())
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<V2DataList> V2DataListImNoneZ
        {
            get
            {
                if (Collection.Count == 0)
                {
                    return null;
                }
                var Iteams = from item in Collection
                             select item;
                var Lists = Iteams.OfType<V2DataList>();
                var res = from item in Lists
                          where item.Contents.All(x => x.Value.Imaginary != 0)
                          select item;
                if (res.Any())
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
        }

        // Indexer
        public V2Data this[int index]
        {
            get
            {
                return Collection[index];
            }
        }

        // Methods
        public bool Contains(string ID)
        {
            foreach (V2Data item in Collection)
            {
                if (item.Str == ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Add(V2Data NewItem)
        {
            foreach (V2Data item in Collection)
            {
                if (item.Str == NewItem.Str)
                {
                    return false;
                }
            }
            Collection.Add(NewItem);
            return true;
        }

        // Output
        public string ToLongString(string format)
        {
            string output = string.Format("Type: V2MainCollection\n");
            foreach (V2Data item in Collection)
            {
                output += item.ToLongString(format);
            }
            return output;
        }

        override public string ToString()
        {
            string output = string.Format("Type: V2MainCollection\n");
            foreach (V2Data item in Collection)
            {
                output += item.ToString();
            }
            return output;
        }
    }
}
