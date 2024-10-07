# Assignment 5

All non-code answers are in this file.

</br>

---

## Exercise 5.1

**Write functions that merge two sorted lists of integers, creating a new sorted list that contains all the elements of the given lists.**

**(A) Implement an F# function:**

```fsharp
merge : int list * int list -> int list
```

**that takes two sorted lists of integers and merges them into a sorted list of integers.**

Check file `mergesort.fs` in directory `Exercise5_1` for answer.

**(B) Implement a similar Java (or C#) method:**

```java
static int[] merge(int[] xs, int[] ys)
```

**that takes two sorted arrays of ints and merges them into a sorted array of ints.**
**The method should build a new array, and should not modify the given arrays.**

Check file `mergesort.java` in directory `Exercise5_1` for answer.

</br>

## Exercise 5.7

**Extend the monomorphic type checker to deal with lists.**
**Use the following extra kinds of types:**

```fsharp
type typ =
    | ...
    |TypL of typ        (* lists, element type is typ *)
    | ...
```

</br>

## Exercise 6.1

**Build the micro-ML higher-order evaluator as described in file `README.TXT` point E.**
**Then run the evaluator on the following four programs and explain the result of the last one:**

```fsharp
let add x = let f y = x + y in f end
in add 2 5 end
```

```fsharp
let add x = let f y = x + y in f end
in let addtwo = add 2
    in addtwo 5 end
end
```

```fsharp
let add x = let f y = x + y in f end
in let addtwo = add 2
    in let x = 77 in addtwo 5 end
    end
end
```

```fsharp
let add x = let f y = x + y in f end
in add 2 end
```

</br>

## Exercise 6.2

**Add anonymous functions to the micro-ML higher-order functional language abstract syntax:**

```fsharp
type expr =
     ...
    | Fun of string * expr
    | ...
```

**Extend the evaluator `eval` in file `HigherFun.fs` to interpret such anonymous functions.**

</br>

## Exercise 6.3

**Extend the micro-ML lexer and parser specifications in `FunLex.fsl` and `FunPar.fsy` to permit anonymous functions.**

</br>

## Exercise 6.4

**Type rules for ML-polymorphism:**

**(i) Build a type rule tree for this micro-ML program (in the let-body, the type of `f` should be polymorphic - why?):**

```fsharp
let f x = 1
in f f end
```

**(ii) Build a type rule tree for this micro-ML program (in the let-body, the type of `f` should not be polymorphic - why?):**

```fsharp
let f x = if x < 10 then 42 else f(x + 1)
in f 20 end
```

</br>

## Exercise 6.5

**Build the micro-ML higher-order type inference as described in fule `README.TXT` point F.**

**(1) Use the type inference on the micro-ML programs below, and report what type the program has.**
    **Some will fail because the programs are not typable in micro-ML; explain why.**

```fsharp
let f x = 1
in f f end
```

```fsharp
let f g = g g
in f end
```

```fsharp
let f x =
    let g y = y
    in g false end
in f 42 end
```

```fsharp
let f x = 
    let g y = if true then y else x
    in g false end
in f 42 end
```

```fsharp
let f x =
    let g y = if true then y else x
    in g false end
in f true end
```

**(2) Write micro-ML programs for which the micro-ML type inference report the following types:**

- `bool -> bool`
- `int -> int`
- `int -> int -> int`
- `´a -> ´b -> ´a`
- `´a -> ´b -> ´b`
- `(´a -> ´b) -> (´b -> ´c) -> (´a -> ´c)`
- `´a -> ´b`
- `´a`

Remember that the type arrow `(->)` is right associative, so `int -> int -> int` is the same as `int -> (int -> int)`, and that the choice of type variables does not matter, so the type scheme `´h -> ´g -> ´h` is the same as `´a -> ´b -> ´a`. **(REMOVE THIS BEFORE SUBMITTING!!!)**

</b>

---
