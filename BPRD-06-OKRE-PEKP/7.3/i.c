// Exercise 7.3

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

void main(int n)
{
    int arr[4];

    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8;

    int *sump;

    arrsum(n, arr, sump);

    print *sump;
    println;
}