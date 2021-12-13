open System.IO

let sign num = if num >= 0 then 1 else -1

let countPointsOverlap includeDiagonals lines =
    let getPoints line =
        match line with
        | [| x0; y0; x1; y1 |] when x0 = x1 ->
            [| for y in (min y0 y1)..(max y0 y1) do yield (x0, y) |]
        | [| x0; y0; x1; y1 |] when y0 = y1 ->
            [| for x in (min x0 x1)..(max x0 x1) do yield (x, y0) |]
        | [| x0; y0; x1; y1 |] when includeDiagonals ->
            [| for i in 0..abs (x1 - x0) do yield (x0 + (i * sign (x1 - x0)), y0 + (i * sign (y1 - y0))) |]
        | _ ->
            [| |]

    lines
    |> Array.map getPoints
    |> Array.concat
    |> Array.countBy id
    |> Array.filter (fun (_, count) -> count > 1)
    |> Array.length

[<EntryPoint>]
let main argv =
    let coordinates =
        File.ReadAllLines "input.txt"
        |> Array.map (fun str -> str.Replace(" -> ", ",").Split(","))
        |> Array.map (Array.map int)

    let part1Sol = countPointsOverlap false coordinates
    let part2Sol = countPointsOverlap true coordinates

    printfn "Part 1 solution: %A\nPart 2 solution: %A" part1Sol part2Sol

    0 // return an integer exit code