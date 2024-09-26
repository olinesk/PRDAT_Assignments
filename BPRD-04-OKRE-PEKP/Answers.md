# Assignment 2

All non-code answers are in this file.

</br>

---

## Exercise 4.1

Generate and compile the lexer and parser as described in `README.TXT`; parse and run some example programs with `ParseAndRun.fs`.

**A. Loading the micro-ML evaluator, with abstract syntax only:**

```fsharp
> open Absyn;;
> open Fun;;  
> let res = run (Prim("+", CstI 5, CstI 7));;
val res: int = 12
```

**B. Generating and compiling the lexer and parser, and loading them:**

```fsharp
> open Parse;;
> let e1 = fromString "5+7";;
val e1: Absyn.expr = Prim ("+", CstI 5, CstI 7)

> let e2 = fromString "let y = 7 in y + 2 end";;
val e2: Absyn.expr = Let ("y", CstI 7, Prim ("+", Var "y", CstI 2))

> let e3 = fromString "let f x = x + 7 in f 2 end";;
val e3: Absyn.expr =
  Letfun ("f", "x", Prim ("+", Var "x", CstI 7), Call (Var "f", CstI 2))
```

**C. Using the lexer, parser and first-order evaluator together:**

```fsharp
> open ParseAndRun;;
> run (fromString "5+7");;
val it: int = 12

> run (fromString "let y = 7 in y + 2 end");;
val it: int = 9

> run (fromString "let f x = x + 7 in f 2 end");;
val it: int = 9
```

</br>

## Exercise 4.2

**Write more example programs in the functional language, and test them:**

- Compute the sum of the numbers from 1000 down to 1.

``` fsharp
let sum n = if n then (n + sum(n - 1)) else n in sum 1000 end`
```

``` fsharp
> open ParseAndRun;;
> run (fromString "let sum n = if n then (n + sum(n - 1)) else n in sum 1000 end");;
val it: int = 500500
```

- Compute the number $3^8$, that is, 3 raised to the power 8.

``` fsharp
let threePowE n = if n < 1 then 1 else 3 * (threePowE(n - 1)) in threePowE 8 end
```

``` fsharp
> open ParseAndRun;;
> run (fromString "let threePowE n = if n < 1 then 1 else 3 * (threePowE(n - 1)) in threePowE 8 end");;
val it: int = 6561
```

- Compute $3^0+3^1+...+3^{10}+3^{11}$, using a recursive function (or two, if you prefer).

``` fsharp
let threePowE x = 
    if x < 1 then 1 else 3 * (threePowE (x - 1))
in
    let sum n =
        if n then (threePowE n) + (sum(n - 1)) else n + 1 
    in 
        sum 11
    end
end
```

``` fsharp
> open ParseAndRun;;
> run (fromString "let threePowE x = 
-     if x < 1 then 1 else 3 * (threePowE (x - 1))
- in
-     let sum n =
-         if n then (threePowE n) + (sum(n - 1)) else n + 1 
-     in 
-         sum 11
-     end
- end");;
val it: int = 265720
```

- Compute $1^8+2^8+...+10^8$, using a recursive function (or two).

``` fsharp
let powE x = 
    if x < 1 then 1 else x * (powE (x - 1))
in
    let sum n = 
        if n then (
            let powSum p = 
                if p < 1 then 1 else n * (powSum (p - 1)) 
            in 
                powSum 8 
            end
        ) + (sum(n - 1)) else n
    in
        sum 10
    end
end
```

``` fsharp
> open ParseAndRun
> run (fromString "let powE x = 
-     if x < 1 then 1 else x * (powE (x - 1))
- in
-     let sum n = 
-         if n then (
-             let powSum p = 
-                 if p < 1 then 1 else n * (powSum (p - 1)) 
-             in 
-                 powSum 8 
-             end
-         ) + (sum(n - 1)) else n
-     in
-         sum 10
-     end
- end");;
val it: int = 167731333
```

</br>

## Exercise 4.3

**Modify the language to allow function to take one or more arguments.**

Look at files `Absyn.fs` and `Fun.fs` for answers.

</br>

## Exercise 4.4

**Modify the parser specification to accept a language where functions may take any (non-zero) number of arguments.**
The resulting parser should permit function declarations such as these:

```fsharp
let pow x n = if n = 0 then 1 else x * pow x (n - 1) in pow 3 8 end

let max2 a b = if a < b then b else a
in let max3 a b c = max2 a (max2 b c)
    in max3 25 6 62 end
end
```

See file `FunPar.fsy` for answer.

```fsharp
> open Parse;;
> open ParseAndRun;;
> fromString "let pow x n = if n = 0 then 1 else x * pow x (n - 1) in pow 3 8 end";;
val it: Absyn.expr =
  Letfun
    ("pow", ["x"; "n"],
     If
       (Prim ("=", Var "n", CstI 0), CstI 1,
        Prim
          ("*", Var "x",
           Call (Var "pow", [Var "x"; Prim ("-", Var "n", CstI 1)]))),
     Call (Var "pow", [CstI 3; CstI 8]))

> run (fromString "let pow x n = if n = 0 then 1 else x * pow x (n - 1) in pow 3 8 end");;
val it: int = 6561

> fromString "let max2 a b = if a < b then b else a
- in let max3 a b c = max2 a (max2 b c)
-     in max3 25 6 62 end
- end";;
val it: Absyn.expr =
  Letfun
    ("max2", ["a"; "b"], If (Prim ("<", Var "a", Var "b"), Var "b", Var "a"),
     Letfun
       ("max3", ["a"; "b"; "c"],
        Call (Var "max2", [Var "a"; Call (Var "max2", [Var "b"; Var "c"])]),
        Call (Var "max3", [CstI 25; CstI 6; CstI 62])))

> run (fromString "let max2 a b = if a < b then b else a
- in let max3 a b c = max2 a (max2 b c)
-     in max3 25 6 62 end
- end");;
val it: int = 62
```

</br>

## Exercise 4.5

**Extend the (untyped) functional language with infix operator "&&" and "||".**

See files `FunPar.fsy` and `FunLex.fsl` for answer.

</b>

---
