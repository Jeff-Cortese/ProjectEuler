// https://projecteuler.net/problem=3

module FSharp.Euler.LargestPrimeFactor

open System.Numerics


let isFactorOf (x: bigint) (y: bigint) = 
    if x < y then false
    else y % x = bigint(0)


let isEven (x: bigint) =
    x % bigint(2) = bigint(0)


(*let isPrime (x: bigint) =
    if x < bigint(2) || isEven x then false
    else
        let until = if x < bigint(7) then bigint(7) else x

        seq { bigint(2)..(until / bigint(2)) }
        |> Seq.filter (not << isEven)
        |> Seq.filter (fun i -> i <> x)
        |> Seq.forall (not << isFactorOf x)
        *)

let isPrime (n: BigInteger) =
    let rec check i =
        i > n/2I || (n % i <> 0I && check (i + 1I))
    check 2I
        

(*let largestPrimeFactorOf (x: BigInteger) =
    try
        Seq.unfold (fun (i: BigInteger * bool) ->     
            if fst i < 2I || snd i
            then 
                None 
            else 
                Some (i, (fst i - 1I, (isPrime <| fst i) && isFactorOf (fst i) x))
            ) (x / 2I, false)
        |> Seq.last |> fst

    with
        msg -> -1I*)


let largestPrimeFactorOf (x: BigInteger) =
    let isFactor (z: BigInteger) = 
        x % z = 0I

    let rec doIt (i: BigInteger) =
        if isFactor i 
        then true 
        else doIt (i - 1I)

    doIt (Common.bigSqrt x)


let thing = bigint(600851475143L)

let answer = largestPrimeFactorOf thing 
