using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public class CCActionManager : SSActionManager, ISSActionCallback, IActionManager
    {
        //public FirstController SceneController;
        //private GameObject d;

        public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
            int intParam = 0, string strParam = null, Object objectParam = null)
        {

        }

        public void PlayDisk(GameObject disk, Vector3 initPosition)
        {
            disk.transform.position = initPosition;
            disk.transform.GetComponent<Rigidbody>().useGravity = false;
            //this.Update();
            UFOAction ac = UFOAction.GetUFOAction(disk.GetComponent<Disk>().direction * disk.GetComponent<Disk>().speed, Vector3.down * 9.8f);
            RunAction(disk, ac, this);
        }

        protected new void Start()
        {
            //SceneController = (FirstController)Director.GetInstance().CurrentScenceController;
            //SceneController.actionManager = this;
        }

        protected new void Update()
        {
            base.Update();
        }
    }

    public class UFOAction : SSAction
    {
        public Vector3 speed;
        public Vector3 force;

        public static UFOAction GetUFOAction(Vector3 t, Vector3 s)
        {
            UFOAction action = ScriptableObject.CreateInstance<UFOAction>();
            action.speed = t;
            action.force = s;
            return action;
        }

        public override void Start()
        {
            this.enable = true;
        }

        public override void Update()
        {
            if (gameobject != null && gameobject.activeInHierarchy == true)
            {
                gameobject.transform.Translate(speed * Time.deltaTime);
                gameobject.transform.GetComponent<Rigidbody>().AddForce(force);
            }
            else
            {
                this.enable = false;
                this.destroy = true;
                gameobject.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
