module Main

open Fable.Core.JsInterop

//importAll "../sass/main.sass"

open Elmish
open Elmish.React
open Elmish.Debug
open Elmish.HMR


type ICirrus =
    abstract Button : Fable.React.FunctionComponent<Feliz.Cirrus.ButtonComponent.ButtonProps>


let Cirrus =
    { new ICirrus with
        member __.Button = Feliz.Cirrus.ButtonComponent.button 
     
    }
// //App
// Program.mkProgram App.init App.update App.render
// #if DEBUG
// |> Program.withDebugger
// #endif
// |> Program.withReactSynchronous "feliz-app"
// |> Program.run
