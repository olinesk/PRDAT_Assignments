(* Programming language concepts for software developers, 2012-02-17 *)

(* Evaluation, checking, and compilation of object language expressions *)
(* Stack machines for expression evaluation                             *)

(* Object language expressions with variable bindings and nested scope *)

module Intcomp1

type expr =
    | CstI of int
    | Var of string
    (* Exercise 2.1 Extend the expression language expr with multiple sequential let-binding. *)
    | Let of (string * expr) list * expr
    | Prim of string * expr * expr

(* Some closed expressions: *)

let e1 = Let([ ("z", CstI 17) ], Prim("+", Var "z", Var "z"))

let e2 =
    Let([ ("z", CstI 17) ], Prim("+", Let([ ("z", CstI 22) ], Prim("*", CstI 100, Var "z")), Var "z"))

let e3 = Let([ ("z", Prim("-", CstI 5, CstI 4)) ], Prim("*", CstI 100, Var "z"))

let e4 =
    Prim("+", Prim("+", CstI 20, Let([ ("z", CstI 17) ], Prim("+", Var "z", CstI 2))), CstI 30)

let e5 = Prim("*", CstI 2, Let([ ("x", CstI 3) ], Prim("+", Var "x", CstI 4)))

let e6 = Let([ ("z", Var "x") ], Prim("+", Var "z", Var "x"))

let e7 =
    Let([ ("z", CstI 3) ], Let([ ("y", Prim("+", Var "z", CstI 1)) ], Prim("+", Var "z", Var "y")))

let e8 =
    Let([ ("z", Let([ ("x", CstI 4) ], Prim("+", Var "x", CstI 5))) ], Prim("*", Var "z", CstI 2))

let e9 =
    Let([ ("z", CstI 3) ], Let([ ("y", Prim("+", Var "z", CstI 1)) ], Prim("+", Var "x", Var "y")))

let e10 =
    Let([ ("z", Prim("+", Let([ ("x", CstI 4) ], Prim("+", Var "x", CstI 5)), Var "x")) ], Prim("*", Var "z", CstI 2))

(* ---------------------------------------------------------------------- *)

(* Evaluation of expressions with variables and bindings *)

let rec lookup env x =
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

let rec eval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x

    (* Exercise 2.1 Revise the eval interpreter to work for the expr language extended with multiple sequential let-bindings. *)
    | Let(ebindings, ebody) ->
        let newEnv =
            ebindings
            (* Using List.fold to apply bindings sequentially and updating the environment. *)
            |> List.fold
                (* The accumulator is the current environment we are updating.*)
                (fun acc (x, expr) ->
                    (* Evaluating the right side of the expression expr in the current environment. *)
                    let value = eval expr acc
                    (* Updating the environment. *)
                    (x, value) :: acc)
                env
        (* Evaluating the body with the new environment. *)
        eval ebody newEnv

    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _ -> failwith "unknown primitive"

(* For exercise 2.6 we have copied the eval function and made eval2 
    to modify it without modifying our answer for exercise 2.1. *)
let rec eval2 e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x

    (* Exercise 2.6 Modify the interpretation of the language from Exercise 2.1 so 
      that multiple let-bindings are simultaneous rather than sequential. *)
    | Let(ebindings, ebody) ->
        (* Evaluates all the right-hand side expressions. *)
        let evaluatedBindings = ebindings |> List.map (fun (x, expr) -> (x, eval2 expr env))

        (* Binds the variables simultaneously to their evaluated values. *)
        let newEnv = evaluatedBindings @ env
        (* Evaluates the body with the new environment. *)
        eval2 ebody newEnv

    | Prim("+", e1, e2) -> eval2 e1 env + eval2 e2 env
    | Prim("*", e1, e2) -> eval2 e1 env * eval2 e2 env
    | Prim("-", e1, e2) -> eval2 e1 env - eval2 e2 env
    | Prim _ -> failwith "unknown primitive"

let run e = eval e []
let res = List.map run [ e1; e2; e3; e4; e5; e7 ] (* e6 has free variables *)

let run2 e = eval2 e []
let res2 = List.map run2 [ e1; e2; e3; e4; e5; e7 ]

(* ---------------------------------------------------------------------- *)

(* Closedness *)

// let mem x vs = List.exists (fun y -> x=y) vs;;

let rec mem x vs =
    match vs with
    | [] -> false
    | v :: vr -> x = v || mem x vr

(* Checking whether an expression is closed.  The vs is 
   a list of the bound variables.  *)
