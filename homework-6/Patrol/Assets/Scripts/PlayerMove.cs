using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float Speed = 10f;
    public bool Jumping = false;
    public bool CanMove = true;

    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;
    [SerializeField] private float m_jumpForce = 7;

    private float m_currentV = 0;
    private float m_currentH = 0;
    private Vector3 m_currentDirection = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        if (!CanMove)
        {
            return;
        }
        m_animator.SetBool("Grounded", !Jumping);
        DirectUpdate();
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * 10);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * 10);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * 30);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * Speed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        //bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (Jumping)
        {
            Jumping = this.transform.position.y == 0 ? false : true;
        }
        else
        {
            Jumping = this.transform.position.y > 3 ? true : false;
        }

        if (!Jumping && Input.GetKeyDown(KeyCode.Space))
        {
            //m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            Jumping = true;
        }

        if (!Jumping)
        {
            m_animator.SetTrigger("Land");
        }
        else
        {
            m_animator.SetTrigger("Jump");
        }
    }
}
