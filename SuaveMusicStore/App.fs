﻿module SuaveMusicStore.App

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
        path Path.home >=> OK View.index
        path Path.Store.overview >=> OK "Store"
        path Path.Store.browse >=> browse
        pathScan Path.Store.details (fun id -> OK  <|sprintf "Details: %d" id)
    ]

startWebServer defaultConfig webPart