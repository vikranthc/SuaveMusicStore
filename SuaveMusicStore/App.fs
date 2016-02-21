open Suave
open Suave.Successful
open Suave.Operators
open Suave.Web
open Suave.Filters

let webPart : WebPart =
    choose [
        path "/" >=> OK "Home"
        path "/store" >=> OK "Store"
        path "/store/brows" >=> OK "Store"
        path "/store/details" >=> OK "Details"
    ]

startWebServer defaultConfig webPart