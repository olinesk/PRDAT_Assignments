// Exercise 7.3

void squares(int n, int arr[])
{
    int i;

    for(i = 0; i < n; i = i + 1)
    {
        arr[i] = i * i;
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

void arrsum(int n, int arr[], int *sump)
{
    int i;
    int sum;
    sum = 0;

    for (i = 0; i < n; i = i + 1)
    {
        sum = sum + arr[i];
    }

    *sump = sum;
}