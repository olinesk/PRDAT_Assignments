# Assignment 7

All non-code answers are in this file.

</br>

---

## Exercise 8.1

**(i) Compile one of the micro-C examples provided, such as that in source file `ex11.c`, then run it using the abstract machine implemented in Java.**

**When run with command line argument 8, the program prints the 92 solutions to the eight queens problem: how to place eight queens on a chessboard so that none of them can attack any of the others.**

```fsharp
> open ParseAndComp;;
> compileToFile (fromFile "ex11.c") "ex11.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
   GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
   CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
   STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 103; ADD; LDI; GETBP;
   CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
   CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; GETBP;
   CSTI 2; ADD; LDI; GETBP; CSTI 0; ADD; LDI; SWAP; LT; NOT; IFNZRO "L2";
   GETBP; CSTI 2; ADD; CSTI 1; STI; INCSP -1; GOTO "L5"; Label "L4"; GETBP;
   CSTI 204; ADD; LDI; GETBP; CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI;
   GETBP; CSTI 2; ADD; LDI; ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2;
   ADD; ...]

> compile "ex11";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
   GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
   CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
   STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 103; ADD; LDI; GETBP;
   CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
   CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; GETBP;
   CSTI 2; ADD; LDI; GETBP; CSTI 0; ADD; LDI; SWAP; LT; NOT; IFNZRO "L2";
   GETBP; CSTI 2; ADD; CSTI 1; STI; INCSP -1; GOTO "L5"; Label "L4"; GETBP;
   CSTI 204; ADD; LDI; GETBP; CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI;
   GETBP; CSTI 2; ADD; LDI; ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2;
   ADD; ...]
```

```java
java Machine ex11.out 8
1 5 8 6 3 7 2 4 
1 6 8 3 7 4 2 5 
1 7 4 6 8 2 5 3 
1 7 5 8 2 4 6 3 
2 4 6 8 3 1 7 5 
2 5 7 1 3 8 6 4 
2 5 7 4 1 8 6 3 
2 6 1 7 4 8 3 5 
2 6 8 3 1 4 7 5 
2 7 3 6 8 5 1 4 
2 7 5 8 1 4 6 3 
2 8 6 1 3 5 7 4 
3 1 7 5 8 2 4 6 
3 5 2 8 1 7 4 6 
3 5 2 8 6 4 7 1 
3 5 7 1 4 2 8 6 
3 5 8 4 1 7 2 6 
3 6 2 5 8 1 7 4 
3 6 2 7 1 4 8 5 
3 6 2 7 5 1 8 4 
3 6 4 1 8 5 7 2 
3 6 4 2 8 5 7 1 
3 6 8 1 4 7 5 2 
3 6 8 1 5 7 2 4 
3 6 8 2 4 1 7 5 
3 7 2 8 5 1 4 6 
3 7 2 8 6 4 1 5 
3 8 4 7 1 6 2 5 
4 1 5 8 2 7 3 6 
4 1 5 8 6 3 7 2 
4 2 5 8 6 1 3 7 
4 2 7 3 6 8 1 5 
4 2 7 3 6 8 5 1 
4 2 7 5 1 8 6 3 
4 2 8 5 7 1 3 6 
4 2 8 6 1 3 5 7 
4 6 1 5 2 8 3 7 
4 6 8 2 7 1 3 5 
4 6 8 3 1 7 5 2 
4 7 1 8 5 2 6 3 
4 7 3 8 2 5 1 6 
4 7 5 2 6 1 3 8 
4 7 5 3 1 6 8 2 
4 8 1 3 6 2 7 5 
4 8 1 5 7 2 6 3 
4 8 5 3 1 7 2 6 
5 1 4 6 8 2 7 3 
5 1 8 4 2 7 3 6 
5 1 8 6 3 7 2 4 
5 2 4 6 8 3 1 7 
5 2 4 7 3 8 6 1 
5 2 6 1 7 4 8 3 
5 2 8 1 4 7 3 6 
5 3 1 6 8 2 4 7 
5 3 1 7 2 8 6 4 
5 3 8 4 7 1 6 2 
5 7 1 3 8 6 4 2 
5 7 1 4 2 8 6 3 
5 7 2 4 8 1 3 6 
5 7 2 6 3 1 4 8 
5 7 2 6 3 1 8 4 
5 7 4 1 3 8 6 2 
5 8 4 1 3 6 2 7 
5 8 4 1 7 2 6 3 
6 1 5 2 8 3 7 4 
6 2 7 1 3 5 8 4 
6 2 7 1 4 8 5 3 
6 3 1 7 5 8 2 4 
6 3 1 8 4 2 7 5 
6 3 1 8 5 2 4 7 
6 3 5 7 1 4 2 8 
6 3 5 8 1 4 2 7 
6 3 7 2 4 8 1 5 
6 3 7 2 8 5 1 4 
6 3 7 4 1 8 2 5 
6 4 1 5 8 2 7 3 
6 4 2 8 5 7 1 3 
6 4 7 1 3 5 2 8 
6 4 7 1 8 2 5 3 
6 8 2 4 1 7 5 3 
7 1 3 8 6 4 2 5 
7 2 4 1 8 5 3 6 
7 2 6 3 1 4 8 5 
7 3 1 6 8 5 2 4 
7 3 8 2 5 1 6 4 
7 4 2 5 8 1 3 6 
7 4 2 8 6 1 3 5 
7 5 3 1 6 8 2 4 
8 2 4 1 7 5 3 6 
8 2 5 3 1 7 4 6 
8 3 1 6 2 5 7 4 
8 4 1 3 6 2 7 5 

Ran 0.035 seconds
```

