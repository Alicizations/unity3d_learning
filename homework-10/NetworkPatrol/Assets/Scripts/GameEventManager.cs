using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {

    //分数变化
    public delegate void ScoreEvent();
    public static event ScoreEvent ScoreChange;
    //游戏结束变化
    public delegate void GameoverEvent();
    public static event GameoverEvent GameoverChange;
    //锁定玩家
    public delegate void LockPlayer();
    public static event LockPlayer LockChange;
    //玩家逃脱
    public delegate void UnlockPlayer();
    public static event UnlockPlayer UnlockChange;

    //玩家进入范围
    public void PlayerIn()
    {
        if (LockChange != null)
        {
            LockChange();
        }
    }

    //玩家逃脱
    public void PlayerEscape()
    {
        if (ScoreChange != null)
        {
            ScoreChange();
        }
        if (UnlockChange != null)
        {
            UnlockChange();
        }
    }

    //玩家被捕
    public void PlayerGameover()
    {
        if (GameoverChange != null)
        {
            GameoverChange();
        }
    }
    
}
