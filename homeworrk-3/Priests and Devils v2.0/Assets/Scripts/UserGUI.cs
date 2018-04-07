using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{

    public class UserGUI : MonoBehaviour
    {
        private UserAction action;
        public int status = 0;
        public int step = 0;
        GUIStyle style;
        GUIStyle buttonStyle;

        void Start()
        {
            action = Director.GetInstance().CurrentScenceController as UserAction;

            style = new GUIStyle();
            style.fontSize = 40;
            style.alignment = TextAnchor.MiddleCenter;


            buttonStyle = new GUIStyle("button");
            buttonStyle.fontSize = 30;
        }
        void OnGUI()
        {
            GUI.Label(new Rect(50, 85, 100, 50), "Step: " + this.step);
            if (status == 2)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    status = 0;
                    action.restart();
                }
            }
            else if (status == 1)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
                {
                    status = 0;
                    step = 0;
                    action.restart();
                }
            }
        }
    }
}