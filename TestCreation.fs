namespace Zepp

module TestCreation =

    open BenchmarkDotNet.Attributes

    let createCB1(size:int) = CircularBuffer1(size)
    let createCB2(size:int) = CircularBuffer2(size)
    let createCB3(size:int) = CircularBuffer3(size)
    let createCB4(size:int) = CircularBuffer4(size)
    let createCB5(size:int) = CircularBuffer5(size)
    let createCB6(size:int) = CircularBuffer6(size)
    let createCB7(size:int) = CircularBuffer7(size)
    let createCB8(size:int) = CircularBuffer8(size)
    let createCB9(size:int) = CircularBuffer9(size)
    let createCB10(size:int) = CircularBuffer10(size)


    [<MemoryDiagnoser>]
    type BufferCreationComparison () =

        [<Params (1_000, 10_000, 1_000_000, 10_000_000)>] 
        member val Size:int = 0 with get, set

     
        [<Benchmark>]
        member x.CreateCB1() = createCB1 x.Size
        
        [<Benchmark>]
        member x.CreateCB2() = createCB2 x.Size
        
        [<Benchmark>]
        member x.CreateCB3() = createCB3 x.Size
        
        [<Benchmark>]
        member x.CreateCB4() = createCB4 x.Size
        
        [<Benchmark>]
        member x.CreateCB5() = createCB5 x.Size
        
        [<Benchmark>]
        member x.CreateCB6() = createCB6 x.Size
        
        [<Benchmark>]
        member x.CreateCB7() = createCB7 x.Size
        
        [<Benchmark>]
        member x.CreateCB8() = createCB8 x.Size
        
        [<Benchmark>]
        member x.CreateCB9() = createCB9 x.Size
        
        [<Benchmark>]
        member x.CreateCB10() = createCB10 x.Size