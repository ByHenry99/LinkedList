using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend;

public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null; // This line can be removed
        _tail = null; // This line can be removed
    }

    public void AddAlphabetically(T data) // #1 Add
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null) // Empty list
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        if (Comparer<T>.Default.Compare(data, _head.Data!) <= 0) // Beginning
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }
        if (Comparer<T>.Default.Compare(data, _tail!.Data!) > 0) // End
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
            return;
        }
        // Middle
        var current = _head;
        while (current != null)
        {
            if (Comparer<T>.Default.Compare(data, current.Data!) <= 0)
            {
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev!.Next = newNode;
                current.Prev = newNode;
                return;
            }
            current = current.Next;
        }
    }

    public override string ToString() // #2 Show list forward
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Next;
        }
        return $"{output} null";
    }

    public string ToStringReverse() // #3 Show backwards
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Prev;
        }
        return $"{output} null";
    }

    public void SortDescending() // #4 Sort in descending order
    {
        if (_head == null || _head.Next == null) //List is empty or only one data
        {
            return;
        }

        var current = _head;

        while (current != null)
        {
            var nextNode = current.Next;

            while (nextNode != null)
            {
                if (Comparer<T>.Default.Compare(current.Data!, nextNode.Data!) < 0)
                {
                    var temp = current.Data;
                    current.Data = nextNode.Data;
                    nextNode.Data = temp;
                }
                nextNode = nextNode.Next;
            }

            current = current.Next;


        }
    }

    public string ShowMode() // #5 Show mode(s)
    {
        if (_head == null)
        {
            return "The list is empty.";
        }

        var current = _head;
        var maxCount = 0;
        var modes = new List<T>(); //Empty list

        while (current != null)
        {
            var temp = _head;
            var cont = 0;

            while (temp != null)
            {
                if (current.Data!.Equals(temp.Data))
                    cont++;

                temp = temp.Next;
            }

            if (cont > maxCount)
            {
                maxCount = cont;
                modes.Add(current.Data!);
            }
            else if (cont == maxCount && !modes.Contains(current.Data!))
            {
                modes.Add(current.Data!);
            }

            current = current.Next;
        }

        if (modes.Count == 1)
        {
            return $"The mode is {modes[0]}.";
        }
        else
        {
            return $"The modes are {string.Join(" and ", modes)}.";
        }
    }

    public string ShowGraph() //#6 ShowGraph
    {
        if (_head == null)
        {
            return "The list is empty.";
        }

        var current = _head;
        var counted = new List<T>();
        var result = new List<string>();

        while (current != null)
        {
            if (!counted.Contains(current.Data!))
            {
                var temp = _head;
                var cont = 0;

                while (temp != null)
                {
                    if (current.Data!.Equals(temp.Data))
                        cont++;

                    temp = temp.Next;
                }

                result.Add($"{current.Data} {new string('*', cont)}");
                counted.Add(current.Data!);
            }

            current = current.Next;
        }

        return string.Join("\n", result);
    }

    public bool Exists(T data) //#7 Exists
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        
        return false;
    }

    public bool RemoveFirstOccurrence(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                // Beginning
                if (current.Prev == null)
                    _head = current.Next;
                else
                    current.Prev.Next = current.Next;

                // End
                if (current.Next == null)
                    _tail = current.Prev;
                else
                    current.Next.Prev = current.Prev;

                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public int RemoveAllOccurrences(T data)
    {
        var current = _head;
        var removed = 0;

        while (current != null)
        {
            var next = current.Next;

            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                // Beginning
                if (current.Prev == null)
                {
                    _head = current.Next;
                }
                else
                {
                    current.Prev.Next = current.Next;
                }
                // End
                if (current.Next == null)
                {
                    _tail = current.Prev;
                }
                else
                    current.Next.Prev = current.Prev;

                removed++;
            }

            current = next;
        }

        return removed;
    }
}
