module SuaveMusicStore.App

open Suave
open Suave.Successful
open Suave.Operators
open Suave.Web
open Suave.Filters
open Suave.Http
open Suave.RequestErrors

let browse =
    request (fun r -> 
        match r.queryParam "genre" with
        | Choice1Of2 genre -> OK <| sprintf "Genre: %s" genre
        | Choice2Of2 msg -> BAD_REQUEST msg)

let webPart : WebPart =
    choose [
        path "/" >=> OK View.index
        path "/store" >=> OK "Store"
        path "/store/browse" >=> browse
        path "/store/details" >=> OK "Details"
        pathScan "/store/details/%d" (fun id -> OK  <|sprintf "Details: %d" id )
        pathScan "/store/details/%s/%d" (fun (a,id) -> OK <| sprintf "Artist: %s; Id: %d" a id)
    ]


startWebServer defaultConfig webPart