namespace AssignmentThree;

public class LinkedList
{
    private LinkedListNode? _head;

    public void Add(string key, string value)
    {
        if (_head is not null)
        {
            LinkedListNode currentNode = _head;
            
            while (currentNode.Next is not null)
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

        if (currentNode?.Next == null)
        {
            Console.WriteLine($"{key} is not in the list.");
        } else { currentNode.Next = currentNode.Next.Next; }
    }
}

public class LinkedListNode(KeyValuePair pair, LinkedListNode? next = null)
{
    public KeyValuePair Pair { get; } = pair;
    public LinkedListNode? Next { get; set; } = next;
}

public class KeyValuePair(string key, string value)
{
    public string Key { get; } = key;
    public string Value { get;  } = value;
}