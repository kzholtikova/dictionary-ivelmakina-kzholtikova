namespace AssignmentThree;

public class StringsDictionary
{
    private const int InitialSize = 10;
    private readonly LinkedList?[] _buckets = new LinkedList?[InitialSize];

    public void Add(string key, string value)
    {
        
    }
     
    public void Remove(string key)
    {
        
    }
    
    public string? Get(string key)
    {
        
    }

    private int CalculateHash(string key)
    {
        const int prime = 31; // common prime number for hash functions
        int hash = 0;

        foreach (char c in key)
        {
            hash = Math.Abs((hash * prime) + c);
        }

        return hash;
    }

    public override string ToString()
    {
        
    }
}