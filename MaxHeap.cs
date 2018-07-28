class Heap
{
    static void Main()
    {
        Console.WriteLine("Hello");
        
        MaxHeap priorityQueue = new MaxHeap();
        priorityQueue.Insert(5);
        priorityQueue.Insert(6);
        priorityQueue.Insert(4);
        
        priorityQueue.PrintHeap();
        
        Console.WriteLine("Max " + priorityQueue.GetMax());
        
        priorityQueue.DeleteMax();
        
        priorityQueue.PrintHeap();
        
        priorityQueue.Insert(10);
        
        priorityQueue.PrintHeap();
    }
    
    public class Node
    {
        public Node left;
        public Node right;
        public Node parent;
        public int value;
    }
    
    public class MaxHeap
    {
        public Node root;
        
        public void Insert(int value)
        {
            if(this.root == null)
            {
                Console.WriteLine("Root Inserted. Value : " + value);
                Node temp = new Node();
                temp.value = value;
                temp.right = null;
                temp.left = null;
                temp.parent = null;
                this.root = temp;
            }
            else
            {
                Console.WriteLine("Non Root Inserted. Value " + value);
                Node temp = new Node();
                temp = this.root;
                while(temp.right != null)
                {
                    temp = temp.right;
                }
                
                Node newNode = new Node();
                newNode.right = null;
                newNode.left = null;
                newNode.value = value;
                newNode.parent = temp;
                temp.right = newNode;
                
                ShuffleUp(newNode);
            }
        }
        
        public void ShuffleUp(Node shuffleNode)
        {
            while(shuffleNode.parent != null)
            {
                if(shuffleNode.value <= shuffleNode.parent.value)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Shuffled");
                    int tempValue = shuffleNode.value;
                    shuffleNode.value = shuffleNode.parent.value;
                    shuffleNode.parent.value = tempValue;
                    
                    shuffleNode = shuffleNode.parent;
                }
            }
            
            return;            
        }
        
        public int GetMax()
        {
            return this.root.value;
        }
        
        public void DeleteMax()
        {
            if(this.root == null)
                return;
            else
            {
                Node tracker = new Node();
                tracker = this.root;
                while(tracker.right != null)
                {
                    tracker = tracker.right;
                }
                
                int swapper = this.root.value;
                this.root.value = tracker.value;
                tracker.value = swapper;
                
                tracker.parent.right = null;
                tracker.left = null;
                tracker.right = null;
                
                ShuffleDown(this.root);
            }
        }
        
        public void ShuffleDown(Node node)
        {
            if(this.root == null)
                return;
            
            if(node == null)
                return;
            
            while(node.right != null || node.left != null)
            {
                if(node.right != null)
                {
                    if(node.right.value > node.value)
                    {
                        if(node.left != null)
                        {
                            if(node.left.value > node.value)
                            {
                                if(node.left.value > node.right.value)
                                {
                                    Console.WriteLine("Swapped Left 1");
                                    Swap(node, false);
                                    node = node.left;
                                }
                                else
                                {
                                    Console.WriteLine("Swapped Right 1");
                                    Swap(node, true);
                                    node = node.right;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Swapped Right 2");
                            Swap(node, true);
                            node = node.right;
                        }
                    }
                    else
                    {
                        if(node.left != null)
                        {
                            if(node.left.value > node.value)
                            {
                                Console.WriteLine("Swapped Left 2");
                                Swap(node, false);                                
                                node = node.left;
                            }
                        }
                    }
                }
                else
                {                    
                    if(node.left != null)
                    {
                        if(node.left.value > node.value)
                        {
                            Console.WriteLine("Swapped Left 3");
                            Swap(node, false);
                            node = node.left;
                        }
                    }
                }
                
                if(node.right == null && node.left == null)
                    break;
            }
        }
        
        public void Swap(Node node, bool right)
        {
            if(right)
            {   
                int swapper = node.right.value;
                node.right.value = node.value;
                node.value = swapper;
            }
            else
            {                
                int swapper = node.left.value;
                node.left.value = node.value;
                node.value = swapper;
            }
        }
        
        public void PrintHeap()
        {
            Console.WriteLine("Printing Heap");
            if(this.root == null)
                return;
            
            InorderPrint(this.root);
        }
        
        public void InorderPrint(Node node)
        {
            if(node == null)
                return;
            
            Console.WriteLine("left");
            InorderPrint(node.left);
            Console.WriteLine(node.value);
            Console.WriteLine("right");
            InorderPrint(node.right);
        }
    }
}
