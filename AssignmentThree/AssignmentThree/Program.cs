namespace AssignmentThree
{
    class Program
    {
        static void Main()
        {
            // Instantiate the StringsDictionary
            StringsDictionary myDictionary = new StringsDictionary();

            // Add some key-value pairs
            myDictionary.Add("apple", "fruit");
            myDictionary.Add("banana", "fruit");
            myDictionary.Add("carrot", "vegetable");

            // Print the initial state
            Console.WriteLine("Initial Dictionary State:");
            Console.WriteLine(myDictionary);

            // Test the Get method
            TestGet(myDictionary, "apple");
            TestGet(myDictionary, "banana");
            TestGet(myDictionary, "carrot");
            TestGet(myDictionary, "grape");

            // Test the Remove method
            TestRemove(myDictionary, "banana");
            TestRemove(myDictionary, "orange");

            // Print the final state
            Console.WriteLine("Final Dictionary State:");
            Console.WriteLine(myDictionary);
        }

        // Helper method to test the Get method
        static void TestGet(StringsDictionary dictionary, string key)
        {
            Console.WriteLine($"Getting value for key '{key}': {dictionary.GetBy(key)}");
        }

        // Helper method to test the Remove method
        static void TestRemove(StringsDictionary dictionary, string key)
        {
            Console.WriteLine($"Removing key '{key}'...");
            dictionary.RemoveBy(key);
            Console.WriteLine(dictionary);
        }
    }
}