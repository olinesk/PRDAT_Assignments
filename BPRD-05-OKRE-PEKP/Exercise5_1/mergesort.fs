module mergesort

let mergesort (xs, ys) = List.sort (xs @ ys)

let mergeTest = mergesort ([3; 5; 12], [2; 3; 4; 7])

printfn "%A" mergeTest