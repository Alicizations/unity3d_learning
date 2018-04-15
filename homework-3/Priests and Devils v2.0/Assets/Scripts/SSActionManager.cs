using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public class SSActionManager : MonoBehaviour
    {
        private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
        private List<SSAction> waitingAdd = new List<SSAction>();
        private List<int> waitingDelete = new List<int>();

        void Start()
        {
            // init
        }

        protected void Update()
        {
            //Debug.Log(waitingAdd.Count);
            //Debug.Log("1");
            foreach (SSAction ac in waitingAdd)
            {
                Debug.Log("111");
                actions[ac.GetInstanceID()] = ac;
            }
            waitingAdd.Clear();

            foreach (KeyValuePair<int, SSAction> kv in actions)
            {
                Debug.Log("222");
                SSAction ac = kv.Value;
                if (ac.destroy)
                {
                    waitingDelete.Add(ac.GetInstanceID());
                }
                else if (ac.enable)
                {
                    ac.Update();
                }
            }

            foreach (var key in waitingDelete)
            {
                SSAction ac = actions[key];
                actions.Remove(key);
                DestroyObject(ac);
            }
            waitingDelete.Clear();
        }

        public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager)
        {
            Debug.Log(action);
            action.gameobject = gameobject;
            action.transform = gameobject.transform;
            action.callback = manager;
            waitingAdd.Add(action);
            action.Start();
        }

        

    }
}
