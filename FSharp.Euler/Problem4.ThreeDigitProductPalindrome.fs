module FSharp.Euler.ThreeDigitProductPalindrome

open System

let isPalindrome (thing: string) =
    (thing.ToCharArray() |> Array.rev |> fun chars -> new string(chars)) = thing

let answer =
    seq { for i = 999 downto 100 do
            for j = 999 downto 100 do 
                if (i * j).ToString() |> isPalindrome then yield i * j
        }
    |> Seq.max