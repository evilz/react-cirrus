namespace App

open Feliz
open Elmish
open Fable.Core
open Fable.Core.JsInterop

open Feliz.Cirrus

module Header =

    let headerTitle =
        Html.a [
            prop.href "../../"
            prop.children [
                Html.h6 [
                    prop.className Ccls.Title
                    prop.children [Html.text "My Awesome App"]
            ]]]
             

    let headerBtn = 
        Html.div [
            prop.className [Ccls.NavItem; Ccls.NavBtn]
            prop.id "header-btn"
            prop.children [
                Html.span []
                Html.span []
                Html.span []
            ]
        ]

    let header = 
        
        
        Html.div [
            prop.id "header"
            prop.className [Ccls.Header; Ccls.UUnselectable; Ccls.HeaderFixed; Ccls.HeaderDark; Ccls.HeaderAnimated; "header-fill" ] //  ;no-transition
            
            prop.children [
                Html.div [
                    prop.className Ccls.HeaderBrand
                    prop.children [
                        Html.div [
                            prop.className Ccls.NavItem
                            prop.children headerTitle
                        ]
                        headerBtn
                    ]
                ]

                

                Html.div [
                    prop.className Ccls.HeaderNav
                    prop.id "header-menu"
                    prop.children [
                        Html.div [
                            prop.className [Ccls.NavItem; Ccls.UTextCenter]
                            prop.children [
                                Html.a [
                                    prop.href "https://github.com/Spiderpig86/Cirrus"
                                    prop.children [
                                        Html.span [
                                            prop.className Ccls.Icon
                                            prop.children [
                                                Html.i [
                                                    prop.className [icon.Fab; Ccls.FaWrapper;icon.FaGithub]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                               
                            ]
                        ]
                    ]
                ]
                
            ]
        ]
        
      