namespace AssignmentThree;

class Program
{
    public static void Main()
    {
        string filePath = "C:\\Users\\user\\Documents\\GitHub\\assignment-three-v3-ivelmakina-kzholtikova\\AssignmentThree\\AssignmentThree\\Dictionary.txt"; 

        if (File.Exists(filePath))
        {
            StringsDictionary dictionary = LoadDictionaryFromFile(filePath);
            RunDictionaryInteractiveMode(dictionary);
        } else { Console.WriteLine("File was not found"); }
    }

    private static StringsDictionary LoadDictionaryFromFile(string filePath)
    {
        string[] dictLines = File.ReadAllLines(filePath);
        StringsDictionary dictionary = new StringsDictionary();

        foreach (string line in dictLines)
        {
            string[] parts = line.Split("|");

            string word = parts[0];
            string definition = parts[2];

            dictionary.Add(word, definition);
        }

        return dictionary;
    }

    private static void RunDictionaryInteractiveMode(StringsDictionary? dictionary)
    {
        bool exitRequested = false;

        while (!exitRequested)
        {
            Console.WriteLine("Enter a word (or 'exit' to quit): ");
            string? input = Console.ReadLine()?.ToLower();

            if (input == "exit")
            {
                exitRequested = true;
            }
            else
            {
                if (input == null)
                {
                    continue;
                }

                string? definition = dictionary?.GetBy(input);

                if (definition != null)
                {
                    Console.WriteLine($"Definition: {definition}");
                } else { Console.WriteLine("Word was not found in the dictionary"); }
            }
        }
    }
}
