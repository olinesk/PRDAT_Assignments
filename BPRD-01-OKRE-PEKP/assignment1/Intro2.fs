(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [ ("a", 3); ("c", 78); ("baf", 666); ("b", 111) ]

let emptyenv = [] (* the empty environment *)

let rec lookup env x =
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

let cvalue = lookup env "c"


(* Object language expressions with variables *)

type expr =
    | CstI of int
    | Var of string
    | Prim of string * expr * expr
    (* Exercise 1.1 (iv) Extend the expression language with conditional expressions. *)
    | If of expr * expr * expr

let e1 = CstI 17

let e2 = Prim("+", CstI 3, Var "a")

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")

(* Exercise 1.1 (ii) Example expressions using abstract syntax (evaluated with the other examples further down). *)

let e4 = Prim("max", CstI 4, Prim("min", CstI 6, Prim("==", CstI 3, CstI 3)))

let e5 = Prim("min", CstI 5, Var "a")

let e6 = If(Var "a", CstI 11, CstI 22)

(* Evaluation within an environment *)

let rec eval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    (* Exercise 1.1 (i) Adding the three additional operators to the Prim constructor. *)
    | Prim("max", e1, e2) -> max (eval e1 env) (eval e2 env)
    | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2) -> if (eval e1 env) = (eval e2 env) then 1 else 0
    | Prim _ -> failwith "unknown primitive"
    (* Exercise 1.1 (v) Extending the interpreter function eval correspondingly. *)
    | If(e1, e2, e3) -> if (eval e1 env) <> 0 then eval e2 env else eval e3 env

(* Exercise 1.1 (iii) Rewrite one of the eval functions to evaluate the arguments of a primitive. *)

let rec eval2 e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Prim(ope, e1, e2) ->
        let i1 = eval2 e1 env
        let i2 = eval2 e2 env

        match ope with
        | "+" -> i1 + i2
        | "*" -> i1 * i2
        | "-" -> i1 - i2
        | "max" -> max i1 i2
        | "min" -> min i1 i2
        | "==" -> if i1 = i2 then 1 else 0
        | _ -> failwith "unknown primitive"
    (* Exercise 1.1 (v) Extending the extra interpreter function eval2 correspondingly. *)
    | If(e1, e2, e3) ->
        let cond = eval2 e1 env
        if cond <> 0 then eval2 e2 env else eval2 e3 env


let e1v = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [ ("a", 314) ]
let e3v = eval e3 env
let e4v = eval e4 env
let e5v = eval e5 env
let e6v = eval e6 env
let e6v2 = eval e6 [ ("a", 0) ]
let e6v3 = eval e6 [ ("a", -3) ]


(* Exercise 1.2 (i) Declare an alternative datatype aexpr for a representation of arithmetic expressions. *)
type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr

(* Exercise 1.3 (ii) Write the representation of the expressions. *)

// v − (w + z)

let a1 = Sub(Var "v", Add(Var "w", Var "z"))

// 2 ∗ (v − (w + z))

let a2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))

// x + y + z + v

let a3 = Add(Add(Var "x", Var "y"), Add(Var "z", Var "v"))

(* Exercise 1.2 (iii) Write an F# function fmt : aexpr -> string to format expressions as strings. *)

let rec fmt a =
    match a with
    | CstI i -> string i
    | Var x -> x
    | Add(a1, a2) -> "(" + fmt a1 + " + " + fmt a2 + ")"
    | Mul(a1, a2) -> "(" + fmt a1 + " * " + fmt a2 + ")"
    | Sub(a1, a2) -> "(" + fmt a1 + " - " + fmt a2 + ")"

let a1v = fmt a1
let a2v = fmt a2
let a3v = fmt a3

(* Exercise 1.2 (iv) Write an F# function simplify : aexpr -> aexpr to perform expres- sion simplification. *)

let rec simplify a =
    match a with
    | Add(CstI 0, a1) -> simplify a1
    | Add(a1, CstI 0) -> simplify a1
    | Sub(a1, CstI 0) -> simplify a1
    | Mul(CstI 1, a1) -> simplify a1
    | Mul(a1, CstI 1) -> simplify a1
    | Mul(CstI 0, _) -> CstI 0
    | Mul(_, CstI 0) -> CstI 0
    | Mul(_, _) -> CstI 0
    | Add(a1, a2) ->
        let simpa1 = simplify a1
        let simpa2 = simplify a2

        match (simpa1, simpa2) with
        | (CstI 0, _) -> simpa2
        | (_, CstI 0) -> simpa1
        | (CstI x, CstI xs) -> CstI(x + xs)
        | _ -> Add(simpa1, simpa2)
    | Sub(a1, a2) ->
        let simpa1 = simplify a1
        let simpa2 = simplify a2

        match (simpa1, simpa2) with
        | (_, CstI 0) -> simpa1
        | (CstI x, CstI xs) -> CstI(x - xs)
        | _ -> Sub(simpa1, simpa2)
    | _ -> a

(* Exercise 1.2 (v) Write an F# function to perform symbolic differentiation of simple arithmetic expressions (such as aexpr) 
  with respect to a single variable. *)

let rec diff a v =
    match a with
    | CstI i -> CstI i
    | Var x -> if x = v then CstI 1 else CstI 0
    | Add(a1, a2) -> Add(diff a1 v, diff a2 v)
    | Mul(a1, a2) -> Add(Mul(diff a1 v, a2), Mul(a1, diff a2 v))
    | Sub(a1, a2) -> Sub(diff a1 v, diff a2 v)

(* Example expressions. *)

let diff1 = Add(Var "x", CstI 3)
let diff2 = Mul(Var "x", Var "x")
let diff3 = Sub(Mul(CstI 5, Var "x"), CstI 4)
let diff4 = Mul(Add(Var "x", CstI 2), Var "x")

let diff1v = diff diff1 "x" // CstI 1
let diff2v = diff diff2 "x" // Add(Mul(CstI 1, Var "x"), Mul(Var "x", CstI 1)) -> Add(Var "x", Var "x") -> Mul(CstI 2, Var "x")
let diff3v = diff diff3 "x" // CstI 5
let diff4v = diff diff4 "x" // Add(Mul(CstI 1, Var "x"), Mul(Add(Var "x", CstI 2), CstI 1)) -> Add(Var "x", Var "x")
