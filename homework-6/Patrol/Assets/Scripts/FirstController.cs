using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;
using System;

public class FirstController : MonoBehaviour, ISceneController, UserAction {
    
    UserGUI userGUI;
    private Queue<GameObject> Patrols = new Queue<GameObject>();
    public GameObject Player;

    public PatrolFactory Factory;
    public CCActionManager ActionManager;

    public int InArea = 5;

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
        LoadPlane();
        LoadOutWall();
        LoadWall();
        
        //Debug.Log("loading");
    }

    private void LoadPatrol()
    {
        int num = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i != 1 || j != 1)
                {
                    var p = Factory.GetPatrol();
                    p.SetActive(true);
                    p.GetComponent<Patrol>().Catch = false;
                    p.GetComponent<Patrol>().Hit = false;
                    p.GetComponent<Patrol>().Lock = false;
                    p.transform.position = new Vector3(-10 + 10 * i, 0, -10 + 10 * j);
                    Patrols.Enqueue(p);
                    p.GetComponent<Patrol>().Num = num;
                    GameEventManager.LockChange += p.GetComponent<Patrol>().LockPlayer;
                    GameEventManager.UnlockChange += p.GetComponent<Patrol>().LosePlayer;
                    ActionManager.PatrolGo(p);
                }
                num++;
            }
        }
    }

    private void LoadWall()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("WallY"), new Vector3(-5 + 10 * i, 1, -13 + 10 * j), Quaternion.identity);
                GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("WallY"), new Vector3(-5 + 10 * i, 1, -7 + 10 * j), Quaternion.identity);
                GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("WallX"), new Vector3(-13 + 10 * j, 1, -5 + 10 * i), Quaternion.identity);
                GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("WallX"), new Vector3(-7 + 10 * j, 1, -5 + 10 * i), Quaternion.identity);
            }
        }
    }

    private void LoadOutWall()
    {
        for (int i = -16; i < 18; i=i+32)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("OutWallY"), new Vector3(i, 1, -12.5f + j * 5), Quaternion.identity);
                GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("OutWallX"), new Vector3(-12.5f + j * 5, 1, i), Quaternion.identity);
            }
        }
    }

    private void LoadPlane()
    {
        GameObject t = null;
        int Num = 1;
        for (int i = -10; i < 11; i=i+10)
        {
            for (int j = -10; j < 11; j=j+10)
            {
                t = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Plane"), new Vector3(i, 0, j), Quaternion.identity);
                t.GetComponent<AreaController>().Sign = Num;
                Num++;
            }
        }
    }

    public void restart()
    {
        while (Patrols.Count > 0)
        {
            var p = Patrols.Dequeue();
            GameEventManager.LockChange -= p.GetComponent<Patrol>().LockPlayer;
            GameEventManager.UnlockChange -= p.GetComponent<Patrol>().LosePlayer;
            Factory.FreePatrol(p);
        }
        LoadPatrol();
        Player.GetComponent<PlayerMove>().CanMove = true;
        Player.transform.position = new Vector3(0, 1, 0);
    }


    // Use this for initialization
    void Start () {
        Factory = Singleton<PatrolFactory>.Instance;
        ActionManager = Singleton<CCActionManager>.Instance;
        LoadPatrol();
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.transform.position.y < -10 || Player.transform.position.y > 13)
        {
            Singleton<GameEventManager>.Instance.PlayerGameover();
        }
	}

    void OnEnable()
    {
        //注册事件
        GameEventManager.ScoreChange += AddScore;
        GameEventManager.GameoverChange += GameOver;
    }

    void OnDisable()
    {
        //取消注册事件
        GameEventManager.ScoreChange -= AddScore;
        GameEventManager.GameoverChange -= GameOver;
    }

    private void AddScore()
    {
        userGUI.Score++;
    }

    private void GameOver()
    {
        userGUI.status = 0;
        Player.GetComponent<PlayerMove>().CanMove = false;
        foreach(var i in Patrols)
        {
            i.GetComponent<Patrol>().Catch = true;
        }
    }
}
