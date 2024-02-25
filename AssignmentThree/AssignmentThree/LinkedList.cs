namespace AssignmentThree;

public class LinkedList
{
    private LinkedListNode? _head;

    public void Add(string key, string value)
    {
        if (_head != null)
        {
            LinkedListNode currentNode = _head;
            
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new LinkedListNode(new KeyValuePair(key, value));
        } else { _head = new LinkedListNode(new KeyValuePair(key, value)); }
    }

    public void RemoveBy(string key)
    {
        if (_head?.Pair.Key == key)
        {
            _head = _head.Next;
            return;
        }
        
        LinkedListNode? currentNode = _head;
        
        while (currentNode?.Next != null && currentNode.Next.Pair.Key != key)
        {
            currentNode = currentNode.Next;
        }

        if (currentNode?.Next != null)
        {
            currentNode.Next = currentNode.Next.Next;
        } 
    }
    
    public LinkedListNode? GetBy(string key)
    {
        LinkedListNode? currentNode = _head;
        
        while (currentNode != null && currentNode.Pair.Key != key)
        {
            currentNode = currentNode.Next;
        }
        
        return currentNode;
    }

    public override string ToString()
    {
        string result = "";
        LinkedListNode? currentNode = _head;
        
        while (currentNode != null)
        {
            result += currentNode.ToString();
            currentNode = currentNode.Next;
        }

        return result;
    }
}

public class LinkedListNode(KeyValuePair pair, LinkedListNode? next = null)
{
    public KeyValuePair Pair { get; } = pair;
    public LinkedListNode? Next { get; set; } = next;

    public override string ToString()
    {
        return $"{Pair}; ";
    }
}

public class KeyValuePair(string key, string value)
{
    public string Key { get; } = key;
    public string Value { get; set; } = value;

    public override string ToString()
    {
        return $"{Key}: {Value}";
    }
}