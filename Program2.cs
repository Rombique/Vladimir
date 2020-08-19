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

        static Node InsertPos(Node headNode,
                            int position, int data)
        {
            var head = headNode;
            if (position < 1)
                Console.WriteLine("Неправильно указана позиция");

            if (position == 1)
            {
                var newNode = new Node(data)
                {
                    NextNode = headNode
                };
                head = newNode;
            }
            else
            {
                while (position-- != 0)
                {
                    if (position == 1)
                    {
                        Node newNode = NewNode(data);

                        newNode.NextNode = headNode.NextNode;

                        headNode.NextNode = newNode;
                        break;
                    }
                    headNode = headNode.NextNode;
                }
                if (position != 1)
                    Console.WriteLine("Неправильно указана позиция");
            }
            return head;
        }

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
            head.NextNode.NextNode.NextNode.NextNode = NewNode(8);
            head.NextNode.NextNode.NextNode.NextNode.NextNode = NewNode(10);
            head.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = NewNode(8);

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
            Console.WriteLine($"MaxData: {maxData} MaxCount: {maxCount}");
            Console.ReadKey();
        }
    }
}
