namespace Zepp

module TestPush =

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


    let pushCB1 times =

        for _ in 1..times do

            buffer1.Push 42.0

    let pushCB2 times =

        for _ in 1..times do

            buffer2.Push 42.0

    let pushCB3 times =

        for _ in 1..times do

            buffer3.Push 42.0

    let pushCB4 times =

        for _ in 1..times do

            buffer4.Push 42.0

    let pushCB5 times =

        for _ in 1..times do

            buffer5.Push 42.0

    let pushCB6 times =

        for _ in 1..times do

            buffer6.Push 42.0

    let pushCB7 times =

        for _ in 1..times do

            buffer7.Push 42.0

    let pushCB8 times =

        let span8 = buffer8.Span

        for _ in 1..times do

            buffer8.Push(42.0, span8)

    let pushCB9 times =

        let span9 = buffer9.Span

        for _ in 1..times do

            buffer9.Push(42.0, span9)

    let pushCB10 times =

        for _ in 1..times do

            buffer10.Push 42.0


    [<MemoryDiagnoser>]
    type BufferPushComparison () =

        [<Params (1_000, 10_000, 1_000_000, 10_000_000)>] 
        member val Times:int = 0 with get, set

        [<Benchmark>]
        member x.PushCB1() = pushCB1 x.Times

        [<Benchmark>]
        member x.PushCB2() = pushCB2 x.Times

        [<Benchmark>]
        member x.PushCB3() = pushCB3 x.Times

        [<Benchmark>]
        member x.PushCB4() = pushCB4 x.Times

        [<Benchmark>]
        member x.PushCB5() = pushCB5 x.Times

        [<Benchmark>]
        member x.PushCB6() = pushCB6 x.Times

        [<Benchmark>]
        member x.PushCB7() = pushCB7 x.Times

        [<Benchmark>]
        member x.PushCB8() = pushCB8 x.Times

        [<Benchmark>]
        member x.PushCB9() = pushCB9 x.Times

        [<Benchmark>]
        member x.PushCB10() = pushCB10 x.Times