**(ii) Compile the example micro-C programs `ex3.c` and `ex5.c` using functions `compileToFile` and `fromFile` from `ParseAndComp.fs`.**

```fsharp
> open ParseAndComp;;
> compileToFile (fromFile "ex3.c") "ex3.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 0; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD;
   STI; INCSP -1; INCSP 0; Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0;
   ADD; LDI; LT; IFNZRO "L2"; INCSP -1; RET 0]

> compileToFile (fromFile "ex5.c") "ex5.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   GETBP; CSTI 0; ADD; LDI; STI; INCSP -1; INCSP 1; GETBP; CSTI 0; ADD; LDI;
   GETBP; CSTI 2; ADD; CALL (2, "L2"); INCSP -1; GETBP; CSTI 2; ADD; LDI;
   PRINTI; INCSP -1; INCSP -1; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1;
   INCSP -1; RET 0; Label "L2"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD;
   LDI; GETBP; CSTI 0; ADD; LDI; MUL; STI; INCSP -1; INCSP 0; RET 1]
```

**Study the generated symbolic bytecode.**

**Write up the bytecode in a more structured way with labels only at the beginning of the line.**

**Write the corresponding micro-C code to the right of the stack machine code.**

```txt
Symbolic bytecode for ex3.c

LDARGS               // Load function arguments from call stack
CALL (1, "L1")       // Call function at L1, return address to stack
STOP                 // Halt program execution
L1:                  // Start of main function
   INCSP 1           // Increase pointer by 1
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   CSTI 0            // Push 0 onto stack
   STI               // Store value 0
   INCSP -1          // Decrease stack pointer by 1
   GOTO "L3"         // Go to L3, conditional statement
L2:                  // while loop body
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   LDI               // Load top value
   PRINTI            // Print value
   INCSP -1          // Decrease by 1
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   LDI               // Load top value
   CSTI 1            // Push 1 onto stack
   ADD               // Value + 1
   STI               // Store value
   INCSP -1          // Decrease by 1
   INCSP 0           // No-op to maintain stack alignment
L3:                  // while loop
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   LDI               // Load value
   GETBP             // Load base pointer
   CSTI 0            // Push 0 onto stack
   ADD               // Base pointer + 0
   LDI               // Load value
   LT                // if base pointer + 1 < base pointer + 0
   IFNZRO "L2"       // if true, go to L2
   INCSP -1          // Clean up stack, decrease by 1
   RET 0             // return
```

