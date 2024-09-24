# Assignment 2

All non-code answers are in this file.

</br>

---

## Exercise 4.1

Generate and compile the lexer and parser as described in `README.TXT`; parse and run some example programs with `ParseAndRun.fs`.

</br>

## Exercise 4.2

**Write more example programs in the functional language, and test them:**

- Compute the sum of the numbers from 1000 down to 1.

- Compute the number $3^8$, that is, 3 raised to the power 8.

- Compute $3^0+3^1+...+3^{10}+3^{11}$, using a recursive function (or two, if you prefer).

- Compute $1^8+2^8+...+10^8$, using a recursive function (or two).

</br>

## Exercise 4.3

**Modify the language to allow function to take one or more arguments.**

Start by modifying the abstract syntax in `Absyn.fs` to permit a list of parameter names in `Letfun` and a list of argument expressions in `Call`.

Then modify the eval interpreter in file `Fun.fs` to work for the new abstract syntax.

- Modify the closure representation to accommodate a list of parameters.
- Modify the `Letfun` and `Call` clauses of the interpreter.
  Hint: Function `List.zip` might be useful.

</br>

## Exercise 4.4

**Modify the parser specification to accept a language where functions may take any (non-zero) number of arguments.**
The resulting parser should permit function declarations such as these:

```fsharppc
let pow x n = if n = 0 then 1 else x * pow x (n - 1) in pow 3 8 end

let max2 a b = if a < b then b else a
in let max3 a b c = max2 a (max2 b c)
    in max3 25 6 62 end
end
```

</br>

## Exercise 4.5

**Extend the (untyped) functional language with infix operator "&&" and "||".**

</b>

---
