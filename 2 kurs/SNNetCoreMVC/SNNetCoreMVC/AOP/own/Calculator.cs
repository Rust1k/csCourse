using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNNetCoreMVC
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }   
}
