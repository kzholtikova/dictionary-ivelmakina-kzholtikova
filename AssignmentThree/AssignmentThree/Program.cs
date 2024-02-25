namespace AssignmentThree;

class Program
{
    public static void Main()
    {
        string filePath = "C:/run" +
                          "Users/user/Documents/GitHub/assignment-three-v3-ivelmakina-kzholtikova/" +
                          "AssignmentThree/AssignmentThree/Dictionary.txt"; // change filepath

        if (File.Exists(filePath))
        {
            StringsDictionary? dictionary = LoadDictionaryFromFile(filePath);

            if (dictionary != null)
            {
                RunDictionaryInteractiveMode(dictionary);
            }
            else
            {
                Console.WriteLine("Failed to load the dictionary. Exiting...");
            }
        }
        else
        {
            Console.WriteLine("File was not found");
        }
    }

    private static StringsDictionary? LoadDictionaryFromFile(string filePath)
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
        
    }
}
