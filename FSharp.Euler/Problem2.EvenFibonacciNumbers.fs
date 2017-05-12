// https://projecteuler.net/problem=2

module FSharp.Euler.EvenFibonacciNumbers


let isEven x =
    x % 2 = 0


let getFibsWhile predicate =
    let rec getFibsInner previous i fibs =
        let next = previous + i

        if not (predicate i) 
        then fibs
        else getFibsInner i next (next :: fibs)
    
    getFibsInner 0 1 []


let sumOfEvenFibNumbersTo sumTo =
    getFibsWhile (fun i -> i < sumTo)
    |> Seq.filter isEven
    |> Seq.sum


let answer = sumOfEvenFibNumbersTo 4000000 //4613732
