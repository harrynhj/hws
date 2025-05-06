namespace day5
{
    public class ManageableList
    {
        public static void sol()
        {
            char operation;
            string[] list = new string[100];
            int count = 0;

            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;
                operation = input[0];
                if (operation == 'q')
                {
                    break;
                }
                else if (operation == '+')
                {
                    string itemToAdd = input.Substring(2).Trim();
                    if (!string.IsNullOrEmpty(itemToAdd) && count < list.Length)
                    {
                        list[count] = itemToAdd;
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid item or list is full.");
                    }
                }
                else if (operation == '-')
                {
                    if (input.Length > 1 && input[1] == '-')
                    {
                        list = new string[100];
                        count = 0;
                        Console.WriteLine("List cleared.");
                        continue;
                    }
                    else
                    {
                        string itemToRemove = input.Substring(2).Trim();
                        bool found = false;
                        for (int i = 0; i < count; i++)
                        {
                            if (list[i] == itemToRemove)
                            {
                                for (int j = i; j < count - 1; j++)
                                {
                                    list[j] = list[j + 1];
                                }
                                list[count - 1] = null;
                                count--;
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Item not found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                Console.WriteLine("Current List:");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"- {list[i]}");
                }
            }
        }
    }
}