(*
let rec closedin (e: expr) (vs: string list) : bool =
    match e with
    | CstI i -> true
    | Var x -> List.exists (fun y -> x = y) vs
    //    | Let(x, erhs, ebody) ->
    //        let vs1 = x :: vs
    //        closedin erhs vs && closedin ebody vs1
    | Prim(ope, e1, e2) -> closedin e1 vs && closedin e2 vs

(* An expression is closed if it is closed in the empty environment *)

let closed1 e = closedin e []
let _ = List.map closed1 [ e1; e2; e3; e4; e5; e6; e7; e8; e9; e10 ]
*)

(* ---------------------------------------------------------------------- *)

(* Free variables *)

(* Operations on sets, represented as lists.  Simple but inefficient;
   one could use binary trees, hashtables or splaytrees for
   efficiency.  *)

(* union(xs, ys) is the set of all elements in xs or ys, without duplicates *)

let rec union (xs, ys) =
    match xs with
    | [] -> ys
    | x :: xr -> if mem x ys then union (xr, ys) else x :: union (xr, ys)

(* minus xs ys  is the set of all elements in xs but not in ys *)

let rec minus (xs, ys) =
    match xs with
    | [] -> []
    | x :: xr -> if mem x ys then minus (xr, ys) else x :: minus (xr, ys)

(* Find all variables that occur free in expression e *)

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x -> [ x ]

    (* Exercise 2.2 Revise freevars to work for the language expr. *)
    | Let(ebindings, ebody) ->
        (* Process each binding sequentially. *)
        let rec processBindings bindSeq acc boundVars =
            match bindSeq with
            | [] -> acc, boundVars
            | (x, expr) :: rest ->
                (* Evaluate the free variables in expr. *)
                let exprFreeVars = freevars expr
                (* Updates the list of free variables. *)
                let newFreeVars = union (exprFreeVars, minus (acc, boundVars))
                (* Updates bound variables. *)
                let newBoundVars = x :: boundVars
                processBindings rest newFreeVars newBoundVars
        (* List of all free variables found in bindings, and list of all bound variables. *)
        let bindingFreeVars, boundVars = processBindings ebindings [] []
        (* Evaluates free variables in body. *)
        let bodyFreeVars = freevars ebody
        (* Combining free variables. *)
        union (bindingFreeVars, minus (bodyFreeVars, boundVars))

    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)


(* Alternative definition of closed *)

(* Checks if expression is closed, i.e. has no free variables. *)
let closed2 e = (freevars e = [])
(* Returns true or false, true if expr is closed else false. *)
let resFreeVars = List.map closed2 [ e1; e2; e3; e4; e5; e6; e7; e8; e9; e10 ]

(* ---------------------------------------------------------------------- *)

(* Compilation to target expressions with numerical indexes instead of
   symbolic variable names.  *)

type texpr = (* target expressions *)
    | TCstI of int
    | TVar of int (* index into runtime environment *)
    | TLet of texpr * texpr (* erhs and ebody                 *)
    | TPrim of string * texpr * texpr


(* Map variable name to variable index at compile-time *)

let rec getindex vs x =
    match vs with
    | [] -> failwith "Variable not found"
    | y :: yr -> if x = y then 0 else 1 + getindex yr x

(* Compiling from expr to texpr *)

let rec tcomp (e: expr) (cenv: string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x -> TVar(getindex cenv x)

    (* Exercise 2.3 Revise the expr-to-texpr compiler tcomp to work for the extended expr language. *)
    | Let(ebindings, ebody) ->
        let rec compileBindings bindSeq cenv =
            match bindSeq with
            | [] -> tcomp ebody cenv
            | (x, expr) :: rest ->
                (* Compiles the expr in the current compile-time environment. *)
                let compiledExpr = tcomp expr cenv
                (* Extends the compile-time environment. *)
                let newCenv = x :: cenv
                (* Each binding is compiled into a TLet expression. *)
                TLet(compiledExpr, compileBindings rest newCenv)
        (* Compiles each binding and extends the environment. *)
        compileBindings ebindings cenv

    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv)


(* Evaluation of target expressions with variable indexes.  The
   run-time environment renv is a list of variable values (ints).  *)

let rec teval (e: texpr) (renv: int list) : int =
    match e with
    | TCstI i -> i
    | TVar n -> List.item n renv
    | TLet(erhs, ebody) ->
        let xval = teval erhs renv
        let renv1 = xval :: renv
        teval ebody renv1
    | TPrim("+", e1, e2) -> teval e1 renv + teval e2 renv
    | TPrim("*", e1, e2) -> teval e1 renv * teval e2 renv
    | TPrim("-", e1, e2) -> teval e1 renv - teval e2 renv
    | TPrim _ -> failwith "unknown primitive"

(* Correctness: eval e []  equals  teval (tcomp e []) [] *)

let compiledExpr e =
    let comp = tcomp e []
    teval comp []

let resTcomp = List.map compiledExpr [ e1; e2; e3; e4; e5; e7; e8 ]
