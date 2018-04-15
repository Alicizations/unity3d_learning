using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{

    public class UserGUI : MonoBehaviour
    {
        private UserAction action;
        public int status = 2;
        // 2 为游戏刚开始 0 为游戏结束 1 为游戏进行中
        public float Score = 0;
        GUIStyle style;
        GUIStyle buttonStyle;
        private Vector3 scene = new Vector3(48.5f, 14f, 35f);
        private Vector3 scener = new Vector3(0, -90, 0);
        private Vector3 play = new Vector3(0, 1, -10);
        private Vector3 playr = new Vector3(0, 0, 0);

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
            if (Input.GetButtonDown("Fire1"))
            {
                //Debug.Log("fire");
                Vector3 pos = Input.mousePosition;
                action.hit(pos);
            }
        }

        void OnGUI()
        {
            //GUI.skin.button.fontSize = 15;
            if (GUI.Button(new Rect(50, 120, 50, 25), "View"))
            {
                var ca = Camera.main.gameObject;
                if (ca.transform.position == scene)
                {
                    ca.transform.position = play;
                    ca.transform.localRotation = Quaternion.Euler(playr);
                }
                else
                {
                    ca.transform.position = scene;
                    ca.transform.localRotation = Quaternion.Euler(scener);
                }
            }
            GUI.Label(new Rect(50, 85, 100, 50), "Score: " + this.Score);
            if (status == 2)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Hit UFO!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Start"))
                {
                    this.status = 1;
                    this.Score = 0;
                    action.restart();
                }
            }
            else if (status == 0)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Time's up!", style);
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart"))
                {
                    this.status = 1;
                    this.Score = 0;
                    action.restart();
                }
            }
        }
    }
}