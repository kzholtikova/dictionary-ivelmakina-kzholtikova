namespace AssignmentThree;

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