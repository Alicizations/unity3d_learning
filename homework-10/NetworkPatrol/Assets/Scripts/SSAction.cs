using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public enum SSActionEventType : int { Started, Competeted}

    public interface ISSActionCallback
    {
        void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
            int intParam = 0, string strParam = null, Object objectParam = null);
    }


    public class SSAction : ScriptableObject {

        public bool enable = true;
        public bool destroy = false;

        public GameObject gameobject { get; set; }
        public Transform transform { get; set; }
        public ISSActionCallback callback { get; set; }

        protected SSAction()
        {

        }

        // Use this for initialization
        public virtual void Start() {

        }

        // Update is called once per frame
        public virtual void Update() {

        }
    }

    public class CCMoveToAction : SSAction
    {
        public Vector3 target;
        public float speed;

        public static CCMoveToAction GetSSAction(Vector3 t, float s)
        {
            CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction>();
            action.target = t;
            action.speed = s;
            return action;
        }

        public override void Start()
        {
            //this.Update();
            Debug.Log(gameobject.name + "   " + this.target);
        }

        public override void Update()
        {
            this.gameobject.transform.position = Vector3.MoveTowards(this.gameobject.transform.position, this.target, this.speed*Time.deltaTime);
            if (this.gameobject.transform.position == this.target)
            {
                // waiting for destroy
                this.destroy = true;
                this.callback.SSActionEvent(this);
            }
        }


    }

    public class CCSequenceAction : SSAction, ISSActionCallback
    {
        public List<SSAction> sequence;
        public int repeat = -1;
        // -1 repeat forever
        public int start = 0;

        public static CCSequenceAction GetSSAction(int repeat, int start, List<SSAction> s)
        {
            CCSequenceAction action = ScriptableObject.CreateInstance<CCSequenceAction>();
            action.repeat = repeat;
            action.start = start;
            action.sequence = s;
            return action;
        }

        public override void Update()
        {
            if (sequence.Count == 0)
            {
                return;
            }
            if (start < sequence.Count)
            {
                sequence[start].Update();
            }
        }

        public override void Start()
        {
            foreach (var action in sequence)
            {
                action.gameobject = this.gameobject;
                action.transform = this.transform;
                action.callback = this;
                action.Start();
            }
        }

        public void SSActionEvent(SSAction s, SSActionEventType e = SSActionEventType.Competeted,
            int intParam = 0, string strParam = null, Object objectParam = null)
        {
            s.destroy = false;
            this.start++;
            if (this.start >= sequence.Count)
            {
                this.start = 0;
                if (repeat > 0)
                {
                    repeat--;
                }
                if (repeat == 0)
                {
                    this.destroy = true;
                    this.callback.SSActionEvent(this);
                }
            }
        }

        void OnDestroy()
        {
            // some thing
        }

    }

}