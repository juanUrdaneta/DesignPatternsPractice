using System;
using System.Collections.Generic;
using System.Text;

namespace DIContainerDemo
{
    public class ClassB : IB
    {

        private IA _classA;

        public ClassB(IA classA)
        {
            _classA = classA;
        }
        public void doB()
        {
            _classA.doA();
            Console.WriteLine("Doing B");
        }
    }
}
