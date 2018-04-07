using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{


    public class CoastController 
    {
        public GameObject Coast;
        public Vector3 CoastPosition;
        public Vector3[] Positions;
        public bool Type;
        // false 为起点, true 为终点

        public CoastController(bool type)
        {
            this.Type = type;
            if (this.Type == false)
            {
                this.CoastPosition = new Vector3(9, 1, 0);
                this.Positions = new Vector3[] { new Vector3(6.5F, 2.25F, 0), new Vector3(7.5F, 2.25F, 0), new Vector3(8.5F, 2.25F, 0) };
            }
            else
            {
                this.CoastPosition = new Vector3(-9, 1, 0);
                this.Positions = new Vector3[] { new Vector3(-6.5F, 2.25F, 0), new Vector3(-7.5F, 2.25F, 0), new Vector3(-8.5F, 2.25F, 0) };
            }
        }
    }
}