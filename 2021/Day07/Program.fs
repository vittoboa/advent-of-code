open System.IO

// sum of all the numbers up to n: 1 + 2 + ... + n
let gauss n = n * (n + 1) / 2

let distance a b = abs (a - b)

[<EntryPoint>]
let main argv =
    let positions =
        File.ReadAllText "input.txt"
        |> fun str -> str.Split ","
        |> Array.map int
        |> Array.sort
    
    let median   = positions.[positions.Length / 2]
    let avgFloor = Array.averageBy float positions |> int

    let part1Sol = Array.sumBy (fun pos -> distance pos median) positions

    let part2 avg  = Array.sumBy (fun pos -> gauss (distance pos avg)) positions
    let part2Floor = part2 avgFloor
    let part2Ceil  = part2 (avgFloor + 1)
    let part2Sol   = min part2Floor part2Ceil

    printfn "Part 1 solution: %A\nPart 2 solution: %A" part1Sol part2Sol

    0 // return an integer exit code