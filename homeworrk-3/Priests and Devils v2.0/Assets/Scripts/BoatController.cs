using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{

    public class BoatController
    {
        public GameObject boat;
        public Vector3 BoatPosition;
        public Vector3 fromPosition = new Vector3(5, 1, 0);
        public Vector3 toPosition = new Vector3(-5, 1, 0);
        public Vector3[] FPositions = new Vector3[] { new Vector3(4.5F, 1.5F, 0), new Vector3(5.5F, 1.5F, 0) };
        public Vector3[] TPositions = new Vector3[] { new Vector3(-5.5F, 1.5F, 0), new Vector3(-4.5F, 1.5F, 0) };
        public CharController[] Passenger = new CharController[2];
        public int[] empty; // 1为空
        public bool IsFrom = true;
        // true 是起点
        readonly ClickGUI clickGUI;

        //private float speed = 10.0f;

        public BoatController()
        {
            this.BoatPosition = this.fromPosition;
            this.empty = new int[] { new int(), new int() };
            this.empty[0] = this.empty[1] = 1;
            //this.boat.AddComponent(typeof(ClickGUI));
        }

        public void ChangeFrom()
        {
            if (IsFrom == false)
            {
                IsFrom = true;
            }
            else
            {
                IsFrom = false;
            }
        }

        



        public int SetPassenger(CharController charater)
        {
            if (charater.coastController.Type == this.IsFrom)
            {
                return 2;
            }
            if (this.empty[0] == 1)
            {
                if (this.IsFrom)
                {
                    charater.Charater.transform.position = FPositions[0];
                }
                else
                {
                    charater.Charater.transform.position = TPositions[0];
                }
                this.empty[0] = 0;
                this.Passenger[0] = charater;
                charater.Charater.transform.parent = this.boat.transform;
                return 0;
            }
            else if (this.empty[1] == 1)
            {
                if (this.IsFrom)
                {
                    charater.Charater.transform.position = FPositions[1];
                }
                else
                {
                    charater.Charater.transform.position = TPositions[1];
                }
                this.empty[1] = 0;
                this.Passenger[1] = charater;
                charater.Charater.transform.parent = this.boat.transform;
                return 1;
            }
            return 2;
        }

        public void OffBoat(int x)
        {
            this.empty[x] = 1;
            if (this.Passenger[x] != null)
            {
                this.Passenger[x].Charater.transform.parent = null;
            }
            this.Passenger[x] = null;
        }

    }
}