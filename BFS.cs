class BFS
{
    static void Main()
    {
        Graph graph = new Graph();
        
        List one = new List();
        one.Add(3);
        one.Add(5);
        
        graph.Add(one);
        
        one = new List();
        one.Add(5);
        one.Add(6);
        one.Add(1);
        one.Add(3);
        
        graph.Add(one);
        
        one = new List();
        one.Add(6);
        one.Add(7);
        one.Add(5);
        
        graph.Add(one);
        
        one = new List();
        one.Add(7);
        one.Add(6);
        one.Add(1);
        
        graph.Add(one);
        
        one = new List();
        one.Add(1);
        one.Add(7);
        one.Add(5);
        
        graph.Add(one);
        
        graph.PrintGraph();
        
        BFSearch(graph, 15);
    }
    
    public static void BFSearch(Graph graph, int search)
    {
        AdjacencyListNode graphTracker = new AdjacencyListNode();
        graphTracker = graph.start;
                
        while(graphTracker != null)
        {
            Node listTracker = new Node();
            listTracker = graphTracker.list.head;
            
            while(listTracker != null)
            {
                if(listTracker.value != search)
                {
                    listTracker = listTracker.next;
                }
                else
                {
                    Console.WriteLine("Found");
                    return;
                }
            }
            
            graphTracker = graphTracker.next;
        }
        
        Console.WriteLine("Not Found");
        return;
    }
    
    public class Node
    {
        public Node next;
        public int value;
    }
    
    public class List
    {
        public Node head;
        
        public void Add(int value)
        {
            if(head == null)
            {
                Node newNode = new Node();
                newNode.value = value;
                this.head = newNode;
            }
            else
            {
                Node tracker = new Node();
                tracker = this.head;

                while(tracker.next != null)
                {
                    tracker = tracker.next;
                }

                Node newNode = new Node();
                newNode.value = value;
                tracker.next = newNode;
            }
        }
    }
    
    public class AdjacencyListNode
    {
        public List list;
        public AdjacencyListNode next;
    }
    
    public class Graph
    {
        public AdjacencyListNode start;
        public AdjacencyListNode end;
        
        public void Add(List list)
        {
            AdjacencyListNode temp = new AdjacencyListNode();
            temp.list = list;            
            
            if(this.start == null)
            {
                this.start = temp;
                this.end = temp;
            }
            else
            {
                this.end.next = temp;
                this.end = temp;   
            }
        }
        
        public void PrintGraph()
        {
            AdjacencyListNode tracker = new AdjacencyListNode();
            tracker = this.start;
            
            while(tracker != null)
            {
                Node listTracker = new Node();
                listTracker = tracker.list.head;
                
                while(listTracker != null)
                {
                    Console.Write(listTracker.value + " ");
                    listTracker = listTracker.next;
                }
                
                tracker = tracker.next;
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
    
    public class Queue
    {
        Node head;
        Node tail;
        
        public Queue(Node node)
        {
            this.head = node;
            this.tail = node;
        }
        
        public void Push(Node node)
        {
            node.next = this.tail;
            this.tail = node;
        }
        
        public Node Pop()
        {
            if(this.head != null)
            {
                Node popNode = this.head;
                this.head = this.head.next;
                return popNode;   
            }
            else
                return null;
        }
        
        public int Peek()
        {
            //if(this.head != null)
            //{
                return this.head.value;
            //}
            //else
                //return null;
        }
        
        public bool IsEmpty()
        {
            return this.head == null;
        }
    }
}
