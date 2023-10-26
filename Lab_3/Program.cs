using System.Collections.Generic;

namespace Lab_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> linkedList = new();

            linkedList.AddTail(1);
            linkedList.AddTail(1);
            linkedList.AddTail(1);
            linkedList.AddTail(3);
            linkedList.InsertBefore(4, 2);
        }
    }
}