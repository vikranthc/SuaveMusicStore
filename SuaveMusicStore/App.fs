open Suave
open Suave.Successful
open Suave.Operators
open Suave.Web
open Suave.Filters

let webPart : WebPart =
    choose [
        path "/" >=> OK "Home"
        path "/store" >=> OK "Store"
        path "/store/browse" >=> OK "Store"
        path "/store/details" >=> OK "Details"
        pathScan "/store/details/%d" (fun id -> OK  <|sprintf "Details: %d" id )
        pathScan "/store/details/%s/%d" (fun (a,id) -> OK <| sprintf "Artist: %s; Id: %d" a id)
    ]

startWebServer defaultConfig webPart