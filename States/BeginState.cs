﻿using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.Interfaces;	// directory of IStateBase

// Assets.Code.States is the cs. directory
// The BeginState file is in the States folder

namespace Assets.Code.States
{
	public class BeginState	: IStateBase	// This is ONE State and implements IStateBase
	{	
		private StateManager manager;		// reference to StateManager class... an object type StateManager
		// manager gets acces to SwitchState() of StateManager
		
	   	/// Constructor ///////////////////////////////////////
		// whenever I create an object of type BeginState, this will be called.
		public BeginState (StateManager managerRef)		// StateManager managerRef now has the parametre THIS
		{	
			// same as StateManager manager, but now with managerRef

			manager = managerRef;
			//Debug.Log("Constructing BeginState");

			if (SceneManager.GetActiveScene().name != "Scene0")
			{
				SceneManager.LoadScene ("Scene0"); 
			}

		}
	   	//////////////////////////////////////////////////////

		// These are methods from the Interface... plus those I want to add.
		public void StateUpdate ()		
		{
			// if (Input.GetKeyUp (KeyCode.Space) )
            // {
            //     manager.SwitchState ( new SetupState (manager) );
            // }

		}

        public void ShowIt ()
		{
			Debug.Log ("In BeginState");

			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			// IMAGEN DE INICIO
			/* 
				public static void DrawTexture (Rect position, Texture image, ScaleMode scaleMode);
			*/
			GUI.DrawTexture (new Rect (0 , 0 , Screen.width, Screen.height) , //Rect position
			
			manager.gameDataRef.blackCurtain,	// Texture image. Con dot syntax obtengo la imagen que alojé en GameData Script
			// manager es el nombre ACA de referencia:	private StateManager manager;
			// public GameData gameDataRef;	está dentro de StateManager.
			// beginStateSplash es una referencia publica: public Texture2D beginStateSplash;

			ScaleMode.StretchToFill );	// ScaleMode scaleMode
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			if (GUI.Button (new Rect(Screen.height/2 , Screen.width/2 , 250 , 60) ,
			"Start"))
			{
				manager.SwitchState ( new SetupState (manager) );
			}

		}

		public void StateFixedUpdate ()
		{

		}

		// private void Switch()
        // {
		// 	SceneManager.LoadScene ("PlayScene_1");		//CAMBIARs

		// 	manager.SwitchState(new PlayState(manager));
    	// }

	}
}