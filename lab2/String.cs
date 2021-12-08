using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class String : IComparable<String>, ISearchable, IAddable
    {
        private string str;
        private int stringLength;
        public string GetStringValue()
        {
            return str;
        }

        public String()
        {
            str = string.Empty;
            stringLength = str.Length;
        }
        public String(string value)
        {
            str = value;
            stringLength = str.Length;
        }
        public String(String str)
        {
            this.str = str.str;
            stringLength = str.stringLength;
        }

        public List<int> SearchForSpecificCharacterIndex(string str, char character)
        {
            List<int> index = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == character)
                {
                    index.Add(i);
                }
            }
            return index;
        }
        public void AddString(string addableString)
        {
            str += addableString;
        }

        public int CompareTo(String other)
        {
            return str.CompareTo(other.str);
        }
    }
}
