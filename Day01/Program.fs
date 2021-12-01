open System.IO

let part1 nums =
    nums 
    |> Array.pairwise
    |> Array.filter (fun (prev, next) -> next > prev)
    |> Array.length

let part2 nums =
    nums 
    |> Array.windowed 3
    |> Array.map Array.sum
    |> part1

[<EntryPoint>]
let main argv =
    let input = File.ReadAllLines("input.txt") |> Array.map int
    let part1Sol = part1 input
    let part2Sol = part2 input

    printfn "Part 1 solution: %A\nPart 2 solution: %A" part1Sol part2Sol

    0 // return an integer exit code
