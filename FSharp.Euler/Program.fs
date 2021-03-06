﻿module Program

open FSharp.Euler

[<EntryPoint>]

printfn "Problem1: %d" <| MultiplesOf3And5.answer
printfn "Problem2: %d" <| EvenFibonacciNumbers.answer
printfn "Problem3: %d" <| LargestPrimeFactor.answer
printfn "Problem4: %d" <| ThreeDigitProductPalindrome.answer

System.Console.In.ReadLine () |> ignore