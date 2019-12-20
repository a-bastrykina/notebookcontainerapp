using System;

namespace Notebook
{
    public class MyList<T>
    {
        public MyListNode<T> Head { get; private set; }
        public MyListNode<T> Tail { get; private set;  }
        public uint Size { get; private set; }

        public MyList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }
        
        public void Add(T element)
        {
            if (Size == 0)
            {
                Head = Tail = new MyListNode<T>(element);
            }
            else
            {
                var node = new MyListNode<T>(element) { PrevNode = Tail };
                Tail.NextNode = node;
                Tail = node;
            }
            Size++;
        }

        public int Find(T element)
        {
            var iterationNode = Head;
            
            for (int i = 0; i < Size; i++)
            {
                if (iterationNode.Data.Equals(element)) return i;
                iterationNode.PrevNode = iterationNode;
                iterationNode = iterationNode.NextNode;
            }

            throw new ArgumentOutOfRangeException();
        }

        public void Remove(T element)
        {
            try
            {
                RemoveAtIndex(Find(element));
            }
            catch (ArgumentOutOfRangeException e)
            {
                //No expected action here
            }
        }

        public void RemoveAtIndex(int index)
        {
            if (index >= Size  || index < 0 || Size == 0) return;
            if (index == 0)
            {
                if (Size == 1)
                {
                    Size = 0;
                    Head = Tail = null;
                    return;
                }
                Head = Head.NextNode;
                Size--;
                return;
            }

            if (index == Size - 1)
            {
                Tail = Tail.PrevNode;
                Size--;
                return;
            }
            var iterationNode = Head;
            for (int i = 0; i < index; i++)
            {
                iterationNode.PrevNode = iterationNode;
                iterationNode = iterationNode.NextNode;
            }
           
            iterationNode.PrevNode.NextNode = iterationNode.NextNode;
            iterationNode.PrevNode = iterationNode;
            iterationNode = iterationNode.NextNode;
            Size--;
        }

        public uint GetSize()
        {
            return Size;
        }
    }
}