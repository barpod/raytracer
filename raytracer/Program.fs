// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let color_of_pixel nx ny x y =
    let r = x/nx
    let g = y/ny
    let b = 0.2
    let ir = int (255.99 * r)
    let ig = int (255.99 * g)
    let ib = int (255.99 * b)
    (ir, ig, ib)

let third (_, _, c) = c

[<EntryPoint>]
let main argv = 
    let nx = 200
    let ny = 100
    printfn "P3\n%d %d\n255" nx ny
    [ny-1..-1..0] 
        |> List.map (fun y -> [0..nx-1] |> List.map (fun x -> color_of_pixel (float nx) (float ny) (float x) (float y))) 
        |> List.fold (fun acc pixel -> acc @ pixel ) []
        |> List.iter (fun (r, g, b) -> printfn "%d %d %d" r g b)
    0 // return an integer exit code