```txt
Symbolic bytecode for ex5.c

LDARGS               // Load function arguments from call stack           
CALL 1, "L1"         // Call function at L1, return address to stack
STOP                 // Halt program execution
L1:                  // Start of main function
   INCSP 1           // Increase pointer by 1
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   GETBP             // Load base pointer
   CSTI 0            // Push 0 onto stack
   ADD               // Base pointer + 0
   LDI               // Load value
   STI               // Store value
   INCSP -1          // Decrease pointer by 1
   INCSP 1           // Increase pointer by 1
   GETBP             // Load base pointer
   CSTI 0            // Push 0 onto stack
   ADD               // Base pointer + 0
   LDI               // Load value
   GETBP             // Load base pointer
   CSTI 2            // Push 2 onto stack
   ADD               // Base pointer + 2
   CALL 2, "L2"      // Call L2 with 2 arguments
   INCSP -1          // Decrease pointer by 1
   GETBP             // Load base pointer
   CSTI 2            // Push 2 onto stack
   ADD               // Base pointer + 2
   LDI               // Load value
   PRINTI            // Print value
   INCSP -1          // Decrease pointer by 1
   INCSP -1          // Decrease pointer by 1
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   LDI               // Load value
   PRINTI            // Print value
   INCSP -1          // Decrease pointer by 1
   INCSP -1          // Decrease pointer by 1
   RET 0             // Return with 0 arguments
L2:                  // Start second function
   GETBP             // Load base pointer
   CSTI 1            // Push 1 onto stack
   ADD               // Base pointer + 1
   LDI               // Load value
   GETBP             // Load base pointer
   CSTI 0            // Push 0 onto stack
   ADD               // Base pointer + 0
   LDI               // Load value
   GETBP             // Load base pointer
   CSTI 0            // Push 0 onto stack
   ADD               // Base pointer + 0
   LDI               // Load value
   MUL               // Multiply top values
   STI               // Store new value
   INCSP -1          // Decrease pointer by 1
   INCSP 0           // No-op to align pointer
   RET 1             // Return
```

**Execute the compiled programs using `java Machine ex3.out 10` and similar.**

Note that these Micro-C programs require a commind line argument (an integer) when they are executed.

```java
java Machine ex3.out 10
0 1 2 3 4 5 6 7 8 9 
Ran 0.018 seconds
```

```java
java Machine ex5.out 10
100 10 
Ran 0.017 seconds
```

**Trace the execution using `java Machinetrace ex3.out 4`, and explain the stack contents and what goes on in each step of execution, and especialle how the low-level bytecode instructions map to the higher-level features of MicroC.**

You can capture the standard output from a command prompt (in a file `ex3trace.txt`) using the Unix-style notation:

```java
java Machinetrace ex3.out 4 > ex3trace.txt
```

