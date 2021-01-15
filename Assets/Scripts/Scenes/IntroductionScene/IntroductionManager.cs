﻿#region Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;
using XavLib;
#endregion
public class IntroductionManager : MonoManager
{
    #region Variables

    //ultima posición de cada opción
    [Header("Input Controller")]
    public MenuInputController menuInputC;
    public Navigator navigator;
    [Space]
    [Header("Pages")]
    public IntroductionPages[] introPages;
    private int[] indexPages = {};
    private int lastIndex = 0;
    #endregion
    #region Events
    private void Start(){
        lastIndex = 0;
        indexPages = new int[introPages.Length];
        navigator.haveBounds = true;
    }
    public override void Init()
    {
        navigator.SetPages(introPages[0].GetObjectsRef());
    }
    private void Update()
    {
        ControlCheck();
    }
    #endregion
    #region Methods

    private void ControlCheck()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) return;

        KeyPlayer keyPress = ControlSystem.KnowKey(KeyPlayer.LEFT, KeyPlayer.RIGHT);

        //si presionan derecha o izq cambiamos la pagina
        if (ControlSystem.KeyExist(keyPress)){
            navigator._NavigateTo(keyPress.Equals(KeyPlayer.RIGHT));
        }
    }

    /// <summary>
    /// Cambiamos de entre las paginas
    /// Solo si este cambio es distinto
    /// </summary>
    public void ChangePagesTo(int i){
        if (!lastIndex.Equals(i)){

            //Actualizamos el ultimo indice
            indexPages[lastIndex] = navigator.GetIndexActual();

            menuInputC.lastIndex = i;

            lastIndex = i;

            //Colocamos als nuevas paginas
            navigator.SetPages(introPages[i].GetObjectsRef(), indexPages[i]);

            introPages[i].ReloadPage(indexPages[i]);
        }
    }
    #endregion
}