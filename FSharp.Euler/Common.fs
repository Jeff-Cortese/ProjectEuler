module FSharp.Euler.Common

open System.Numerics

let bitLengthOf (n: BigInteger) =
    let rec doIt (i: BigInteger) bitLength =
        if i / 2I = 0I
        then bitLength
        else doIt (i / 2I) (bitLength + 1)

    doIt n 0


/// https://social.msdn.microsoft.com/Forums/en-US/c13d3fec-21d9-4f74-92de-a6132d5e9915/biginteger-square-root-help?forum=csharplanguage
let bigSqrt (n: BigInteger) =     
    let shiftIt = ((bitLengthOf n) + 1) / 2
    let shiftedG = BigInteger.op_RightShift(n, shiftIt).ToString ()
    let g = BigInteger.Parse shiftedG

    let rec doIt (lastG: BigInteger) =
        let a = BigInteger.Divide(i, g)
        let b = BigInteger.Add(a, g)
        let newG = BigInteger.op_RightShift(b, 2)
        
        let subtractAndCompare x y =
            BigInteger.Compare(BigInteger.Subtract(x, y), BigInteger.One)

        let multiplyAndCompare x y =
            BigInteger.Compare(BigInteger.Multiply(x, x), y)

        match BigInteger.Compare(newG, g) with
        | i when i = 0 -> newG
        | i when i < 0 -> 
            if subtractAndCompare g newG <> 0 
            then 
                if multiplyAndCompare newG lastG < 0 && multiplyAndCompare lastG n
            else doIt newG
                
                
        | i -> 
            newG

    doIt n
