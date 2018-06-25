using UnityEngine;
using UnityEngine.Networking;
using Mygame;

public class EnemySpawner : NetworkBehaviour
{

    //public GameObject enemyPrefab;
    public FirstController fc = (FirstController)Director.GetInstance().CurrentScenceController;

    public override void OnStartServer()
    {
        int num = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i != 1 && j != 1)
                {
                    Debug.Log("in");
                    var p = Singleton<PatrolFactory>.Instance.GetPatrol();
                    p.SetActive(true);
                    p.GetComponent<Patrol>().Catch = false;
                    p.GetComponent<Patrol>().Hit = false;
                    p.GetComponent<Patrol>().Lock = false;
                    p.transform.position = new Vector3(-10 + 10 * i, 0, -10 + 10 * j);
                    fc.Patrols.Enqueue(p);
                    p.GetComponent<Patrol>().Num = num;
                    GameEventManager.LockChange += p.GetComponent<Patrol>().LockPlayer;
                    GameEventManager.UnlockChange += p.GetComponent<Patrol>().LosePlayer;
                    Singleton<CCActionManager>.Instance.PatrolGo(p);
                    NetworkServer.Spawn(p);
                }
                num++;
            }
        }
    }
}