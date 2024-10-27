// Test examples for exercise 7.5

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

void combinedTest(int n)
{
    print ++n;
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

void main(int n)
{
    testInc(n);
    
    testDec(n);

    
    combinedTest(n);

    
    arrInc(n);
    
    arrDec(n);
}
