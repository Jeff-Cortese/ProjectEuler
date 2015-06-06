// https://projecteuler.net/problem=1

module FSharp.Euler.MultiplesOf3And5


let isMultipleOf number multiple = 
    number % multiple = 0


let isMultipleOfAnyIn list x =
    list |> Seq.exists (isMultipleOf x)


let sumOfMultiplesTo sumTo multiples =
    seq { 0..sumTo - 1 }
    |> Seq.filter (isMultipleOfAnyIn multiples)
    |> Seq.sum 


let sumOfMultiplesTo' sumTo multiples =
    let multiplesOf x =
        async {
            return seq { 0..sumTo }
            |> Seq.takeWhile (fun i -> i * x < sumTo)
            |> Seq.fold (fun list i ->
                if list |> Seq.head < i * x
                then i * x :: list 
                else list
            ) [0]
        }

    multiples
    |> Seq.map multiplesOf
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Seq.concat
    |> Seq.distinct
    |> Seq.sum
        
    
let answer = sumOfMultiplesTo 1000 [3; 5;] //233168
let answer' = sumOfMultiplesTo' 1000 [3; 5;]