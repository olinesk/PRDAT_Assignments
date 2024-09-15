# Assignment 3

All non-code answers are in this file.

</br>

---

## PLC 3.3 - DONE

Write out the rightmost derivation of the string below from the expression grammar at the end of Sect. 3.6.5, corresponding to `ExprPar.fsy`.

Take note of the sequence of grammer rules (A-I) used:

``` fsharppc
Main ::= Expr EOF                         rule A
Expr ::= NAME                             rule B
      |  CSTINT                           rule C
      |  MINUS CSTINT                     rule D
      |  LPAR Expr RPAR                   rule E
      |  LET NAME EQ Expr IN Expr END     rule F
      |  Expr TIMES Expr                  rule G
      |  Expr PLUS  Expr                  rule H
      |  Expr MINUS Expr                  rule I
```

String:

```let z = (17) in z + 2 * 3 end EOF```

**Answer:**

> $\text{Main}$
>
> $\overset{A}\rightarrow \text{\textbf{\textit{Expr} EOF}}$
>
> $\overset{F}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} END EOF}}$
>
> $\overset{G}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} TIMES \textit{Expr} END EOF}}$
>
> $\overset{G}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} * \textit{Expr} END EOF}}$
>
> $\overset{C}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} * CSTINT END EOF}}$
>
> $\overset{C}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} * 3 END EOF}}$
>
> $\overset{H}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} PLUS \textit{Expr} * 3 END EOF}}$
>
> $\overset{H}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} + \textit{Expr} * 3 END EOF}}$
>
> $\overset{C}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} + CSTINT * 3 END EOF}}$
>
> $\overset{C}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN \textit{Expr} + 2 * 3 END EOF}}$
>
> $\overset{B}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN NAME + 2 * 3 END EOF}}$
>
> $\overset{B}\rightarrow \text{\textbf{LET NAME EQ \textit{Expr} IN z + 2 * 3 END EOF}}$
>
> $\overset{E}\rightarrow \text{\textbf{LET NAME EQ LPAR \textit{Expr} RPAR IN z + 2 * 3 END EOF}}$
>
> $\overset{E}\rightarrow \text{\textbf{LET NAME EQ ( \textit{Expr} ) IN z + 2 * 3 END EOF}}$
>
> $\overset{C}\rightarrow \text{\textbf{LET NAME EQ ( CSTINT ) IN z + 2 * 3 END EOF}}$
>
> $\overset{C}\rightarrow \text{\textbf{LET NAME EQ ( 17 ) IN z + 2 * 3 END EOF}}$
>
> $\overset{B}\rightarrow \text{\textbf{LET z EQ ( 17 ) IN z + 2 * 3 END EOF}}$

## PLC 3.4

Draw the above derivation as a tree.

**Answer:**

</b>

---
