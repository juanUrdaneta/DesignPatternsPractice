using System;

namespace DIContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new DiContainer();
            container.Register<IA, ClassA>();
            container.Register<IB, ClassB>();
            IB classB = container.Resolve<IB>();
            classB.doB();
            Console.ReadKey();
        }
    }
}
