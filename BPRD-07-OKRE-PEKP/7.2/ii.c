// Exercise 7.2 (ii)

void squares(int n, int arr[])
{
    int i;
    i = 0;

    while (i < n)
    {
        arr[i] = i * i;
        i = i + 1;
    }
}

void main(int n)
{
    int arr[20];
    int *sump;

    squares(n, arr);

    arrsum(n, arr, sump);

    print *sump;
    println;
}

// From exercise 7.2 (i)
void arrsum(int n, int arr[], int *sump)
{
    int i;
    int sum;

    i = 0;
    sum = 0;

    while (i < n)
    {
        sum = sum + arr[i];
        i = i + 1;
    }

    *sump = sum;
}