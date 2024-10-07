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

See file `mergesort.java` in directory `Exercise5_1` for answer.

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

See file `TypedFun.fs` in directory `TypedFun` for answer.

</br>

## Exercise 6.1

**Build the micro-ML higher-order evaluator as described in file `README.TXT` point E.**
**Then run the evaluator on the following four programs:**

**1.**

```fsharp
let add x = let f y = x + y in f end
in add 2 5 end
```

```fsharp
> open ParseAndRunHigher;;
> run (fromString @"let add x = let f y = x + y in f end
- in add 2 5 end");;
val it: HigherFun.value = Int 7
```

**2.**

```fsharp
let add x = let f y = x + y in f end
in let addtwo = add 2
    in addtwo 5 end
end
```

```fsharp
> open ParseAndRunHigher;;
> run (fromString @"let add x = let f y = x + y in f end
- in let addtwo = add 2
-     in addtwo 5 end
- end");;
val it: HigherFun.value = Int 7
```

**3.**

```fsharp
let add x = let f y = x + y in f end
in let addtwo = add 2
    in let x = 77 in addtwo 5 end
    end
end
```

```fsharp
> open ParseAndRunHigher;;
> run (fromString @"let add x = let f y = x + y in f end
- in let addtwo = add 2
-     in let x = 77 in addtwo 5 end
-     end
- end");;
val it: HigherFun.value = Int 7
```

**Is the result as expected?**

Yes since the inner binding of `x = 77` is never used, because the returned function must enclose the value of `f`'s free variable `x`.

**4.**

```fsharp
let add x = let f y = x + y in f end
in add 2 end
```

```fsharp
> open ParseAndRunHigher;;
> run (fromString @"let add x = let f y = x + y in f end
- in add 2 end");;
val it: HigherFun.value =
  Closure
    ("f", "y", Prim ("+", Var "x", Var "y"),
     [("x", Int 2);
      ("add",
       Closure
         ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"),
          []))])
```

**Explain why the result is different:**

The result is the return of a partial application of a function.

</br>

## Exercise 6.2

**Add anonymous functions to the micro-ML higher-order functional language abstract syntax:**

```fsharp
type expr =
     ...
    | Fun of string * expr
    | ...
```

For instance, these two expressions in concrete syntax:

```fsharp
fun x -> 2 * x
let y = 22 in fun z -> z + y end
```

should parse to these expressions in abstract syntax:

```fsharp
Fun("x", Prim("*", CstI 2, Var "x"))
Let("y", CstI 22, Fun("z", Prim("+", Var "z", Var "y")))
```

Evaluation of a `Fun(...)` should produce a non-recursive closure of the form

```fsharp
type value =
    | ...
    | Clos of string * expr * value env     (* (x, body, declEnv) *)
```

In the empty environment the two expressions shown above should evaluate to these two closure values:

```fsharp
Clos("x", Prim("*", CstI 2, Var "x"), [])
Clos("z", Prim("+", Var "z", Var "y"), [(y, 22)])
```

**Extend the evaluator `eval` in file `HigherFun.fs` to interpret such anonymous functions.**

See files `HigherFun.fs` and `Absyn.fs` in directory `Fun` for answers.

</br>

## Exercise 6.3

**Extend the micro-ML lexer and parser specifications in `FunLex.fsl` and `FunPar.fsy` to permit anonymous functions.**

See files `FunLex.fsl` and `FunPar.fsy` in directory `Fun` for answers.

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

**1.**

```fsharp
let f x = 1
in f f end
```

```fsharp
> open ParseAndType;;
> inferType (fromString "let f x = 1
- in f f end");;
val it: string = "int"
```

**2.**

```fsharp
let f g = g g
in f end
```

```fsharp
> open ParseAndType;;
> inferType (fromString "let f g = g g
- in f end");;
System.Exception: type error: circularity
```

The type definition of `g g` is infinitely recursive, so the type inference never stops infering to the type.

**3.**

```fsharp
let f x =
    let g y = y
    in g false end
in f 42 end
```

```fsharp
> open ParseAndType;;
> inferType (fromString "let f x =
-     let g y = y
-     in g false end
- in f 42 end");;
val it: string = "bool"
```

**4.**

```fsharp
let f x = 
    let g y = if true then y else x
    in g false end
in f 42 end
```

```fsharp
> open ParseAndType;;
> inferType (fromString "let f x = 
-     let g y = if true then y else x
-     in g false end
- in f 42 end");;
System.Exception: type error: bool and int
```

The if-statement doesn't return the same type.

**5.**

```fsharp
let f x =
    let g y = if true then y else x
    in g false end
in f true end
```

```fsharp
> open ParseAndType;;
> inferType (fromString "let f x =
-     let g y = if true then y else x
-     in g false end
- in f true end");;
val it: string = "bool"
```

**(2) Write micro-ML programs for which the micro-ML type inference report the following types:**

- **`bool -> bool`**

```fsharp
let f x = if x then true else false in f end

> open ParseAndType;;
> inferType (fromString "let f x = if x then true else false in f end");;
val it: string = "(bool -> bool)"
```

- **`int -> int`**

```fsharp
let f x = x + x in f end

> open ParseAndType;;
> inferType (fromString "let f x = x + x in f end");;
val it: string = "(int -> int)"
```

- **`int -> int -> int`**

```fsharp
let f x = 
    let g y = x + y 
    in g end 
in f end

> open ParseAndType;;
> inferType (fromString "let f x = 
-     let g y = x + y 
-     in g end 
- in f end");;
val it: string = "(int -> (int -> int))"
```

- **`´a -> ´b -> ´a`**

```fsharp
let f x = 
    let g y = x
    in g end
in f end

> open ParseAndType;;
> inferType (fromString "let f x = 
-     let g y = x
-     in g end
- in f end");;
val it: string = "('h -> ('g -> 'h))"
```

- **`´a -> ´b -> ´b`**

```fsharp
let f x =
    let g y = y
    in g end
in f end

> open ParseAndType;;
> inferType (fromString "let f x =
-     let g y = y
-     in g end
- in f end");;
val it: string = "('g -> ('h -> 'h))"
```

- **`(´a -> ´b) -> (´b -> ´c) -> (´a -> ´c)`**

```fsharp
let f x = 
    let g y =
        let h z = y (x z)
        in h end
    in g end
in f end

> open ParseAndType;;
> inferType (fromString "let f x = 
-     let g y =
-         let h z = y (x z)
-         in h end
-     in g end
- in f end");;
val it: string = "(('l -> 'k) -> (('k -> 'm) -> ('l -> 'm)))"
```

- **`´a -> ´b`**

```fsharp
let f x = f x in f end

> open ParseAndType;;
> inferType (fromString "let f x = f x in f end");;
val it: string = "('e -> 'f)"
```

- **`´a`**

```fsharp
let f x = f x in f x end

> open ParseAndType;;
> inferType (fromString "let f x = f 0 in f 0 end");;
val it: string = "'e"
```

</b>

---
