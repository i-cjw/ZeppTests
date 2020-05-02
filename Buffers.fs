namespace Zepp

open System
open Microsoft.FSharp.NativeInterop

type CircularBuffer1(size:int) =

    let arr = Array.create size nan

    let mutable headIndex = -1

    member x.Push value =

        if headIndex + 1 = size then
            headIndex <- 0
        else
            headIndex <- headIndex + 1

        arr.[headIndex] <- value

    member x.LastNticks with get(nTicks) =

        if nTicks > size then

            failwith "Number of requested ticks exceeds number of ticks"


        elif headIndex >= nTicks - 1 then

            let startIndex = (headIndex - nTicks + 1)

            arr.[startIndex..(headIndex)]

        else

            let offset = size - (nTicks - headIndex - 1)

            let startArray = arr.[offset..]

            let endArray = arr.[0..headIndex]

            Array.append startArray endArray


type CircularBuffer2(size:int) =

    let arr = Array.init (size * 2) (fun _ -> nan)

    let mutable headIndex = size - 1

    member x.Push value =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        arr.[headIndex] <- value

        arr.[headIndex - size] <- value


    member x.LastNticks with get(nTicks) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            arr.[startIndex..headIndex] 


type private StructArray = 
    struct
        val arr: float[]

        new (size) =
            { arr = Array.init size (fun _ -> nan)} end


type CircularBuffer3(size:int) =

    let structArray = StructArray(size * 2)

    let arr = structArray.arr

    let mutable headIndex = size - 1

    member x.Push value =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        arr.[headIndex] <- value

        arr.[headIndex - size] <- value

  
    member x.LastNticks with get(nTicks) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            arr.[startIndex..headIndex] 


type CircularBuffer4(size:int) =

    let arr = Array.init (size * 2) (fun _ -> nan)

    let mutable headIndex = size - 1

    member x.Push value =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        let span = new Span<float>(arr)

        span.[headIndex] <- value

        span.[headIndex - size] <- value


    member x.LastNticks with get(nTicks) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            let span = new Span<float>(arr)

            span.Slice(startIndex, nTicks).ToArray()


type CircularBuffer5(size:int) =

    let arr = Array.init (size * 2) (fun _ -> nan)

    let mutable mem = Memory<float>(arr)

    let mutable headIndex = size - 1

    member x.Push value =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        mem.Span.[headIndex] <- value

        mem.Span.[headIndex - size] <- value


    member x.LastNticks with get(nTicks) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            mem.Span.Slice(startIndex, nTicks).ToArray()


type CircularBuffer6(size:int) =

    let structArray = StructArray(size * 2)

    let arr = structArray.arr

    let mutable headIndex = size - 1

    member x.Push value =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        let span = new Span<float>(arr)

        span.[headIndex] <- value

        span.[headIndex - size] <- value


    member x.LastNticks with get(nTicks) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            let span = new Span<float>(arr)

            span.Slice(startIndex, nTicks).ToArray()


type CircularBuffer7(size:int) =

    let structArray = StructArray(size * 2)

    let arr = structArray.arr

    let mutable mem = Memory<float>(arr)

    let mutable headIndex = size - 1

    member x.Push value =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        mem.Span.[headIndex] <- value

        mem.Span.[headIndex - size] <- value


    member x.LastNticks with get(nTicks) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            mem.Span.Slice(startIndex, nTicks).ToArray()


type CircularBuffer8(size:int) =

    let arr = Array.create (size * 2) nan     

    let mutable headIndex = size - 1

    member x.Span with get() = Span<float>(arr)

    member x.Push (value, span:Span<float>) =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        span.[headIndex] <- value

        span.[headIndex - size] <- value
    

    member x.LastNticks with get(nTicks, span:Span<float>) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            span.Slice(startIndex, nTicks).ToArray()


type CircularBuffer9(size:int) =

    let structArray = StructArray(size * 2)

    let arr = structArray.arr      

    let mutable headIndex = size - 1

    member x.Span with get() = Span<float>(arr)

    member x.Push (value, span:Span<float>) =

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        span.[headIndex] <- value

        span.[headIndex - size] <- value


    member x.LastNticks with get(nTicks, span:Span<float>) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let startIndex = headIndex - nTicks + 1

            span.Slice(startIndex, nTicks).ToArray()


type CircularBuffer10(size:int) =

    let arr = NativePtr.stackalloc<float>(size * 2)
    let ptr = arr |> NativePtr.toVoidPtr
    

    let mutable headIndex = size - 1

    member x.Push value =

        let span = Span<float>(ptr, size * 2)

        if headIndex + 1 = size * 2 then
            headIndex <- size
        else
            headIndex <- headIndex + 1

        span.[headIndex] <- value

        span.[headIndex - size] <- value


    member x.LastNticks with get(nTicks) =

        if nTicks > size then
    
            failwith "Number of requested ticks exceeds number of ticks"

        else

            let span = Span<float>(ptr, size * 2)

            let startIndex = headIndex - nTicks + 1

            span.Slice(startIndex, nTicks).ToArray()    