using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;
using System;

public class FirstController : MonoBehaviour, ISceneController, UserAction {
    
    UserGUI userGUI;
    public GameObject Player;
    private GameObject[] AIs;
    private int AIliving = 4;

    void Awake()
    {
        Director director = Director.GetInstance();
        director.CurrentScenceController = this;
        director.CurrentScenceController.LoadResources();
        userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
    }

    // 加载资源
    public void LoadResources()
    {       
        
    }

    public void restart()
    {
        Player.transform.position = new Vector3(-32, 0, 2.4f);
        Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        Player.SetActive(true);
        for (int i = 0; i < AIs.Length; i++)
        {
            AIs[i].transform.position = new Vector3(20, 0, -5f + 8*i);
            AIs[i].transform.rotation = Quaternion.Euler(0, -90, 0);
            AIs[i].SetActive(true);
        }
        AIliving = 4;
    }


    // Use this for initialization
    void Start () {
        AIs = GameObject.FindGameObjectsWithTag("AI");
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void AddScore()
    {
        userGUI.Score++;
        AIliving--;
        if (AIliving <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        userGUI.status = 0;
    }
}
