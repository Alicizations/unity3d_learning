using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public class CCActionManager : SSActionManager, ISSActionCallback
    {
        public FirstController SceneController;
        public CCMoveToAction moveToA, moveToB;

        public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted, int intParam = 0, string strParam = null, Object objectParam = null)
        {
            //throw new System.NotImplementedException();
            Director.GetInstance().CurrentScenceController.ChangeFrom();
            Director.GetInstance().CurrentScenceController.StopMoving();
            moveToA = null;
            moveToB = null;
        }

        protected void Start()
        {
            SceneController = (FirstController)Director.GetInstance().CurrentScenceController;
            SceneController.actionManager = this;

            //moveToA = CCMoveToAction.GetSSAction(new Vector3(-5, 1, 0), 5f);
            //this.RunAction(SceneController.boat.boat, moveToA, this);


        }

        protected new void Update()
        {
            //base.Update();
            //Debug.Log("go  "+ Director.GetInstance().CurrentScenceController.GetMoving());
            if (Director.GetInstance().CurrentScenceController.GetMoving())
            {
                if (Director.GetInstance().CurrentScenceController.GetFrom())
                {
                    if (moveToA == null)
                    {
                        moveToA = CCMoveToAction.GetSSAction(new Vector3(-5, 1, 0), 5f);
                        this.RunAction(SceneController.boat.boat, moveToA, this);
                    }
                }
                else
                {
                    if (moveToB == null)
                    {
                        moveToB = CCMoveToAction.GetSSAction(new Vector3(5, 1, 0), 5f);
                        this.RunAction(SceneController.boat.boat, moveToB, this);
                    }
                }
            }
            base.Update();
        }
    }
}
