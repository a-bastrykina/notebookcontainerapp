namespace Notebook
{
    public class MyListNode<T>
    {
        public T Data { get; }
        public MyListNode<T> NextNode { get; set; }
        public MyListNode<T> PrevNode { get; set; }

        public MyListNode(T data)
        {
            Data = data;
            NextNode = null;
            PrevNode = null;
        }
        
    }
}