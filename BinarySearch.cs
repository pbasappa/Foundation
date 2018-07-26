class BinarySearch {
    static void Main() {
        
        List<int> input = new List<int> {1,2,3,5,6};
        int findNumber = 0;
        
        BinarySearch(input, 0, input.Count-1, findNumber);
    }
    
    public static void BinarySearch(List<int> input, int low, int high, int search)
    {
        if(input[low] > search || input[high] < search)
        {
            Console.WriteLine("Number not found");
            return;
        }
        
        int middle = low + (high - low)/2;
        
        if(input[middle] == search)
        {
            Console.WriteLine("Number found. Index = " + middle);
            return;
        }
        
        if(input[middle] < search)
        {
            BinarySearch(input, middle+1, high, search);
        }
        else
        {
            BinarySearch(input, low, middle, search);
        }
    }
}
