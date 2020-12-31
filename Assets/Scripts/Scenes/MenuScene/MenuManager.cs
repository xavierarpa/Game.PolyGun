﻿#region Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XavLib;
using Environment;
#endregion
public class MenuManager : MonoManager
{
    #region Variables
    [Header("MenuManager")]
    public Button[] buttons;

    //poseerán este ordenamiento
    enum ButtonMenu{
        Play,
        Intro,
        Achieve,
        Opt,
        Exit
    }

    #endregion
    #region Events
    private void Update()
    {
        if (ManagerReady) Init();
    }

    #endregion
    #region Methods
    public void Init(){
        Debug.Log("Esto cargará solo 1 vez");
        ButtonAdjust(!DataPass.GetSavedData().isIntroCompleted);
    }

    
    //void ClickAction()
    //{

    //}

    /// <summary>
    /// Ajustará qué botones podrán ser interactuables y cuales no,
    /// dependiendo del estado de si el tutorial fue terminado o no.
    /// </summary>
    private void ButtonAdjust(bool adjust = false){
        ButtonMenu[] buttonsMenu = { ButtonMenu.Play, ButtonMenu.Achieve, ButtonMenu.Opt};

        for (int x = 0; x < buttons.Length; x++){

            buttons[x].interactable = true;

            if (adjust){
                //si encuentra que forma parte de los adjust
                foreach (ButtonMenu btn in buttonsMenu)
                {
                    if ((ButtonMenu)x == btn) buttons[x].interactable = false;
                }
            }
        }
    }
    

    #endregion
}


