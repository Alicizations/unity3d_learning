using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour {

    public Sprite source;
    public Sprite aim;

    public Transform mtrans;

    public bool init = true;

    public GameObject relative;

    public GameObject p;
    public ParticleSystem ss;

     void Awake()
    {
        mtrans = this.transform;
        if (p != null)
        {
            ss = p.GetComponent<ParticleSystem>();
        }
    }


    public void On_Click()
    {
        if (init)
        {
            mtrans.GetComponent<Image>().sprite = aim;
            init = false;
            relative.GetComponent<OnButtonClick>().initial();
        }
    }

    public void initial()
    {
        mtrans.GetComponent<Image>().sprite = source;
        init = true;
        if (ss != null)
        {
            ss.Play();
        }
    }

    // Use this for initialization
     void Start () {
        if (ss != null)
        {
            ss.Stop();
        }
    }
	
	// Update is called once per frame
	 void Update () {
		
	}
}
