namespace FsSpectre

open FsSpectre
open Spectre.Console

module Tests =
    table {
        title_text "Pods with multiple replica but on same node"
        column_text "Namespace"
        column_text "Node"
        column_text "Pod"
        // ([|for p in pods do yield row [| markup { text { p.Metadata.Name } } |] |])
        row [| markup { text "pwet" }; panel { content_text "Waldo" } |]
    } |> AnsiConsole.Write

module Tests2 =
    table {
        title_text "Pods with multiple replica but on same node"
        column_text "Namespace"
        column_text "Node"
        column_text "Pod"
        // ([|for p in pods do yield row [| markup { text { p.Metadata.Name } } |] |])
        
        for p in pods do yield row [| markup { text { p.Metadata.Name } } |]

        row [| markup { text "pwet" }; panel { content_text "Waldo" } |]
    } |> AnsiConsole.Write
