using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{
    public class ClickGUI : MonoBehaviour
    {
        UserAction action;
        CharController characterController;

        public void setController(CharController characterCtrl)
        {
            characterController = characterCtrl;
        }

        void Start()
        {
            action = Director.GetInstance().CurrentScenceController as UserAction;
        }

        void OnMouseDown()
        {
            //Debug.Log(gameObject.name);
            if (gameObject.name == "boat")
            {
                action.MoveBoat();
            }
            else
            {
                action.characterIsClicked(characterController);
            }
        }
    }
}