namespace Feliz.Cirrus

open Feliz
open Fable.Core
open Fable.Core.JsInterop

module ButtonComponent =

    // BUTTON
    type ElementType = Div | Button | Submit 

    type Theme = Plain | Primary | Transparent | Light | Dark | Black | Info | Link | Success | Warning | Danger

    type Size = Tiny | Small | Normal | Large | ExtraLarge


    type ButtonProps = {
        /// An element type to render as (string or function).
        elmType:ElementType

        children: ReactElement seq

        value: string

        animated: bool

        disabled: bool

        theme: Theme

        outline: bool

        size: Size
      }

    let themeClass theme =
        match theme with
        | Plain -> ""
        | Primary -> Ccls.BtnPrimary
        | Transparent -> Ccls.BtnTransparent
        | Light -> Ccls.BtnLight
        | Dark -> Ccls.BtnDark
        | Black -> Ccls.BtnBlack
        | Info -> Ccls.BtnInfo 
        | Link -> Ccls.BtnLink
        | Success -> Ccls.BtnSuccess
        | Warning -> Ccls.BtnWarning 
        | Danger -> Ccls.BtnDanger

    let sizeClass size = 
        match size with
        | Tiny -> Ccls.BtnTiny
        | Small -> Ccls.BtnSmall
        | Normal -> ""
        | Large -> Ccls.BtnLarge
        | ExtraLarge -> Ccls.BtnXlarge

    let button = 
        React.functionComponent("Button", fun (props: ButtonProps) ->
        
        let btn = 
            match props.elmType with
            | Button -> Html.button
            | Div -> Html.div
            | Submit _ -> Html.input
        
        let cls = [
            if props.elmType = Div then
                Ccls.Btn
            if props.animated then
                Ccls.BtnAnimated
            
            if props.outline then
                Ccls.Outline

            themeClass props.theme
            sizeClass props.size
        ]

        btn [
                prop.className cls
                prop.disabled props.disabled

                if props.elmType = Submit then
                    prop.withType "submit"
                    prop.value props.value
                else
                    prop.children props.children ]
    )

    // BUTTON GROUP
    type ButtonGroupProps = {
        fill: bool
        children: ReactElement seq
    }
    let buttonGroup = React.functionComponent("Button-Group", fun (props: ButtonGroupProps) ->
            Html.div [
                prop.classes [
                    Ccls.BtnGroup
                    if props.fill then
                        Ccls.BtnGroupFill
                ]

                prop.children props.children
            ]
    )


    // BUTTON CONTAINER
    type ButtonContainerProps = {
        children: ReactElement seq
    }
    let buttonContainer = React.functionComponent("Button-Container", fun (props: ButtonContainerProps) ->
            Html.div [
                prop.className Ccls.BtnContainer
                prop.children props.children
            ]
    )

open ButtonComponent

type IButtonProperty = interface end

[<Erase>]
type button =
    /// The content.
    static member inline children (children: ReactElement list) =
        unbox<IButtonProperty> ((nameof children), Html.fragment children)
    /// The element type
    static member inline elmType (elmType: ElementType) =
        unbox<IButtonProperty> (( nameof elmType), elmType)

    /// The value of submit
    static member inline value (value: string) =
        unbox<IButtonProperty> (( nameof value), value)

    /// animate
    static member inline animated =
        unbox<IButtonProperty> ("animated", true)

    /// disabled
    static member inline disabled =
        unbox<IButtonProperty> ("disabled", true)
    
    static member inline plain = unbox<IButtonProperty> ("theme", ButtonComponent.Plain)
    static member inline primary = unbox<IButtonProperty> ("theme", ButtonComponent.Primary)
    static member inline transparent = unbox<IButtonProperty> ("theme", ButtonComponent.Transparent)
    static member inline light = unbox<IButtonProperty> ("theme", ButtonComponent.Light)
    static member inline dark = unbox<IButtonProperty> ("theme", ButtonComponent.Dark)
    static member inline black = unbox<IButtonProperty> ("theme", ButtonComponent.Black)
    static member inline info = unbox<IButtonProperty> ("theme", ButtonComponent.Info)
    static member inline link = unbox<IButtonProperty> ("theme", ButtonComponent.Link)
    static member inline success = unbox<IButtonProperty> ("theme", ButtonComponent.Success)
    static member inline warning = unbox<IButtonProperty> ("theme", ButtonComponent.Warning)
    static member inline danger = unbox<IButtonProperty> ("theme", ButtonComponent.Danger)
    
    static member inline outline = unbox<IButtonProperty> ("outline", true)


    static member inline tiny = unbox<IButtonProperty> ("size", Tiny)
    static member inline small = unbox<IButtonProperty> ("size", Small)
    static member inline normal = unbox<IButtonProperty> ("size", Normal)
    static member inline large = unbox<IButtonProperty> ("size", Large)
    static member inline extraLarge = unbox<IButtonProperty> ("size", ExtraLarge)

[<Erase>]
type Button =
    static member inline button (properties: IButtonProperty list) =
        let defaults = createObj [ "elmType" ==> ButtonComponent.ElementType.Button;
                                   "theme" ==> ButtonComponent.Plain
                                   "size" ==> Normal ]
        Interop.reactApi.createElement(ButtonComponent.button, JS.Object.assign(defaults, createObj !!properties))
    

type IButtonGroupProperty = interface end

[<Erase>]
type buttonGroup = 
    /// The content.
    static member inline children (children: ReactElement list) =
        unbox<IButtonGroupProperty> ((nameof children), Html.fragment children)
    
    static member inline fill =
        unbox<IButtonGroupProperty> ("fill", true)


[<Erase>]
type ButtonGroup =
    static member inline buttonGroup (properties: IButtonGroupProperty list) =
        let defaults = createObj [ "fill" ==> false ]
        Interop.reactApi.createElement(ButtonComponent.buttonGroup, JS.Object.assign(defaults, createObj !!properties))




type IButtonContainerProperty = interface end

[<Erase>]
type buttonContainer = 
    /// The content.
    static member inline children (children: ReactElement list) =
        unbox<IButtonContainerProperty> ((nameof children), Html.fragment children)
    
[<Erase>]
type ButtonContainer =
    static member inline buttonContainer (properties: IButtonContainerProperty list) =
        let defaults = createObj [ ]
        Interop.reactApi.createElement(ButtonComponent.buttonContainer, JS.Object.assign(defaults, createObj !!properties))