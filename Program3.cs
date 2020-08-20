using System;

namespace ConsoleApp1
{
    class Program
    {
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }

            public Node(int data) => Data = data;
        }

        static Node NewNode(int data) => new Node(data);

        static void PrintList(Node node)
        {
            while (node.NextNode != null)
            {
                Console.Write(node.Data);
                node = node.NextNode;
                Console.Write(",");
            }
            Console.Write(node.Data);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var head = NewNode(3);
            head.NextNode = NewNode(5);
            head.NextNode.NextNode = NewNode(8);
            head.NextNode.NextNode.NextNode = NewNode(8);
            head.NextNode.NextNode.NextNode.NextNode = NewNode(2);
            head.NextNode.NextNode.NextNode.NextNode.NextNode = NewNode(1);
            head.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = NewNode(7);
            head.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = NewNode(7);
            head.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = NewNode(7);
            head.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = NewNode(7);

            PrintList(head);
            int index = 1;
            int maxCount = 1;
            int maxData = 0;
            var node = head;
            while (node.NextNode != null)
            {
                if (node.Data == node.NextNode.Data)
                {
                    index++;
                    if (maxCount < index)
                    {
                        maxCount = index;
                        maxData = node.Data;
                    };
                }
                else
                    index = 1;
                node = node.NextNode;
            }
            if (maxCount > 1)
                Console.WriteLine($"MaxData: {maxData} MaxCount: {maxCount}");
            Console.ReadKey();
        }
    }
}
