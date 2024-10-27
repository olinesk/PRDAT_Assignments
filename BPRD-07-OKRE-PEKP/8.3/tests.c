// Exercise 8.3

void testInc(int n)
{
    print ++n;
    println;
}

void testDec(int n)
{
    print --n;
    println;
}

void arrInc(int n)
{
    int arr[1];

    arr[0] = n;

    ++arr[0];

    print arr[0];
    println;
}

void arrDec(int n)
{
    int arr[1];

    arr[0] = n;
    
    --arr[0];

    print arr[0];
    println;
}

void doubleInc(int n)
{
    int arr[1];

    arr[0] = n;

    print (++arr[++n]);
    println;
}

void doubleDec(int n)
{
    int arr[1];

    arr[0] = n;

    print (--arr[--n]);
    println;
}

void main(int n)
{
    testInc(n);

    testDec(n);
    
    arrInc(n);

    arrDec(n);

    doubleInc(n);

    doubleDec(n);
}