```txt
[ ]{0: LDARGS}
[ 4 ]{1: CALL 1 5}
[ 4 -999 4 ]{5: INCSP 1}
[ 4 -999 4 0 ]{7: GETBP}
[ 4 -999 4 0 2 ]{8: CSTI 1}
[ 4 -999 4 0 2 1 ]{10: ADD}
[ 4 -999 4 0 3 ]{11: CSTI 0}
[ 4 -999 4 0 3 0 ]{13: STI}
[ 4 -999 4 0 0 ]{14: INCSP -1}
[ 4 -999 4 0 ]{16: GOTO 43}
[ 4 -999 4 0 ]{43: GETBP}
[ 4 -999 4 0 2 ]{44: CSTI 1}
[ 4 -999 4 0 2 1 ]{46: ADD}
[ 4 -999 4 0 3 ]{47: LDI}
[ 4 -999 4 0 0 ]{48: GETBP}
[ 4 -999 4 0 0 2 ]{49: CSTI 0}
[ 4 -999 4 0 0 2 0 ]{51: ADD}
[ 4 -999 4 0 0 2 ]{52: LDI}
[ 4 -999 4 0 0 4 ]{53: LT}
[ 4 -999 4 0 1 ]{54: IFNZRO 18}
[ 4 -999 4 0 ]{18: GETBP}
[ 4 -999 4 0 2 ]{19: CSTI 1}
[ 4 -999 4 0 2 1 ]{21: ADD}
[ 4 -999 4 0 3 ]{22: LDI}
[ 4 -999 4 0 0 ]{23: PRINTI}
0 [ 4 -999 4 0 0 ]{24: INCSP -1}
[ 4 -999 4 0 ]{26: GETBP}
[ 4 -999 4 0 2 ]{27: CSTI 1}
[ 4 -999 4 0 2 1 ]{29: ADD}
[ 4 -999 4 0 3 ]{30: GETBP}
[ 4 -999 4 0 3 2 ]{31: CSTI 1}
[ 4 -999 4 0 3 2 1 ]{33: ADD}
[ 4 -999 4 0 3 3 ]{34: LDI}
[ 4 -999 4 0 3 0 ]{35: CSTI 1}
[ 4 -999 4 0 3 0 1 ]{37: ADD}
[ 4 -999 4 0 3 1 ]{38: STI}
[ 4 -999 4 1 1 ]{39: INCSP -1}
[ 4 -999 4 1 ]{41: INCSP 0}
[ 4 -999 4 1 ]{43: GETBP}
[ 4 -999 4 1 2 ]{44: CSTI 1}
[ 4 -999 4 1 2 1 ]{46: ADD}
[ 4 -999 4 1 3 ]{47: LDI}
[ 4 -999 4 1 1 ]{48: GETBP}
[ 4 -999 4 1 1 2 ]{49: CSTI 0}
[ 4 -999 4 1 1 2 0 ]{51: ADD}
[ 4 -999 4 1 1 2 ]{52: LDI}
[ 4 -999 4 1 1 4 ]{53: LT}
[ 4 -999 4 1 1 ]{54: IFNZRO 18}
[ 4 -999 4 1 ]{18: GETBP}
[ 4 -999 4 1 2 ]{19: CSTI 1}
[ 4 -999 4 1 2 1 ]{21: ADD}
[ 4 -999 4 1 3 ]{22: LDI}
[ 4 -999 4 1 1 ]{23: PRINTI}
1 [ 4 -999 4 1 1 ]{24: INCSP -1}
[ 4 -999 4 1 ]{26: GETBP}
[ 4 -999 4 1 2 ]{27: CSTI 1}
[ 4 -999 4 1 2 1 ]{29: ADD}
[ 4 -999 4 1 3 ]{30: GETBP}
[ 4 -999 4 1 3 2 ]{31: CSTI 1}
[ 4 -999 4 1 3 2 1 ]{33: ADD}
[ 4 -999 4 1 3 3 ]{34: LDI}
[ 4 -999 4 1 3 1 ]{35: CSTI 1}
[ 4 -999 4 1 3 1 1 ]{37: ADD}
[ 4 -999 4 1 3 2 ]{38: STI}
[ 4 -999 4 2 2 ]{39: INCSP -1}
[ 4 -999 4 2 ]{41: INCSP 0}
[ 4 -999 4 2 ]{43: GETBP}
[ 4 -999 4 2 2 ]{44: CSTI 1}
[ 4 -999 4 2 2 1 ]{46: ADD}
[ 4 -999 4 2 3 ]{47: LDI}
[ 4 -999 4 2 2 ]{48: GETBP}
[ 4 -999 4 2 2 2 ]{49: CSTI 0}
[ 4 -999 4 2 2 2 0 ]{51: ADD}
[ 4 -999 4 2 2 2 ]{52: LDI}
[ 4 -999 4 2 2 4 ]{53: LT}
[ 4 -999 4 2 1 ]{54: IFNZRO 18}
[ 4 -999 4 2 ]{18: GETBP}
[ 4 -999 4 2 2 ]{19: CSTI 1}
[ 4 -999 4 2 2 1 ]{21: ADD}
[ 4 -999 4 2 3 ]{22: LDI}
[ 4 -999 4 2 2 ]{23: PRINTI}
2 [ 4 -999 4 2 2 ]{24: INCSP -1}
[ 4 -999 4 2 ]{26: GETBP}
[ 4 -999 4 2 2 ]{27: CSTI 1}
[ 4 -999 4 2 2 1 ]{29: ADD}
[ 4 -999 4 2 3 ]{30: GETBP}
[ 4 -999 4 2 3 2 ]{31: CSTI 1}
[ 4 -999 4 2 3 2 1 ]{33: ADD}
[ 4 -999 4 2 3 3 ]{34: LDI}
[ 4 -999 4 2 3 2 ]{35: CSTI 1}
[ 4 -999 4 2 3 2 1 ]{37: ADD}
[ 4 -999 4 2 3 3 ]{38: STI}
[ 4 -999 4 3 3 ]{39: INCSP -1}
[ 4 -999 4 3 ]{41: INCSP 0}
[ 4 -999 4 3 ]{43: GETBP}
[ 4 -999 4 3 2 ]{44: CSTI 1}
[ 4 -999 4 3 2 1 ]{46: ADD}
[ 4 -999 4 3 3 ]{47: LDI}
[ 4 -999 4 3 3 ]{48: GETBP}
[ 4 -999 4 3 3 2 ]{49: CSTI 0}
[ 4 -999 4 3 3 2 0 ]{51: ADD}
[ 4 -999 4 3 3 2 ]{52: LDI}
[ 4 -999 4 3 3 4 ]{53: LT}
[ 4 -999 4 3 1 ]{54: IFNZRO 18}
[ 4 -999 4 3 ]{18: GETBP}
[ 4 -999 4 3 2 ]{19: CSTI 1}
[ 4 -999 4 3 2 1 ]{21: ADD}
[ 4 -999 4 3 3 ]{22: LDI}
[ 4 -999 4 3 3 ]{23: PRINTI}
3 [ 4 -999 4 3 3 ]{24: INCSP -1}
[ 4 -999 4 3 ]{26: GETBP}
[ 4 -999 4 3 2 ]{27: CSTI 1}
[ 4 -999 4 3 2 1 ]{29: ADD}
[ 4 -999 4 3 3 ]{30: GETBP}
[ 4 -999 4 3 3 2 ]{31: CSTI 1}
[ 4 -999 4 3 3 2 1 ]{33: ADD}
[ 4 -999 4 3 3 3 ]{34: LDI}
[ 4 -999 4 3 3 3 ]{35: CSTI 1}
[ 4 -999 4 3 3 3 1 ]{37: ADD}
[ 4 -999 4 3 3 4 ]{38: STI}
[ 4 -999 4 4 4 ]{39: INCSP -1}
[ 4 -999 4 4 ]{41: INCSP 0}
[ 4 -999 4 4 ]{43: GETBP}
[ 4 -999 4 4 2 ]{44: CSTI 1}
[ 4 -999 4 4 2 1 ]{46: ADD}
[ 4 -999 4 4 3 ]{47: LDI}
[ 4 -999 4 4 4 ]{48: GETBP}
[ 4 -999 4 4 4 2 ]{49: CSTI 0}
[ 4 -999 4 4 4 2 0 ]{51: ADD}
[ 4 -999 4 4 4 2 ]{52: LDI}
[ 4 -999 4 4 4 4 ]{53: LT}
[ 4 -999 4 4 0 ]{54: IFNZRO 18}
[ 4 -999 4 4 ]{56: INCSP -1}
[ 4 -999 4 ]{58: RET 0}
[ 4 ]{4: STOP}
```

