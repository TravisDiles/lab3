Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

int[][] arr = null;

bool running = true;
while (running)
{
    Console.WriteLine("\n===================================");
    Console.WriteLine("       ЛАБОРАТОРНА РОБОТА 3  ");
    Console.WriteLine("         Зубчасті масиви     ");
    Console.WriteLine("===================================");
    Console.WriteLine("1 - Заповнити масив рандомно");
    Console.WriteLine("2 - Заповнити масив вручну");
    Console.WriteLine("3 - Вивести поточний масив");
    Console.WriteLine("4 - Блок Влада (Варіант - додати рядок після мінімуму)");
    Console.WriteLine("5 - Блок Аліни (Варіант - знищити порожні рядки)");
    Console.WriteLine("6 - Блок Олени (Варіант - знищити рядки з нулями)");
    Console.WriteLine("0 - Вийти");
    Console.Write("Ваш вибір: ");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            arr = FillRandom();
            Console.WriteLine("Масив створено випадково:");
            PrintJagged(arr);
            break;

        case "2":
            arr = FillManual();
            Console.WriteLine("Масив створено вручну:");
            PrintJagged(arr);
            break;

        case "3":
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Масив ще не створено! Спочатку оберіть пункт 1 або 2.");
                break;
            }
            Console.WriteLine("Поточний масив:");
            PrintJagged(arr);
            break;

        case "4":
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Масив ще не створено! Спочатку оберіть пункт 1 або 2.");
                break;
            }
            //Vlad_Block(ref arr);
            break;

         case "5":
             if (arr == null || arr.Length == 0)
             {
                 Console.WriteLine("Масив ще не створено!");
                 break;
             }
             //Alina_Block(ref arr);
             break; 

        case "6":
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Масив ще не створено!");
                break;
            }
            //Olena_Block(ref arr);
            break;

        case "0":
            running = false;
            Console.WriteLine("До побачення!");
            break;

        default:
            Console.WriteLine("Ви ввели шось незрозуміле((");
            break;
    }
}

// INPUT METHOD

static int[][] FillRandom()
{
    Random rnd = new Random();
    Console.Write("Введіть кількість рядків: ");
    int rows = int.Parse(Console.ReadLine());

    int[][] jagged = new int[rows][];
    for (int i = 0; i < rows; i++)
    {
        Console.Write($"Скільки елементів у рядку {i + 1}? (або 0 = випадкова кількість 1-10): ");
        string line = Console.ReadLine();
        int cols = int.Parse(line);
        if (cols <= 0)
            cols = rnd.Next(-20, 20);

        jagged[i] = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            jagged[i][j] = rnd.Next(-20, 21);
        }
        Console.WriteLine($"  Рядок {i + 1} ({cols} ел.): {string.Join(", ", jagged[i])}");
    }
    return jagged;
}

static int[][] FillManual()
{
    Console.Write("Введіть кількість рядків: ");
    int rows = int.Parse(Console.ReadLine());

    int[][] jagged = new int[rows][];
    for (int i = 0; i < rows; i++)
    {
        Console.Write($"Скільки елементів у рядку {i + 1}? ");
        int cols = int.Parse(Console.ReadLine());

        jagged[i] = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            Console.Write($"  jagged[{i}][{j}] = ");
            jagged[i][j] = int.Parse(Console.ReadLine());
        }
    }
    return jagged;
}


static void PrintJagged(int[][] arr)
{
    if (arr == null || arr.Length == 0)
    {
        Console.WriteLine("Масив порожній.");
        return;
    }
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"  Рядок {i}: [ ");
        for (int j = 0; j < arr[i].Length; j++)
        {
            Console.Write(arr[i][j]);
            if (j < arr[i].Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine(" ]");
    }
    Console.WriteLine($"  Всього рядків: {arr.Length}");
}
