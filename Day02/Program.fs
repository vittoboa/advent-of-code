open System.IO

type Position = { horizontal: int; depth: int; aim: int }

let move pos command =
    match command with
    | [| "forward"; amount |] -> 
        { pos with horizontal = pos.horizontal + int amount; depth = pos.depth + pos.aim * int amount }
    | [| "down"; amount |] -> { pos with aim = pos.aim + int amount }
    | [| "up"; amount |] -> { pos with aim = pos.aim - int amount }
    | _ -> failwith ""

[<EntryPoint>]
let main argv =
    let position = 
        File.ReadAllLines "input.txt"
        |> Array.map (fun command -> command.Split " ")
        |> Array.fold move { depth = 0; horizontal = 0; aim = 0 }

    let part1Sol = position.horizontal * position.aim
    let part2Sol = position.horizontal * position.depth

    printfn "Part 1 solution: %A\nPart 2 solution: %A" part1Sol part2Sol

    0 // return an integer exit code
