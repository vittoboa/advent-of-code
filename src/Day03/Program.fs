open System.IO

let mostCommon nums =
    let zeros = nums |> Array.filter (fun num -> num = '0')

    if zeros.Length > nums.Length / 2 then '0' else '1'

let leastCommon nums =
    let zeros = nums |> Array.filter (fun num -> num = '0')

    if zeros.Length <= nums.Length / 2 then '0' else '1'

let convertToDecimal (binary: char[]) = System.Convert.ToInt32(System.String binary, 2)

let invertBinary binary =
    binary
    |> Array.map (fun bit -> if bit = '0' then '1' else '0')

let rec matchBitCriteria criteria matchingInput bit =
    if Array.length matchingInput = 1 then
        matchingInput.[0]
    else
        let common = 
            matchingInput
            |> Array.transpose
            |> Array.map criteria

        let matching =
            matchingInput
            |> Array.filter (fun inp -> inp.[bit] = common.[bit])

        matchBitCriteria criteria matching (bit + 1)

[<EntryPoint>]
let main argv =
    let input =
        File.ReadAllLines "input.txt"
        |> Array.map (fun str -> str.ToCharArray())

    let gamma =
        input
        |> Array.transpose
        |> Array.map mostCommon

    let epsilon = invertBinary gamma

    let gamma2 = matchBitCriteria mostCommon input 0
    let epsilon2 = matchBitCriteria leastCommon input 0

    let part1Sol = convertToDecimal gamma * convertToDecimal epsilon
    let part2Sol = convertToDecimal gamma2 * convertToDecimal epsilon2

    printfn "Part 1 solution: %A\nPart 2 solution: %A" part1Sol part2Sol

    0 // return an integer exit code
