# Assignment 7

All non-code answers are in this file.

</br>

---

## Exercise 8.1

**(i) Compile one of the micro-C examples provided, such as that in source file `ex11.c`, then run it using the abstract machine implemented in Java.**

**When run with command line argument 8, the program prints the 92 solutions to the eight queens problem: how to place eight queens on a chessboard so that none of them can attack any of the others.**

**(ii) Compile the example micro-C programs `ex3.c` and `ex5.c` using functions `compileToFile` and `fromFile` from `ParseAndComp.fs`.**

**Study the generated symbolic bytecode.**

**Write up the bytecode in a more structured way with labels only at the beginning of the line.**

**Write the corresponding micro-C code to the right of the stack machine code.**

Note that `ex5.c` has a nested scope (a block ... inside a function body); how is that visible in the generated code?

**Trace the execution using `java Machinetrace ex3.out 4`, and explain the stack contents and what goes on in each step of execution, and especialle how the low-level bytecode instructions map to the higher-level features of MicroC.**

You can capture the standard output from a command prompt (in a file `ex3trace.txt`) using the Unix-style notation:

```fsharp
java Machinetrace ex3.out 4 > ex3trace.txt
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

**Write a program to check that this works.**

Try it on expressions of the form `++arr[++i]` and check that `i` and the elements of `arr` have the correct values afterwards.

</br>

## Exercise 8.4

**Compile `ex8.c` and study the symbolic bytecode to see why it is so much slower then the handwritten 20 million iterations loop in `prog1`.**

**Compile `ex13.c` and study the symbolic bytecode to see how loops and conditionals interact; describe what you see.**

</br>

## Exercise 8.5

**Extend the micro-C language, *the abstract syntax*, *the lexer*, *the parser*, and *the compiler* to implement conditional expressions of the form `(e1 ? e2 : e3)`.**

The compilation of `e1 ? e2 : e3` should produce code that evaluates `e2` only if `e1` is true and evaluates `e3` only if `e1` is false.

The compilation scheme should be the same as for the conditional statement `if (e) stmt1 else stmt2`, but expression `e2` or expression `e3` must leave its value on the stack top if evaluated, so that the entire expressions `e1 ? e2 : e3` leaves its value on the stack top.

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

</b>

---
