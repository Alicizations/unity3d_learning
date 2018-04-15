using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public class CCActionManager : SSActionManager, ISSActionCallback
    {
        public FirstController SceneController;

        public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted, int intParam = 0, string strParam = null, Object objectParam = null)
        {

        }

        protected new void Start()
        {
            //SceneController = (FirstController)Director.GetInstance().CurrentScenceController;
            //SceneController.actionManager = this;
        }

        protected new void Update()
        {
            
        }
    }
}