</br>

## Exercise 8.3

**Modify the compiler (function `cExpr`) to generate code for `PreInc(acc)` and `PreDec(acc)`.**

**To parse micro-C source programs containing these expressions, you need to modify the lexer and parser.**

`e` should be computed only once.

For instance, `++i` should compile to something like this:

```fsharp
<code to compute address of i>, DUP, LDT, CSTI 1, ADD, STI
```

where the address of `i` is computed once and then duplicated.

Go to directory `MicroC` and see file `Comp.fs` for modified code.

**Write a program to check that this works.**

Go to directory `8.3` and see file `tests.c` for program.

First compile the program:

```fsharp
> open ParseAndComp;;
> compile "../8.3/tests";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L7"); STOP; Label "L1"; GETBP; CSTI 0; ADD; DUP; LDI;
   CSTI 1; ADD; STI; PRINTI; INCSP -1; CSTI 10; PRINTC; INCSP -1; INCSP 0;
   RET 0; Label "L2"; GETBP; CSTI 0; ADD; DUP; LDI; CSTI 1; SUB; STI; PRINTI;
   INCSP -1; CSTI 10; PRINTC; INCSP -1; INCSP 0; RET 0; Label "L3"; INCSP 1;
   GETSP; CSTI 0; SUB; GETBP; CSTI 2; ADD; LDI; CSTI 0; ADD; GETBP; CSTI 0;
   ADD; LDI; STI; INCSP -1; GETBP; CSTI 2; ADD; LDI; CSTI 0; ADD; DUP; LDI;
   CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 2; ADD; LDI; CSTI 0; ADD; LDI;
   PRINTI; INCSP -1; CSTI 10; PRINTC; INCSP -1; INCSP -2; RET 0; Label "L4";
   INCSP 1; GETSP; CSTI 0; SUB; GETBP; CSTI 2; ADD; LDI; CSTI 0; ADD; GETBP;
   CSTI 0; ADD; LDI; STI; INCSP -1; GETBP; CSTI 2; ADD; LDI; CSTI 0; ...]
```

