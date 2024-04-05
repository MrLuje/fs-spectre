namespace FsSpectre

open FsSpectre
open Spectre.Console

module Tests =

    let pods = [| "a"; "b"; "c" |]

    table {
        title_text "Pods with multiple replica but on same node"
        column_text "Namespace"
        column_text "Node"
        column_text "Pod"
        // ([|for p in pods do yield row [| markup { text { p.Metadata.Name } } |] |])
        row [| markup { text "pwet" }; panel { content_text "Waldo" } |]
        rows_text pods (fun s -> [| markup { text ("[blue]"+s+"[/]") } |])
    } |> AnsiConsole.Write

// module Tests2 =
//     let pods = [ "a"; "b"; "c" ]

//     table {
//         // title_text "Pods with multiple replica but on same node"
//         column_text "Namespace"
//         // column_text "Node"
//         // column_text "Pod"
//         // ([|for p in pods do yield row [| markup { text { p.Metadata.Name } } |] |])
        
//         // for p in pods do yield columns_text p
//         // for p in pods do yield row [| markup { text { "p.Metadata.Name" } } |]
//         // for p in pods do row [| markup { text "pwet" } |]

//         // row [| markup { text "pwet" }; panel { content_text "Waldo" } |]
//         // rows_test "psqdf"
//         rows_text pods (fun s -> [| markup { text ("[blue]"+s+"[/blue]") } |])
//     } |> AnsiConsole.Write


module pwet = 
    type ListBuilder() =
        member __.Zero() = []
        member __.Yield(x) = [x]
        member __.Combine(yielded, delayed) =
            yielded @ delayed
    
        member __.Delay(f) = f()

        member __.Run last =
            last |> List.toArray

    let ll = ListBuilder()
    let r = ll {
        1
        2
    }

module maybe =
    type MaybeBuilder() =
        member __.Zero() = None
        member __.Bind(x, f) =
            match x with
            | None -> None
            | Some x -> f x

        member __.Bind(x: int, f) =
            f x

        member __.Return x =
            Some x

    let mb = MaybeBuilder()
    let r = mb {
        let! a = Some 3
        let! b = None
        let! c =  4

        return a + b
    }

    let pwet = mb {
        return 4
    }
