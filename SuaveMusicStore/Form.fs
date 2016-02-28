module SuaveMusicStore.Form

open Suave.Form

type Album = {
    ArtistId : decimal
    GenreId : decimal
    Title : string
    Price : decimal
    ArtUrl : string
}

let album : Form<Album> =
    Form ([ TextProp ((fun f -> <@ f.Title @>), [maxLength 100])
            TextProp ((fun f -> <@ f.ArtUrl@>), [maxLength 100])
            DecimalProp((fun f -> <@f.Price@>), [min 0.01m; max 100.0m; step 0.01m])
            ],
          [])

