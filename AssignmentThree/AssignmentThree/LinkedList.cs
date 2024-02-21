namespace AssignmentThree;

public class LinkedList
{
    private LinkedListNode? _head;

    public void Add(KeyValuePair pair)
    {
        if (_head is not null)
        {
            LinkedListNode currentNode = _head;
            
            while (currentNode.Next is not null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new LinkedListNode(pair);
        } else { _head = new LinkedListNode(pair); }
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