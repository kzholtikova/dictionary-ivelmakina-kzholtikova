namespace AssignmentThree;

public class StringsDictionary
{
    private int _size = 10;
    private LinkedList?[] _buckets = new LinkedList?[10];
    private const double MarginalLoadFactor = 0.75;
    private int _elementsCount;
    
    private double CalculateLoadFactor()
    {
        return (_elementsCount * 1.0) / _buckets.Length;
    }

    private void Rehash()
    {
        LinkedList?[] initialBuckets = _buckets;
        
        _size *= 2;
        _buckets = new LinkedList?[_size];
        _elementsCount = 0;

        for (int i = 0; i < initialBuckets.Length; i++)
        {
            if (initialBuckets[i] == null)
            {
                continue;
            }
            
            foreach (var pair in initialBuckets[i]!)
            {
                Add(pair.Key, pair.Value);
            }
        }

    }
    
    public void Add(string key, string value)
    {
        if (CalculateLoadFactor() > MarginalLoadFactor)
        {
            Rehash();
        }
        
        int bucketPosition = CalculateHash(key) % _size;
        
        if (_buckets[bucketPosition] == null)
        {
            _buckets[bucketPosition] = new LinkedList();
        }
        
        LinkedListNode? node = _buckets[bucketPosition]?.GetBy(key);
        if (node == null)
        {
            _buckets[bucketPosition]?.Add(new KeyValuePair(key, value));
            _elementsCount++;
        } else {  node.Pair.Value = value; }
    }
     
    public void RemoveBy(string key)
    {
        int bucketPosition = CalculateHash(key) % _size;
        
        if (_buckets[bucketPosition] != null)
        {
            LinkedListNode? node = _buckets[bucketPosition]?.GetBy(key);

            if (node != null)
            {
                _buckets[bucketPosition]?.RemoveBy(key);
                _elementsCount--;
            }
        } 
    }
    
    public string? GetBy(string key)
    {
        int bucketPosition = CalculateHash(key) % _size;
        
        if (_buckets[bucketPosition] != null)
        {
            LinkedListNode? node = _buckets[bucketPosition]?.GetBy(key);

            if (node != null)
            {
                return node.Pair.Value;
            }        
        }
        
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

        for (int i = 0; i < _size; i++)
        {
            result += $"Bucket {i}: {_buckets[i]}\n";
        }

        return result;
    }
}
