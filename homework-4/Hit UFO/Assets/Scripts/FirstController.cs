using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;

public class FirstController : MonoBehaviour, ISceneController, UserAction {

    public bool Playing;
    private int Round = 1;
    private float time = 0;
    private int DiskFlyOneTime;
    UserGUI userGUI;
    private Queue<GameObject> Disks = new Queue<GameObject>();

    private static int max = 9;
    private static int min = 2;
    private Vector3[] position = new Vector3[max];

    public DiskFactory Factory;

    // public CCActionManager actionManager;

    void Awake()
    {
        Director director = Director.GetInstance();
        director.CurrentScenceController = this;
        director.CurrentScenceController.LoadResources();
        userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
        for (int i = 0; i < max; i++)
        {
            position[i] = new Vector3(4-2*i, 4-2*i, -7);
        }
    }

    // 加载资源
    public void LoadResources()
    {
        //GameObject water = Instantiate(Resources.Load("Perfabs/Water", typeof(GameObject)), new Vector3(0, 0.5F, 0), Quaternion.identity, null) as GameObject;
        //water.name = "water";  
    }

    public void restart()
    {
        this.Round = 1;
        this.Playing = false;
        this.time = 0;
    }


    // Use this for initialization
    void Start () {
        Factory = Singleton<DiskFactory>.Instance; 
    }
	
	// Update is called once per frame
	void Update () {
        if (userGUI.status == 1)
        {
            if (time > 4f)
            {
                RoundOver();
            } else
            {
                time += Time.deltaTime;
                if (this.Playing == false)
                {
                    DiskFlyOneTime = Random.Range(min, max);
                    //Debug.Log(DiskFlyOneTime);
                    GameObject temp;
                    for (int i = 0; i < DiskFlyOneTime; i++)
                    {
                        //Debug.Log(Factory+"here");
                        temp = Factory.GetDisk(this.Round);
                        temp.transform.position = position[i];
                        temp.transform.GetComponent<Rigidbody>().velocity = temp.GetComponent<Disk>().direction * temp.GetComponent<Disk>().speed;
                        Disks.Enqueue(temp);
                    }
                    this.Playing = true;
                }
            }
        }
	}

    private void RoundOver()
    {
        while(Disks.Count > 0)
        {
            Factory.FreeDisk(Disks.Dequeue());
        }
        this.Round++;
        this.time = 0;
        this.Playing = false;
        if (Round > 10)
        {
            userGUI.status = 0;
        }
    }

    public void hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.collider.gameObject.GetComponent<Disk>() != null)
            {
                Debug.Log("hit");
                hit.collider.gameObject.SetActive(false);
                userGUI.Score += (0.1f * Round + 1) * (0.1f * Round + 1);
            }

        }
    }
}
