namespace Zepp

module TestPull =

    open BenchmarkDotNet.Attributes


    let buffer1 = CircularBuffer1(1000)
    let buffer2 = CircularBuffer2(1000)
    let buffer3 = CircularBuffer3(1000)
    let buffer4 = CircularBuffer4(1000)
    let buffer5 = CircularBuffer5(1000)
    let buffer6 = CircularBuffer6(1000)
    let buffer7 = CircularBuffer7(1000)
    let buffer8 = CircularBuffer8(1000)
    let buffer9 = CircularBuffer9(1000)
    let buffer10 = CircularBuffer10(1000)

    for _ in 1..1500 do buffer1.Push 42.0
    for _ in 1..1500 do buffer2.Push 42.0
    for _ in 1..1500 do buffer3.Push 42.0
    for _ in 1..1500 do buffer4.Push 42.0
    for _ in 1..1500 do buffer5.Push 42.0
    for _ in 1..1500 do buffer6.Push 42.0
    for _ in 1..1500 do buffer7.Push 42.0
    let loadBuffer8 =
        let span = buffer8.Span
        for _ in 1..1500 do buffer8.Push(42.0, span)
    let loadBuffer9 =
        let span = buffer9.Span    
        for _ in 1..1500 do buffer9.Push(42.0, span)
    for _ in 1..1500 do buffer10.Push 42.0


    [<MemoryDiagnoser>]
    type BufferPullComparison () =

        [<Params (10, 50, 100, 1000)>] 
        member val Length:int = 0 with get, set

        [<Benchmark>]
        member x.PullCB1() = buffer1.LastNticks x.Length

        [<Benchmark>]
        member x.PullCB2() = buffer2.LastNticks x.Length

        [<Benchmark>]
        member x.PullCB3() = buffer3.LastNticks x.Length

        [<Benchmark>]
        member x.PullCB4() = buffer4.LastNticks x.Length

        [<Benchmark>]
        member x.PullCB5() = buffer5.LastNticks x.Length

        [<Benchmark>]
        member x.PullCB6() = buffer6.LastNticks x.Length

        [<Benchmark>]
        member x.PullCB7() = buffer7.LastNticks x.Length

        [<Benchmark>]
        member x.PullCB8() =
            let span = buffer8.Span
            buffer8.LastNticks(x.Length, span)

        [<Benchmark>]
        member x.PullCB9() =
            let span = buffer9.Span
            buffer9.LastNticks(x.Length, span)

        [<Benchmark>]
        member x.PullCB10() = buffer10.LastNticks x.Length