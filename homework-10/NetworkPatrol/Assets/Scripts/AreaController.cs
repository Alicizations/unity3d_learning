﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public class AreaController : MonoBehaviour
    {

        public int Sign = 0;
        FirstController sceneController;

        private void Start()
        {
            sceneController = Director.GetInstance().CurrentScenceController as FirstController;
        }

        public void OnTriggerEnter(Collider collider)
        {
            //Debug.Log("player in");
            if (collider.gameObject.tag == "Player")
            {
                collider.gameObject.GetComponent<Score>().AddScore(10);
                Singleton<GameEventManager>.Instance.PlayerEscape();
                if (Sign != 5)
                {
                    sceneController.InArea = Sign;
                    Singleton<GameEventManager>.Instance.PlayerIn();
                }
            }
        }
        

        //public void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.tag == "Player")
        //    {
        //        sceneController.InArea = Sign;
        //    }
        //}
    }
}