Then run program with `Machine.java`:

```java
java Machine ../8.3/tests.out 3
4 
2 
4 
2 
5 
7 

Ran 0.018 seconds
```

</br>

## Exercise 8.4

**Compile `ex8.c` and study the symbolic bytecode to see why it is so much slower then the handwritten 20 million iterations loop in `prog1`.**

```fsharp
> open ParseAndComp;;
> compile "ex8";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 20000000; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 0; ADD;
   GETBP; CSTI 0; ADD; LDI; CSTI 1; SUB; STI; INCSP -1; INCSP 0; Label "L3";
   GETBP; CSTI 0; ADD; LDI; IFNZRO "L2"; INCSP -1; RET -1]
```

```txt
[LDARGS; CALL (0, "L1"); STOP; 
Label "L1";                                     // main()
   INCSP 1; GETBP; CSTI 0; ADD;                 // int i;
   CSTI 20000000; STI; INCSP -1;                // i = 20000000
   GOTO "L3"; 
Label "L2"; 
   GETBP; CSTI 0; ADD;                          // loads address of i
   GETBP; CSTI 0; ADD; LDI;                     // loads value of i
   CSTI 1; SUB; STI; INCSP -1;                  // i = i - 1
   INCSP 0;                                     
Label "L3";
   GETBP; CSTI 0; ADD; LDI; IFNZRO "L2";        // while(i)
   INCSP -1; RET -1]                            // program ends
```

```java
java Machine ex8.out           

Ran 0.435 seconds

java Machine prog1  

Ran 0.113 seconds
```

The execution of `ex8.out` is slower than `prog1` because each iteration involves more instructions and possibly redundant operations.
Therefore, the symbolic bytecode for `ex8.c` includes additional steps not present in the handwritten `prog1`, leading to the observed performance gap.

**Compile `ex13.c` and study the symbolic bytecode to see how loops and conditionals interact; describe what you see.**

