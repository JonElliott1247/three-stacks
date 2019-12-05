using System;

namespace ThreeStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 11;
            ThreeStacks stack = new ThreeStacks(arraySize);
            stack.Push(45, WhichStack.One);
            stack.Push(46, WhichStack.One);
            stack.Push(47, WhichStack.One);

            Console.WriteLine("Expected: 47, 46, 45   Actual: "
                + stack.Pop(WhichStack.One) + "," + stack.Pop(WhichStack.One) + "," + stack.Pop(WhichStack.One));

            Console.ReadKey();
        }
    }
}
