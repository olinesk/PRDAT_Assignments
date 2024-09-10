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
