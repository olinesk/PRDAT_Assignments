module ex2_4

open Expr
open Absyn

(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)
let sinstrToInt =
    function
    | SCstI i -> [ 0; i ]
    (* Exercise 2.4 Implement function sinstrToInt that converts a sinstr into a list of integers representing the bytecode instruction on the file.*)
    | SVar i -> [ 1; i ]
    | SAdd -> [ 2 ]
    | SSub -> [ 3 ]
    | SMul -> [ 4 ]
    | SPop -> [ 5 ]
    | SSwap -> [ 6 ]

(* Exercise 2.4 Implement function assemble that folds over a list of sinstr and use sinstrToInt to accumulate the list of integers. *)
let assemble sinstrs =
    List.fold (fun acc instr -> acc @ (sinstrToInt instr)) [] sinstrs

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss: int list) (fname: string) =
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text)


// From github
let e1 = Let("z", CstI 17, Prim("+",Var "z", Var "z"));;

let e1Compiled = scomp e1 [];; //val it : sinstr list = [SCstI 17; SVar 0; SVar 1; SAdd; SSwap; SPop]

let test1 = assemble (scomp e1 []);; //val it : int list = [0; 17; 1; 0; 1; 1; 2; 6; 5]
intsToFile test1 "test.txt"