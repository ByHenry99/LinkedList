using Backend;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1": //Add alphabetically
            Console.Write("Enter value: ");
            list.AddAlphabetically(Console.ReadLine()!);
            break;

        case "2":  //Show forward
            Console.WriteLine(list.ToString());
            break;

        case "3": //Show backwards
            Console.WriteLine(list.ToStringReverse());
            break;

        case "4": //Sort descending
            list.SortDescending();
            Console.WriteLine(list.ToString());
            break;

        case "5": //Show mode(s)
            Console.WriteLine(list.ShowMode());
            break;

        case "6": //Show graph
            Console.WriteLine(list.ShowGraph());
            break;

        case "7":
            Console.Write("Enter value: "); //Exitst
            var itemToSearch = Console.ReadLine()!;
            Console.WriteLine(list.Exists(itemToSearch)
                ? $"The item: '{itemToSearch}' exists!"
                : $"The item: '{itemToSearch}' doesn't exists!");
            break;

        case "8":
            Console.Write("Enter value: "); //Delete and occurrence
            itemToSearch = Console.ReadLine()!;
            Console.WriteLine(list.RemoveFirstOccurrence(itemToSearch)
                ? $"The first occurrence of '{itemToSearch}' was removed!"
                : $"The ocurrence of '{itemToSearch}' wasn't found!");
            break;

        case "9":
            Console.Write("Enter value: "); //Delete all occurrences
            itemToSearch = Console.ReadLine()!;
            Console.WriteLine($"Occurrences removed: {list.RemoveAllOccurrences(itemToSearch)}");
            break;

            default:
            Console.WriteLine("Invalid option.");
            break;
    }
    
} while (option != "0");

string Menu()
{
    Console.WriteLine("------------------------------------");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("|               MENU               |");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("|----------------------------------|");
    Console.WriteLine("|1. Add                            |");
    Console.WriteLine("|2. Show forward                   |");
    Console.WriteLine("|3. Show backwards                 |");
    Console.WriteLine("|4. Sort descending                |");
    Console.WriteLine("|5. Show mode(s)                   |");
    Console.WriteLine("|6. Show graph                     |");
    Console.WriteLine("|7. Exists                         |");
    Console.WriteLine("|8. Delete an occurrence           |");
    Console.WriteLine("|9. Delete all occurrences         |");
    Console.WriteLine("|0. Exit.                          |");
    Console.WriteLine("------------------------------------");
    Console.Write("Enter your option? ");
    return Console.ReadLine()!;
}