using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mygame;
using UnityEngine.Networking;

public class Score : NetworkBehaviour
{
    public const int minHealth = 0;
    [SyncVar]
    public int health = minHealth;

    public void AddScore(int amount)
    {
        if (!isServer)
        {
            return;
        }
        health += amount;
        Debug.Log("health value = " + health.ToString());
        if (health >= 100)
        {
            health = 100;
            Debug.Log("win!");
        }
        if (health <= 0)
        {
            health = 0;
        }
    }
}