```fsharp
> open ParseAndComp;;
> compile "ex13";; 
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 1889; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; GETBP;
   CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 1; ADD; LDI;
   CSTI 4; MOD; CSTI 0; EQ; IFZERO "L7"; GETBP; CSTI 1; ADD; LDI; CSTI 100;
   MOD; CSTI 0; EQ; NOT; IFNZRO "L9"; GETBP; CSTI 1; ADD; LDI; CSTI 400; MOD;
   CSTI 0; EQ; GOTO "L8"; Label "L9"; CSTI 1; Label "L8"; GOTO "L6";
   Label "L7"; CSTI 0; Label "L6"; IFZERO "L4"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GOTO "L5"; Label "L4"; INCSP 0; Label "L5"; INCSP 0;
   Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
   IFNZRO "L2"; INCSP -1; RET 0]
```

```txt
LDARGS
CALL (1, "L1")
STOP 
L1: 
   INCSP 1
   GETBP
   CSTI 1
   ADD
   CSTI 1889
   STI
   INCSP -1
   GOTO "L3" 
L2:
   GETBP
   CSTI 1
   ADD
   GETBP
   CSTI 1
   ADD
   LDI
   CSTI 1
   ADD
   STI
   INCSP -1
   GETBP
   CSTI 1
   ADD
   LDI
   CSTI 4
   MOD
   CSTI 0
   EQ
   IFZERO "L7"
   GETBP
   CSTI 1
   ADD
   LDI
   CSTI 100
   MOD
   CSTI 0
   EQ
   NOT
   IFNZRO "L9"
   GETBP
   CSTI 1
   ADD
   LDI
   CSTI 400
   MOD
   CSTI 0
   EQ
   GOTO "L8" 
L9:
   CSTI 1
   Label "L8"
   GOTO "L6"
L7:
   CSTI 0
   Label "L6"
   IFZERO "L4"
   GETBP
   CSTI 1    
   ADD
   LDI
   PRINTI
   INCSP -1
   GOTO "L5" 
L4:
   INCSP 0
L5:
   INCSP 0
L3:
   GETBP
   CSTI 1
   ADD
   LDI
   GETBP
   CSTI 0
   ADD
   LDI 
   LT
   IFNZRO "L2"
   INCSP -1
   RET 0
```

This bytecode uses conditional jumps, `IFZERO` and `IFNZRO`, to handle the while-loop and the if-statement.
Labels like, `L2` `L3` `L7`, allow for organised handling of the nested conditions and loop continuation.

</br>

## Exercise 8.5

**Extend the micro-C language, *the abstract syntax*, *the lexer*, *the parser*, and *the compiler* to implement conditional expressions of the form `(e1 ? e2 : e3)`.**

Go to directory `MicroC` and see files `Absyn.fs`, `CLex.fsl`, `CPar.fsy` and `Comp.fs` for answer.

```fsharp
> open ParseAndComp;;
> compile "../8.5/ternary";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 2; CSTI 3; EQ; IFZERO "L2"; CSTI 4; GOTO "L3"; Label "L2"; CSTI 5;
   Label "L3"; STI; INCSP -1; GETBP; CSTI 0; ADD; LDI; PRINTI; INCSP -1;
   CSTI 10; PRINTC; INCSP -1; INCSP -1; RET -1]
```

```java
java Machine ../8.5/ternary.out
5 

Ran 0.019 seconds
```

</br>

## Exercise 8.6

**Extend the *lexer*, *parser*, *abstract syntax*, and *compiler* to implement `switch` statements such as this one:**

```fsharp
switch (month) {
  case 1:
    { days = 31; }
  case 2:
    { days = 28; if (y%4==0) days = 29; }
  case 3:
    { days = 31; }
}
```

There should be no fall-through from one `case` to the next:

- After the last statement of a `case`, the code should jump to the end of the `switch` statement.
- The parenthesis after `switch` must contain an expression.
- The value after a `case` must be an integer constant, and a case must be followed by a statement block.
- A `switch` with `n` cases can be compiled using `n` labels, the last of which is at the very end of the `switch`.
- Do not implement the `break` statement or the `default` branch.

Go to directory `MicroC` and see files `Absyn.fs`, `CLex.fsl`, `CPar.fsy` and `Comp.fs` for answer.

```fsharp

```

```java

```

</b>

---
