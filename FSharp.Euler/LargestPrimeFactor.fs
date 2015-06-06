// https://projecteuler.net/problem=3

module FSharp.Euler.LargestPrimeFactor


let isFactorOf (x: bigint) (y: bigint) = 
    if x < y then false
    else y % x = bigint(0)


let isEven (x: bigint) =
    x % bigint(2) = bigint(0)


let isPrime (x: bigint) =
    if x < bigint(2) || isEven x then false
    else
        let until = if x < bigint(7) then bigint(7) else x

        seq { bigint(2)..(until / bigint(2)) }
        |> Seq.filter (not << isEven)
        |> Seq.filter (fun i -> i <> x)
        |> Seq.forall (not << isFactorOf x)
        

let largestPrimeFactorOf (x: bigint) =
    seq { x..bigint(3) } // probably inefficient memory-wise, but i can't figure out how to exit a for loop early
    |> Seq.takeWhile isPrime 
    |> Seq.last


let thing = bigint(600851475143L)

let answer = largestPrimeFactorOf thing 