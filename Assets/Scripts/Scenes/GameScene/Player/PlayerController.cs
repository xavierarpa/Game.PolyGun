﻿#region
using System;
using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;
#endregion
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Equipment))]
[RequireComponent(typeof(Shot))]
///<summary>
/// Manejo de los controles de Player
/// <para>
/// Dependiendo de la tecla presionada buscaremos
/// hacer una acción o otra
/// </para>
///</summary>
public class PlayerController : MonoX
{

    #region Variables
    [Header("Player Movement")]
    public Movement movement;
    private readonly KeyPlayer[] keysHorizontal ={KeyPlayer.RIGHT,KeyPlayer.LEFT,};
    private readonly KeyPlayer[] keysForward ={KeyPlayer.UP,KeyPlayer.DOWN,};

    [Space]
    [Header("Player Equipment")]
    public Equipment equipment;
    private readonly KeyPlayer[] keysObjects = {KeyPlayer.C,KeyPlayer.V,KeyPlayer.B};

    [Header("Player Attack")]
    public Shot shot;
    private readonly KeyPlayer keyAttack = KeyPlayer.OK_FIRE;

    [Header("Player Settings")]
    private readonly KeyPlayer keyPause = KeyPlayer.BACK;

    /*
     * Este script se encarga de detectar las teclas y ejecutar
     * algo correspondiente dependiendo de  la tecla
     * 
     * TODO
     * Encargado de la interacción entre el objeto y el jugador
     * 
     * En este script podrñas saber:
     * 
     * - Disparar
     * 
     * 
     */
    #endregion

    #region Events
    private void Awake()
    {
        //Bro y esto :0
        Get(out movement);
        Get(out equipment);
        Get(out shot);

    }
    private void Update()
    {
        if (GameManager.GetGameStatus().Equals( GameStatus.ON_GAME))
        {
            CheckOnGame();
        }
        Pause();
    }
    #endregion
    #region Methods

    /// <summary>
    /// Detectas los  controles para en juego
    /// </summary>
    private void CheckOnGame(){
        Movement();
    }


        /// <summary>
        /// Movemos la player en la dirección en la que ha tocado las teclas
        /// Se revisa cada tecla presionada por separado para asignar los
        /// valores correspondientes
        /// </summary>
        private void Movement(){
        //Revisamos si hay adiciones por parte de las teclas presionadas
        movement.SetAxis(ControlSystem.GetAxisOf(keysHorizontal), 0, ControlSystem.GetAxisOf(keysForward));
        movement.Move();
    }
    /// <summary>
    /// Detecta si has tocado alguna tecla de equipación, de ser así
    /// ejecuta una acción en <see cref="Equipment"/>
    /// </summary>
    private void Equipment(){

        //Buscamos la primera acciond e objeto selecta
        ControlSystem.KnowKeyIndex(keysObjects);



    }

    private void Attack()
    {

    }

    /// <summary>
    /// Te permitirá entrar y salir de la pantalla de pausa
    /// </summary>
    private void Pause(){
        if (!ControlSystem.KeyDown(keyPause)) return;
        GameStatus actualStatus = GameManager.GetGameStatus().Equals(GameStatus.ON_GAME) ? GameStatus.ON_PAUSE : GameStatus.ON_GAME; 
        GameManager.SetGameStatus(actualStatus);
    }
    
    #endregion
}
