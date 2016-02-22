module SuaveMusicStore.App

open Suave
open Suave.Operators
open Suave.Web
open Suave.Filters
open Suave.Http
open Suave.RequestErrors
open View

let browse =
    request (fun r -> 
        match r.queryParam "genre" with
        | Choice1Of2 genre -> html (View.browse genre)
        | Choice2Of2 msg -> BAD_REQUEST msg)

let webPart : WebPart =
    choose [
        path Path.home >=> html View.home
        path Path.Store.overview >=> html View.store
        path Path.Store.browse >=> browse
        pathScan Path.Store.details (fun id -> html (View.details id))

        pathRegex "(.*)\.(css|png)" >=> Files.browseHome
    ]

startWebServer defaultConfig webPart