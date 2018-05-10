using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mygame
{
    public class Patrol : MonoBehaviour
    {
        // 撞墙
        public bool Hit = false;
        public bool Catch = false;
        // 锁定Player
        public bool Lock = false;
        public int Num = 0;


        private Animator animator;

        const int countOfDamageAnimations = 3;
        int lastDamageAnimation = -1;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Start()
        {
            Stay();
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Catch = true;
                //Debug.Log("catch");
                Singleton<GameEventManager>.Instance.PlayerGameover();
            }
            else
            {
                Hit = true;
            }
            //Debug.Log("111");
        }

        //发现玩家
        public void LockPlayer()
        {
            //Debug.Log("in");
            if (((FirstController)Director.GetInstance().CurrentScenceController).InArea == this.Num)
            {
                //Debug.Log("find");
                this.Lock = true;
            }
        }

        //玩家逃脱
        public void LosePlayer()
        {
            this.Lock = false;
        }

        //动画效果设置
        public void Stay()
        {
            animator.SetBool("Aiming", false);
            animator.SetFloat("Speed", 0f);
        }

        public void Walk()
        {
            animator.SetBool("Aiming", false);
            animator.SetFloat("Speed", 0.5f);
        }

        public void Run()
        {
            animator.SetBool("Aiming", false);
            animator.SetFloat("Speed", 1f);
        }

        public void Attack()
        {
            Aiming();
            animator.SetTrigger("Attack");
        }

        public void Death()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
                animator.Play("Idle", 0);
            else
                animator.SetTrigger("Death");
        }

        public void Damage()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) return;
            int id = Random.Range(0, countOfDamageAnimations);
            if (countOfDamageAnimations > 1)
                while (id == lastDamageAnimation)
                    id = Random.Range(0, countOfDamageAnimations);
            lastDamageAnimation = id;
            animator.SetInteger("DamageID", id);
            animator.SetTrigger("Damage");
        }

        public void Jump()
        {
            animator.SetBool("Squat", false);
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Aiming", false);
            animator.SetTrigger("Jump");
        }

        public void Aiming()
        {
            animator.SetBool("Squat", false);
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Aiming", true);
        }

        public void Sitting()
        {
            animator.SetBool("Squat", !animator.GetBool("Squat"));
            animator.SetBool("Aiming", false);
        }
    }
}