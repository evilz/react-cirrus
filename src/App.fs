module App

open Feliz
open Elmish
open Fable.Core
open Fable.Core.JsInterop

open Feliz.Cirrus

type State =
    { Count: int
      Name: string }

type Msg =
    | Increment
    | Decrement
    | UpdateName of string

let init() =
    { Count = 0
      Name = "" }, Cmd.none

let update (msg: Msg) (state: State) =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }, Cmd.none
    | Decrement -> { state with Count = state.Count - 1 }, Cmd.none
    | UpdateName name -> { state with Name = name }, Cmd.none


let render (state: State) (dispatch: Msg -> unit) =
    


    //// BOUTONS ///////////

    let btnTypes =[ ButtonComponent.ElementType.Div, "div"
                    ButtonComponent.ElementType.Button, "regular button"
                    ButtonComponent.ElementType.Submit, "submit" ]
    
    let btnThemes = [ button.plain , nameof(button.plain)
                      button.primary, nameof(button.primary)
                      button.transparent, nameof(button.transparent)
                      button.light, nameof(button.light)
                      button.dark, nameof(button.dark)
                      button.black, nameof(button.black)
                      button.info, nameof(button.info)
                      button.link, nameof(button.link)
                      button.success, nameof(button.success)
                      button.warning, nameof(button.warning)
                      button.danger, nameof(button.danger) ]
     
    let btnSize = [ button.tiny , nameof(button.tiny) ]

    Html.fragment [
        App.Header.header

        Html.br []
        Html.br []
        Html.div [ prop.className Ccls.Large]

        Cirrus.Flexbox.row [
            Cirrus.Flexbox.col12 [
                Html.div [
                    prop.style [style.backgroundColor "red"]
                    prop.children [Html.text "Col-12"]
                ]
            ]
        ]

        Html.section [
            prop.className "padtop"
            prop.children [
                Html.h1 [ Html.text "Buttons" ]

                ButtonContainer.buttonContainer
                      [ buttonContainer.children
                          [ ButtonComponent.button
                              { elmType = ButtonComponent.Button
                                children = [ Html.text "Using record" ]
                                value = ""
                                animated = false
                                disabled = false
                                theme = ButtonComponent.Theme.Plain
                                outline = false
                                size = ButtonComponent.Normal } ] ]

                Html.h2 [ Html.text "Non-animated buttons." ]

                for (e, t) in btnTypes do
                             ButtonContainer.buttonContainer
                                 [ buttonContainer.children
                                     [ Button.button
                                         [ button.elmType e
                                           button.children [ Html.text t ] ] ] ]

                Html.h2 [ Html.text "Animated" ]

                for (e, t) in btnTypes do
                      ButtonContainer.buttonContainer
                          [ buttonContainer.children
                              [ Button.button
                                  [ button.elmType e
                                    button.children [ Html.text t ]
                                    button.animated ] ] ]


                Html.h2 [ Html.text "Disabled" ]

                for (e, t) in btnTypes do
                      ButtonContainer.buttonContainer
                          [ buttonContainer.children
                              [ Button.button
                                  [ button.elmType e
                                    button.children [ Html.text t ]
                                    button.disabled ] ] ]

                Html.h2 [ Html.text "Themed" ]

                for (theme, text) in btnThemes do
                      ButtonContainer.buttonContainer
                          [ buttonContainer.children
                              [ Button.button
                                  [ button.children [ Html.text text ]
                                    theme ] ] ]

                Html.h2 [ Html.text "Outline" ]

                for (theme, text) in btnThemes do
                      ButtonContainer.buttonContainer
                          [ buttonContainer.children
                              [ Button.button
                                  [ button.children [ Html.text text ]
                                    button.outline
                                    theme ] ] ]


                Html.h2 [ Html.text "Size" ]

                Cirrus.Button.button
                      [ Cirrus.button.children [ Html.text "tiny" ]
                        Cirrus.button.primary
                        Cirrus.button.tiny ]

                Cirrus.Button.button
                      [ Cirrus.button.children [ Html.text "small" ]
                        Cirrus.button.primary
                        Cirrus.button.small ]

                Cirrus.Button.button
                      [ Cirrus.button.children [ Html.text "normal" ]
                        Cirrus.button.primary
                        Cirrus.button.normal ]

                Cirrus.Button.button
                      [ Cirrus.button.children [ Html.text "large" ]
                        Cirrus.button.primary
                        Cirrus.button.large ]

                Cirrus.Button.button
                      [ Cirrus.button.children [ Html.text "extraLarge" ]
                        Cirrus.button.primary
                        Cirrus.button.extraLarge ]


                Html.h2 [ Html.text "Group" ]

                Cirrus.ButtonGroup.buttonGroup
                      [ Cirrus.buttonGroup.children
                          [ Cirrus.Button.button [ Cirrus.button.children [ Html.text "no" ] ]
                            Cirrus.Button.button [ Cirrus.button.children [ Html.text "fill" ] ] ] ]

                Html.div
                      [ prop.style [ style.width 400 ]
                        prop.children
                            [ Cirrus.ButtonGroup.buttonGroup
                                [ Cirrus.buttonGroup.fill
                                  Cirrus.buttonGroup.children
                                      [ Cirrus.Button.button [ Cirrus.button.children [ Html.text "First Button" ] ]
                                        Cirrus.Button.button [ Cirrus.button.children [ Html.text "Second Button" ] ] ] ] ] ]

                Html.h2 [ Html.text "Font Awesome" ]

                Cirrus.Button.button
                      [ Cirrus.button.children
                          [ Html.i
                              [ prop.classes [ icon.Fa; icon.FaChevronLeft; Ccls.FaWrapper; Ccls.PadRight ] ]
                            Html.text "FaChevronLeft with pad right" ] ]

                Cirrus.Button.button
                      [ Cirrus.button.children
                          [ Html.text "FaChevronRight with pad left"
                            Html.i
                                [ prop.classes
                                    [ icon.Fa; icon.FaChevronRight; Ccls.FaWrapper; Ccls.PadLeft ] ] ] ]

                Cirrus.Button.button
                      [ Cirrus.button.children
                          [ Html.text "Loading"
                            Html.i
                                [ prop.classes
                                    [ icon.Fa; icon.FaCircleNotch; icon.FaSpin; Ccls.FaWrapper; Ccls.PadLeft ] ] ] ] ]

        ]
    ]

    