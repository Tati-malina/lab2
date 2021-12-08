using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    interface ISearchable
    {
        public List<int> SearchForSpecificCharacterIndex(string str, char character);
    }
}
