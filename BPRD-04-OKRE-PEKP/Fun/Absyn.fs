(* Fun/Absyn.fs * Abstract syntax for micro-ML, a functional language *)

module Absyn

type expr = 
  | CstI of int
  | CstB of bool
  | Var of string
  | Let of string * expr * expr
  | Prim of string * expr * expr
  | If of expr * expr * expr
  | Letfun of string * list<string> * expr * expr    (* (f, [x, y, ...], fBody, letBody) *) // Exercise 4.3
  | Call of expr * list<expr> // Exercise 4.3
