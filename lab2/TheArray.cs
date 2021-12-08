using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public static class TheArray
    {
        public static void Add<T>(ref T[] array, T item)
        {
            T[] newArray = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++) { newArray[i] = array[i]; }
            newArray[newArray.Length - 1] = item;
            array = newArray;
        }

        public static bool Remove<T>(ref T[] array, T item)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item)) { index = i; }
            }
  
            if (index < 0) { return false; }

            int currentPosition = 0;
            T[] newArray = new T[array.Length - 1];

            for (int i = 0; i < index; i++, currentPosition++)
            {
                newArray[i] = array[i];
            }

            for (int i = index + 1; i < array.Length; i++, currentPosition++)
            {
                newArray[currentPosition] = array[i];
            }
            array = newArray;
            return true;
        }
    }
}
