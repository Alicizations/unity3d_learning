using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{

    public class UserGUI : MonoBehaviour
    {
        private UserAction action;
        public int status = 1;
        //0 为游戏结束 1 为游戏进行中
        public float Score = -1;
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

        private void Update()
        {
            
        }

        void OnGUI()
        {
            GUI.Label(new Rect(50, 50, 100, 50), "Score: " + this.Score);
            if (status == 0)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 300, 100, 50), "Game Over!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart"))
                {
                    this.status = 1;
                    this.Score = -1;
                    action.restart();
                }
            }
        }
    }
}