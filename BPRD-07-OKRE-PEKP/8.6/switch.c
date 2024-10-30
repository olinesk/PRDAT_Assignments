// Test for Exercise 8.6

void main (int month)
{
    int days;
    int year;
    year = 2010;

    switch (month) {
        case 1:
            { days = 31; }
        case 2:
            { days = 28; if (y%4==0) days = 29; }
        case 3:
            { days = 31; }
    }

    print days;
    println;
}