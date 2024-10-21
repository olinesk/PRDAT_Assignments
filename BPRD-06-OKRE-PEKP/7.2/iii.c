// Exercise 7.2 (iii)

void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    int c;

    c = 0;
    i = 0;

    while (c <= max)
    {
        freq[c] = 0;
        c = c + 1;
    }

    while (i < n)
    {
        freq[ns[i]] = freq[ns[i]] + 1;
        i = i + 1;
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

    while (i <= 3)
    {
        print freq[i];
        i = i + 1;
    }

    println;
}