using Sort;
using Sort.Algorithms;

IComparable[] first = new IComparable[100];
int[] a = new int[100];
int[] b = new int[100];
int[] d = new int[100];
int[] e = new int[100];
int[] c = new int[101];

int srav = 0, zamen = 0;

Random rnd = new Random();

for (int i = 0; i < 100; i++)
    first[i] = rnd.Next(0, 1000);


first.CopyTo(a, 0);
first.CopyTo(b, 0);
first.CopyTo(c, 1);
first.CopyTo(d, 0);
first.CopyTo(e, 0);
c[0] = int.MinValue;

for (int i = 0; i < 100; i++)
    for (int j = i + 1; j < 100; j++)
    {
        srav++;
        if (a[i] > a[j])
        {
            zamen++;
            var temp = a[j];
            a[j] = a[i];
            a[i] = temp;
        }
    }
Console.WriteLine("Пузырьком");
Console.WriteLine($"Количество сравнений - {srav}\nКоличество замен - {zamen}\n");

zamen = srav = 0;

int left = 0,
    right = 99;

while (left < right)
{
    for (int i = left; i < right; i++)
    {
        srav++;
        if (b[i] > b[i + 1])
        {
            zamen++;
            var temp = b[i+1];
            b[i+1] = b[i];
            b[i] = temp;
        }
    }
    right--;

    for (int i = right; i > left; i--)
    {
        srav++;
        if (b[i - 1] > b[i])
        {
            zamen++;
            var temp = b[i - 1];
            b[i - 1] = b[i];
            b[i] = temp;
        }
    }
    left++;
}
Console.WriteLine("Шейкерная");
Console.WriteLine($"Количество сравнений - {srav}\nКоличество замен - {zamen}\n");

srav = zamen = 0;


for (int i = 1; i <= 100; i++)
{
    int x;
    int j;
    x = c[i];
    j = i;
    while (srav++ > -1  && j > 0 && c[j - 1] > x )
    {
        zamen++;
        c[j] = c[j - 1];
        j--;
    }
    c[j] = x;
}

Console.WriteLine("Вставками");
Console.WriteLine($"Количество сравнений - {srav}\nКоличество замен - {zamen}\n");

zamen = srav = 0;

for (int s = 100 / 2; s > 0; s /= 2)
{
    for (int i = s; i < 100; i++)
    {
        for (int j = i - s; j >= 0 ; j -= s)
        {
            srav++;
            if (d[j] > d[j + s])
            {
                zamen++;
                int temp = d[j];
                d[j] = d[j + s];
                d[j + s] = temp;
            }
        }
    }
}


Console.WriteLine("Шелла");
Console.WriteLine($"Количество сравнений - {srav}\nКоличество замен - {zamen}\n");

srav = zamen = 0;



int partition(int[] array, int start, int end)
{
    int marker = start;
    for (int i = start; i <= end; i++)
    {
        srav++;
        if (array[i] <= array[end])
        {
            zamen++;
            int temp = array[marker]; // swap
            array[marker] = array[i];
            array[i] = temp;
            marker += 1;
        }
    }
    return marker - 1;
}

void quicksort(int[] array, int start, int end)
{
    if (start >= end)
    {
        return;
    }
    int pivot = partition(array, start, end);
    quicksort(array, start, pivot - 1);
    quicksort(array, pivot + 1, end);
}

quicksort(e, 0, e.Length - 1);

Console.WriteLine("Быстрая");
Console.WriteLine($"Количество сравнений - {srav}\nКоличество замен - {zamen}\n");

IDiagnosticSortAlgorithm algorithm = new ShakerSort();
algorithm.SwapTwo += CompareTwo;
var t = algorithm.Sort(first);
algorithm.SwapTwo -= CompareTwo;


foreach (var element in t)
{
    Console.Write($"{element} ");
}

Console.WriteLine($"\n\n{algorithm.CompareCount} {algorithm.SwapCount}");

void CompareTwo(int first, int second)
{
    Console.WriteLine($"{first} <-> {second}");
}