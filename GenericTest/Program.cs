using System;
using System.Drawing;

namespace GenericTest
{

    public class GenericArrayExample<T>
    {
        public GenericArrayExample(int size)
        {
            Array = new T[size];
        }
        public GenericArrayExample(T[] arr)
        {
            Array = new T[arr.Length];
            Array = arr;
        }
        public int Lenght { get { return Array.Length; } }
        public ref T GetElement(int index)
        {
            if(Array == null) throw new NullReferenceException("Array is null");
            if (index >= Array.Length) throw new ArgumentOutOfRangeException("Array out of range");
            return ref Array[index];
        }

        public void ForEachElement(Action<T> op)
        {
            foreach (T element in Array) { op(element); }
        }

        private T [] Array;
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            GenericArrayExample<int> IntArray = new GenericArrayExample<int>(new int[]{1,2,3,4});

            string[] str = { "Hello", "World", "!" };
            GenericArrayExample<string> stringArray = new GenericArrayExample<string>(str);
            stringArray.ForEachElement((string str) => Console.Write(str));
            Console.Write('\n');
            int sum = 0;
            IntArray.ForEachElement((int i) => sum += i);
            Console.WriteLine(sum);
            Console.WriteLine("Size array 1: {0}, Size array 2: {1}. WTF is this", IntArray.Lenght, stringArray.Lenght);
        }
    }
}