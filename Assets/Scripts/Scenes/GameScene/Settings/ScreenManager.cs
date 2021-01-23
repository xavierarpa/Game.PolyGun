﻿#region imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavLib;
#endregion
/// <summary>
//TODO
/// Encargarse de las actualización de cada pantallas y HUD correspondientemente
/// </summary>
public class ScreenManager : MonoX
{
    #region variables

    [Header("Screen Settings")]
    public GameStatus lastGameStatus = GameStatus.ON_GAME;

    [Header("Screens")]
    public GameObject HUDScreen;
    public GameObject pauseScreen;
    public GameObject endScreen;


    [Header("End Settings")]
    public AchievementItem[] endItems;



    [Header("Debug")]
    public bool _Debug_LoadEnd = false;
    #endregion
    #region events
    private void Start(){
        ActiveScreenOf();
        lastGameStatus = GameStatus.ON_GAME;
    }
    private void Update(){


        StatusChange();

        _Debug();
    }
    #endregion
    #region methods

    /// <summary>
    /// Revisa si ha cambiado el estado de <see cref="GameStatus"/> de <see cref="GameManager"/>,
    /// de ser así ejecuta lo correspondiente
    /// </summary>
    private void StatusChange(){
        //si el estado NO es igual entonces cambia
        if (!lastGameStatus.Equals(GameManager.GetGameStatus())){
            //actualizamos la variable
            lastGameStatus = GameManager.GetGameStatus();

            //Activamos la pantalla
            ActiveScreenOf(lastGameStatus);

            //Actualizamos el estado, dependiendo del cambio
            //Time.timeScale = GameManager.IsOnGame() ? 1 : 0;



        }
    }
    /// <summary>
    /// Abre la pantalla de opxiones
    /// </summary>
    public void OptionOpen()
    {
        OptionSystem.OpenClose(true);
    }


    /// <summary>
    /// Activamos la pantalla correspondiente al estado que se encuentran
    /// </summary>
    private void ActiveScreenOf(int v) => XavHelpTo.Change.ActiveObjectsExcept(v, HUDScreen, pauseScreen, endScreen);
    private void ActiveScreenOf(GameStatus v = GameStatus.ON_GAME) => ActiveScreenOf((int)v);



    /// <summary>
    /// Revisa los debugs...?
    /// </summary>
    private void _Debug()
    {
        if (!DebugFlag(ref _Debug_LoadEnd)) return;

        foreach (AchievementItem i in endItems)
        {
            AchieveSystem.Setitem(XavHelpTo.Get.ZeroMax(10), i);
        }
    }
    #endregion
}