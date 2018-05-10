using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public class CCActionManager : SSActionManager, ISSActionCallback
    {
        public FirstController SceneController;
        //private GameObject d;

        public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
            int intParam = 0, string strParam = null, Object objectParam = null)
        {
            PatrolAction p = source as PatrolAction;
            p.PatrolData.Hit = false;
            PatrolAction ac = PatrolAction.GetPatrolAction((p.WalkWay+1)%4, p.OriPos);
            RunAction(p.gameobject, ac, this);
        }

        public void PatrolGo(GameObject Patrol)
        {
            //Debug.Log("11");
            int w = Random.Range(0, 4);
            PatrolAction ac = PatrolAction.GetPatrolAction(w, Patrol.transform.position);
            RunAction(Patrol, ac, this);
        }

        protected new void Start()
        {
            SceneController = Director.GetInstance().CurrentScenceController as FirstController;
            SceneController.ActionManager = this;
        }

        protected new void Update()
        {
            base.Update();
        }
    }

    public class PatrolAction : SSAction
    {
        public Vector3 OriPos;
        public Vector3 target;
        public int WalkWay;
        // 0 为上, 1 为左, 2 为下, 3 为右
        public float speed;
        public Patrol PatrolData;

        public static PatrolAction GetPatrolAction(int way, Vector3 o)
        {
            PatrolAction action = ScriptableObject.CreateInstance<PatrolAction>();
            action.OriPos = o;
            action.WalkWay = way;
            action.SetTarget(way);
            return action;
        }

        public override void Start()
        {
            //this.Update();
            //Debug.Log(gameobject.name + "   " + this.target);
            PatrolData = gameobject.GetComponent<Patrol>();
        }

        public override void Update()
        {
            if (PatrolData.Catch == true)
            {
                //Debug.Log("delete");
                PatrolData.Attack();
                this.destroy = true;
                return;
            }
            if (PatrolData.Hit == false)
            {
                PatrolData.Walk();
                speed = 2f;
                if (PatrolData.Lock == true)
                {
                    this.target = ((FirstController)(Director.GetInstance().CurrentScenceController)).Player.transform.position;
                    this.target.y = 0;
                    PatrolData.Run();
                    speed = 4f;
                }
                this.gameobject.transform.LookAt(this.target);
                this.gameobject.transform.position = Vector3.MoveTowards(this.gameobject.transform.position, this.target, speed * Time.deltaTime);
                if (this.gameobject.transform.position == this.target)
                {
                    this.destroy = true;
                    this.callback.SSActionEvent(this);
                }
            }
            else
            {
                this.destroy = true;
                this.callback.SSActionEvent(this);
            }
            
        }

        public void SetTarget(int way)
        {
            float z = 0;
            float x = 0;
            if (way == 0)
            {
                z = Random.Range(0, 4.5f);
                x = Random.Range(-z, z);

            }
            else if (way == 1)
            {
                x = Random.Range(0, 4.5f) * -1;
                z = Random.Range(x, -x);
            }
            else if (way == 2)
            {
                z = Random.Range(0, 4.5f) * -1;
                x = Random.Range(z, -z);
            }
            else
            {
                x = Random.Range(0, 4.5f);
                z = Random.Range(-x, x);
            }
            this.target = new Vector3(x, 0, z) + this.OriPos;
        }
    }


}
