module Program

open FSharp.Euler

[<EntryPoint>]

printfn "Problem3: %s" <| LargestPrimeFactor.answer.ToString ()

System.Console.In.ReadLine () |> ignore
()