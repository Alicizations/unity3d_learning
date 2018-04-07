using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

namespace Mygame
{

    public class CharController
    {
        public GameObject Charater;
        // 0为恶魔,1为牧师
        public int Type;
        public int No;
        public bool CanControl { get; set; }
        public int OnBoat { get; set; }
        // 2为不在船上
        public ClickGUI clickGUI;


        public CoastController coastController;

        public CharController(int type, int num)
        {
            this.Type = type;
            this.No = num;
            this.CanControl = true;
            this.OnBoat = 2;
            
        }

        public void GoCoast()
        {
            this.Charater.transform.position = this.coastController.Positions[this.No]+this.Type*new Vector3(0.5f,0,0);
        }
        
    }
}