namespace AssignmentThree;

public class StringsDictionary
{
    private const int InitialSize = 10;
    private readonly LinkedList?[] _buckets = new LinkedList?[InitialSize];

    public void Add(string key, string value)
    {
        int bucketPosition = CalculateHash(key) % InitialSize;
        
        if (_buckets[bucketPosition] == null)
        {
            _buckets[bucketPosition] = new LinkedList();
        }
        
        LinkedListNode? node = _buckets[bucketPosition]!.GetBy(key);
        if (node != null)
        {
            node.Pair.Value = value;
        } else { _buckets[bucketPosition]!.Add(key, value); }
    }
     
    public void RemoveBy(string key)
    {
        int bucketPosition = CalculateHash(key) % InitialSize;
        string message = $"{key} is not in the dictionary";
        
        if (_buckets[bucketPosition] != null)
        {
            LinkedListNode? node = _buckets[bucketPosition]!.GetBy(key);

            if (node != null)
            {
                _buckets[bucketPosition]!.RemoveBy(key);
            }
            else { Console.WriteLine(message); }
        }
        else { Console.WriteLine(message); }
    }
    
    public string? GetBy(string key)
    {
        int bucketPosition = CalculateHash(key) % InitialSize;
        
        if (_buckets[bucketPosition] != null)
        {
            LinkedListNode? node = _buckets[bucketPosition]!.GetBy(key);

            if (node != null)
            {
                return node.Pair.Value;
            }        
        }

        Console.WriteLine($"{key} is not in the dictionary");
        return null;
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
        string result = "";

        for (int i = 0; i < InitialSize; i++)
        {
            result += $"Bucket {i}: {_buckets[i]}\n";

        }

        return result;
    }
}