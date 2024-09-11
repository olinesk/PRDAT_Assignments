# Assignment 2

All non-code answers are in this file.

</br>

---

dotnet fslex.dll --unicode ../BPRD-02-OKRE-PEKP/Assignment2/Expr/ExprLex.fsl

dotnet fsyacc.dll --module ExprPar ../BPRD-02-OKRE-PEKP/Assignment2/Expr/ExprPar.fsy

## PLC 2.5 - DONE + 2.4

Has already been done and simply just compile provided `Machine.java` and run:
```% javac Machine.java```
```% java Machine is1.txt```

</br>

## PLC 3.2

Write a regular expression that recognises all sequences consisting of *a* and *b* where two *a*'s are always seperated by at least one *b*.
For instance, these four strings are legal: *b*, *a*, *ba*, *ababbbaba*; but these two strings are illegal: *aa*, *babaa*.

**Answer:** `b*(ab*|b)*`

`b*` any sequence of *b*'s.
`(ab*|b)*`
   `ab*` any sequence of *a* followed by zero or more *b*'s.
   `b` standalone *b*.
`*` repeats pattern.

Construct the corresponding NFA. Try to find a DFA corresponding to the NFA.

**NFA:**

**DFA:**

</br>

## HelloLex Question 1 - DONE

Read the specification `hello.fsl`.
What are the regular expressions involved, and which semantic values are they associated with?

**Answer:**
The regular expressions invovled are: `['0'-'9']`.
The semantic value is a single digit number between 0-9.

</br>

## HelloLex Question 2

Generate the lexer out of the specification using a command prompt. 
Which additional file is generated during the process?

**Answer:**
`hello.fs`

How many states are there by the automation of the lexer?

**Answer:**
3 states.

</br>

## HelloLex Question 3

Compile and run the generated program `hello.fs`from question 2.

**Answer:**
The program is run with `dotnet run`.

</br>

## HelloLex Question 4

Extend the lexer specification `hello.fsl`to recognise numbers of more than one digit.
New lexer specification is `hello2.fsl`.
Generate `hello2.fs`, compile and run the generated program.

**Answer:**
The program is run with `dotnet run`.

</br>

## HelloLex Question 5

Extend the lexer specification `hello2.fsl`to recognise numbers of more than one digit.
New lexer specification is `hello3.fsl`.
Generate `hello3.fs`, compile and run the generated program.

Hint: You can use the regular expression `[+-]?([0-9]*[.])?[0-9]+` to recognize floats.

**Answer:**
The program is run with `dotnet run`.

</br>

## HelloLex Question 6

Consider the 3 examples of input provided at the prompt and the result.

```fsharppc
% dotnet bin/Debug/net8.0/hello3.dll
Hello World from FSLex!

Please pass a digit:
34
The lexer recognises 34

% dotnet bin/Debug/net8.0/hello3.dll
Hello World from FsLex!

Please pass a digit:
34.24
The lexer recognises 34.24

% dotnet bin/Debug/net8.0/hello3.dll
Hello World from FsLex!

Please pass a digit:
34,34
The lexer recognises 34
%
```

Explain why the results are expected behaviour from the lexer.

**Answer:**

</b>

---
