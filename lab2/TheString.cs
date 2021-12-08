using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{

    class TheString : IComparable<TheString>, ISearchable, IAddable
    {
        private string str;
        private int stringLength;
        public string GetStringValue()
        {
            return str;
        }

        public TheString()
        {
            str = string.Empty;
            stringLength = str.Length;
        }
        public TheString(string value)
        {
            str = value;
            stringLength = str.Length;
        }
        public TheString(TheString str)
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

        public int CompareTo(TheString other)
        {
            return str.CompareTo(other.str);
        }
        public int CompareTo(object obj)
        {
            if (obj is string objString)
            {
                return str.CompareTo(objString);
            }
            else if (obj is TheString _string)
            {
                return CompareTo(_string);
            }
            throw new NotImplementedException();
        }
    }
}
