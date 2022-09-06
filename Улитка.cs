int CorrectInput()
{
    string? UserNumber;
    int number = 0;
    bool check = false;
    while (check == false)
    {
        UserNumber = Console.ReadLine();
        if (int.TryParse(UserNumber, out number))
        {
            check = true;
        }
        else
        {
            Console.Write("Ошибка ввода.\n Повторите ввод:");
        }
    }
    return number;
}

// создание двумерного массива - улитка!
void CreateArray()
{
    Console.WriteLine("Введите размеры массива");
    Console.Write("Введите количество строк: ");
    int downSide = CorrectInput();
    Console.Write("Введите количество столбцов: ");
    int rigtSide = CorrectInput();
    int derection = 1, i = 0, j = 0, leftSide = 0, upSide = 0;
    int[,] matrix = new int[downSide, rigtSide];
    int max =downSide*rigtSide+1;
    downSide--;
    rigtSide--;
    for (int num = 1; num < max; num++)
    {
        switch(derection)
        {
        case 1:
            matrix[i,j] = num;
            j++;
            if (j > rigtSide - 1)
                derection = 2;
            break;
        case 2:
            matrix[i,j] = num;
            i++;
            if (i > downSide - 1)
                derection = 3;
            break;
        case 3:
            matrix[i,j] = num;
            j--;
            if (j < leftSide+1)
                derection = 4;
                break;
        case 4:
            matrix[i,j] = num;
            i--;
            if (i < upSide+1)
            {
                derection = 1;
                leftSide++;
                upSide++;
                downSide--;
                rigtSide--;
                j=leftSide;
                i=upSide;
                if (j == rigtSide)
                    derection=2;
            }
            break;
        }
    }
    PrintMatrix(matrix);
}

// Вывод двумерного массива
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i<matrix.GetUpperBound(0) + 1; i++)
    {
        for (int j = 0; j<matrix.GetUpperBound(1) + 1; j++)
        {
            if (matrix[i,j]<10)
                Console.Write(" " + matrix[i,j] + " ");
            else
                Console.Write(matrix[i,j]+" ");             
        }
    Console.WriteLine();
    }
}

//Код программы
CreateArray();