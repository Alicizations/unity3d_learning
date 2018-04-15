using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{


    public class move : MonoBehaviour
    {
        public float speed = 5.0f;

        public void Strat()
        {
            
        }

        // move
        public void Update()
        {
            if (Director.GetInstance().CurrentScenceController.GetMoving())
            {
                if (Director.GetInstance().CurrentScenceController.GetFrom())
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(-5, 1, 0), speed * Time.deltaTime);
                    if (this.transform.position == new Vector3(-5, 1, 0))
                    {
                        Director.GetInstance().CurrentScenceController.ChangeFrom();
                        Director.GetInstance().CurrentScenceController.StopMoving();
                        // check win
                    }
                }
                else
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(5, 1, 0), speed * Time.deltaTime);
                    if (this.transform.position == new Vector3(5, 1, 0))
                    {
                        Director.GetInstance().CurrentScenceController.ChangeFrom();
                        Director.GetInstance().CurrentScenceController.StopMoving();
                        // check win
                    }
                }
            }
        }
    }
}