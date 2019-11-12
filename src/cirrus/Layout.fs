namespace Feliz.Cirrus

open Feliz
open Fable.Core
open Fable.Core.JsInterop

module Flexbox =

     // BUTTON CONTAINER
    type RowProps = {
        children: ReactElement seq
    }
    let row = React.functionComponent("Row", fun (props: RowProps) ->
            Html.div [
                prop.className Ccls.Row
                prop.children props.children
            ]
    )

    type ColProps = {
        children: ReactElement seq
    }
    let col12 = React.functionComponent("Col-12", fun (props: ColProps) ->

            let (width, setWidth) = React.useState(12)


            Html.div [
                prop.className [ width = 12 , Ccls.Col12 ; width = 3 , Ccls.Col3  ]
                prop.children props.children
                prop.onClick (fun _ -> setWidth(3))
            ]
    )

type IRowProperty = interface end

[<Erase>]
type row = 
    /// The content.
    static member inline children (children: ReactElement list) =
        unbox<IRowProperty> ((nameof children), Html.fragment children)


[<Erase>]
type Flexbox =
    
    static member inline row (children: ReactElement list) =
        let defaults = createObj [ "children" ==> children  ]
        Interop.reactApi.createElement(Flexbox.row, JS.Object.assign(defaults))

    static member inline col12 (children: ReactElement list) =
        let defaults = createObj [ "children" ==> children  ]
        Interop.reactApi.createElement(Flexbox.col12, JS.Object.assign(defaults))