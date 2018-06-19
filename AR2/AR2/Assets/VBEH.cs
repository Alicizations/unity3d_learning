using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBEH : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vb;

    public Animator ani;

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        ani.SetTrigger("on");
        Debug.Log("on");
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        ani.SetTrigger("off");
        Debug.Log("off");
    }

    // Use this for initialization
    void Start () {
        VirtualButtonAbstractBehaviour vbb = vb.GetComponent<VirtualButtonAbstractBehaviour>();
        if (vbb)
        {
            vbb.RegisterEventHandler(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
