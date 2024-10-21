// Exercise 7.3

void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    int c;

    for (c = 0; c <= max; c = c + 1)
    {
        freq[c] = 0;
    }

    for (i = 0; i < n; i = i + 1)
    {
        freq[ns[i]] = freq[ns[i]] + 1;
    }
}

void main(int n)
{
    int ns[7];

    ns[0] = 1;
    ns[1] = 2;
    ns[2] = 1;
    ns[3] = 1;
    ns[4] = 1;
    ns[5] = 2;
    ns[6] = 0;

    int freq[4];

    histogram(7, ns, 3, freq);

    int i;
    i = 0;

    for (i = 0; i <= 3; i = i + 1)
    {
        print freq[i];
    }

    println;
}