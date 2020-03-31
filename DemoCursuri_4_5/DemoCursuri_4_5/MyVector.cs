using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class MyVector
    {
        private int[] v;

        public MyVector(int length)
        {
            v = new int[length];
        }

        public int this[int index]
        {
            get { return v[index]; }
            set { v[index] = value; }
        }

        public int Length
        {
            get
            {
                return v.Length;
            }
        }

        public static MyVector operator+(MyVector a, MyVector b)
        {
            if (a == null || b == null || a.Length != b.Length)
            {
                throw new Exception("Incompatible sizes");
            }
            MyVector result = new MyVector(a.Length);

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = a[i] + b[i];
            }

            return result;
        }
    }
}
