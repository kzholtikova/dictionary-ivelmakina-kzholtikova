namespace AssignmentThree;

public class LinkedList
{
    private LinkedListNode? _head;
    private LinkedListNode? _tail;

    public void Add(KeyValuePair pair)
    {
        if (_head == null || _tail == null)
        {
            _head = new LinkedListNode(pair);
            _tail = _head;
            return;
        }
       
        _tail.Next = new LinkedListNode(pair, _tail);
        _tail = _tail.Next;
    }
    
    public void RemoveBy(string key)
    {
        if (_head?.Pair.Key == key)
        {
            _head = _head.Next;
            if (_head != null)
            {
                _head.Previous = null;
            }

            if (_head == null)
            {
                _tail = null;
            }
           
            return;
        }

        if (_tail?.Pair.Key == key)
        {
            _tail = _tail.Previous;
            if (_tail != null)
            {
                _tail.Next = null;
            }
            
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
            if (currentNode.Next != null)
            {
                currentNode.Next.Previous = currentNode;
            }
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

public class LinkedListNode(KeyValuePair pair, LinkedListNode? prev = null, LinkedListNode? next = null)
{
    public KeyValuePair Pair { get; } = pair;
    public LinkedListNode? Previous { get; set; } = prev;
    public LinkedListNode? Next { get; set; } = next;

    public override string ToString()
    {
        return $" prev: {Previous?.Pair.Key}, current: {Pair}, next: {Next?.Pair.Key},";
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