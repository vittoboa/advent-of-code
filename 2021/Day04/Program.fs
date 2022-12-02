open System.IO

[<EntryPoint>]
let main argv =
    let numbers = 
        File.ReadLines "input.txt"
        |> Seq.head
        |> fun str -> str.Split ","
        |> Seq.map int

    let boardsRows = 
        File.ReadLines "input.txt"
        |> Seq.skip 1
        |> Seq.where (fun row -> row <> "")
        |> Seq.map (fun row -> row.Split " ")
        |> Seq.map (Seq.filter (fun num -> num <> ""))
        |> Seq.map (Seq.map int)

    let everyNth n seq = 
        seq 
        |> Seq.mapi (fun i el -> el, i)
        |> Seq.filter (fun (el, i) -> i % n = 0)
        |> Seq.map fst

    let boardsCols = 
        boardsRows
        |> Seq.concat
        |> fun cols -> seq { for i in 0 .. 4 -> everyNth 5 (cols |> Seq.skip i)}
        |> Seq.map (Seq.chunkBySize 5)
        |> Seq.concat
        |> Seq.where (fun col -> All (fun el -> Seq.contains el col))

    printfn "Part 1 solution: %A\n" boardsCols

    0 // return an integer exit code

