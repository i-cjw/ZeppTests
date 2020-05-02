namespace Zepp

open BenchmarkDotNet.Running

open TestCreation
open TestPush
open TestPull

module Main =

    [<EntryPoint>]
    let main argv =
        
        //BenchmarkRunner.Run typeof<BufferCreationComparison> |> ignore
        //BenchmarkRunner.Run typeof<BufferPushComparison> |> ignore
        BenchmarkRunner.Run typeof<BufferPullComparison> |> ignore

        0 // return an integer exit code
