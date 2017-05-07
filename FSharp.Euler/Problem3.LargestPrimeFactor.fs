// https://projecteuler.net/problem=3

module FSharp.Euler.LargestPrimeFactor


let private square x = pown x 2


let private isNotFactorOf x y = x % y <> 0L


let private isGreaterThanSquareOf x squareOf = x >= square squareOf


let rec largestPrimeFactorOf (checkMe: int64) (divisor: int64) =
    let rec getThingy thingy = 
        if (checkMe |> isNotFactorOf) thingy && (checkMe |> isGreaterThanSquareOf) thingy 
            then getThingy (thingy + 1L)
            else thingy

    let thing = getThingy divisor
    if (square thing) <= checkMe 
        then largestPrimeFactorOf (checkMe / thing) thing 
        else checkMe


let answer = largestPrimeFactorOf 600851475143L 2L //6857