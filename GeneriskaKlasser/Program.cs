Queue<string> affärsKö = new();
Dictionary<string, int> dictionary = new Dictionary<string, int>();
string name;
int position = 1;

while (true)
{
    Console.WriteLine("Skriv '1' för att lägga till en person i kön, '2' för att ta bort en person från kön, eller '3' för att kolla kön");
    string choice = Console.ReadLine();

    bool braVal = int.TryParse(choice, out int val);
    Console.Clear();

    if (!braVal || val < 1 || val > 3)
    {
        Console.WriteLine("Inte ett korrekt val");
    }

    if (val == 1)
    {
        Console.WriteLine("Vad för namn ska personen ha?");
        name = Console.ReadLine();
        while (name.Length < 1) 
        {
            Console.WriteLine("Personen måste ha ett namn");
            name = Console.ReadLine();
        }
        affärsKö.Enqueue(name);
        dictionary.Add(name, position++);
        Console.WriteLine(name + " har lagts till i kön\n");
    }
    else if (val == 2)
    {
        if (affärsKö.Count > 0)
        {
            string removedCustomer = affärsKö.Dequeue();
            dictionary.Remove(removedCustomer);
            foreach (var person in affärsKö)
            {
                dictionary[person] -= 1;
            }
            Console.WriteLine(removedCustomer + " har tagits bort från kön\n");
        }
        else
        {
            Console.WriteLine("Det finns ingen att ta bort i kön\n");
        }
    }
    else if (val == 3)
    {
        if (affärsKö.Count > 0)
        {
            foreach (var person in affärsKö)
            {
                Console.WriteLine(person + " är på plats " + dictionary[person] + " i kön");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Ingen står i kön\n");
        }
    }
}
