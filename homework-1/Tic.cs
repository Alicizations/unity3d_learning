using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tic : MonoBehaviour {

    public Texture computer;
    public Texture player;
    private char[][] matrix;
    private bool win;
    private int count;
    private char winner;

    private void Start()
    {
        init();
    }

    private void init()
    {
        win = false;
        count = 0;
        winner = 'n';
        matrix = new char[3][];
        for (int i = 0; i < 3; i++)
        {
            matrix[i] = new char[3];
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrix[i][j] = 'n';
            }
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(90, 10, 200, 20), "Tic Tac Toe");
        if (GUI.Button(new Rect(50, 210, 150, 30), "Restart"))
        {
            init();
        }
        if (win)
        {
            if (winner == 'p')
            {
                GUI.Label(new Rect(100, 10, 200, 20), "You Win!");
            }
            else
            {
                GUI.Label(new Rect(100, 30, 200, 20), "You lose!");
            }
        }
        else if (!win && count == 9)
        {
            GUI.Label(new Rect(100, 10, 200, 20), "Draw!");
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix[i][j] == 'p')
                {
                    if (GUI.Button(new Rect(50*(i+1), 50*(j+1), 50, 50), player))
                    {
                        Debug.Log("player");
                    }
                }
                else if (matrix[i][j] == 'c')
                {
                    if (GUI.Button(new Rect(50 * (i + 1), 50 * (j + 1), 50, 50), computer))
                    {
                        Debug.Log("computer");
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(50 * (i + 1), 50 * (j + 1), 50, 50), "") && !win)
                    {
                        count++;
                        matrix[i][j] = 'p';
                        Debug.Log("matrix[" + i + "][" + j + "]");
                        checkWin('p');
                        if (!win && count < 9)
                        {
                            ComputerPlay(i, j);
                        }
                    }
                }
            }
        }
    }

    private void checkWin(char c)
    {
        if (matrix[0][0] == c)
        {
            if (matrix[0][1] == c && matrix[0][2] == c)
            {
                win = true;
            }
            if (matrix[1][0] == c && matrix[2][0] == c)
            {
                win = true;
            }
            if (matrix[1][1] == c && matrix[2][2] == c)
            {
                win = true;
            }
        }
        if (matrix[0][2] == c)
        {
            if (matrix[1][2] == c && matrix[2][2] == c)
            {
                win = true;
            }
            if (matrix[1][1] == c && matrix[2][0] == c)
            {
                win = true;
            }
        }
        if (matrix[2][1] == c)
        {
            if (matrix[1][1] == c && matrix[0][1] == c)
            {
                win = true;
            }
            if (matrix[2][0] == c && matrix[2][2] == c)
            {
                win = true;
            }
        }
        if ((matrix[1][0] == c) && (matrix[1][1] == c) && matrix[1][2] == c)
        {
            win = true;
        }
        if (win)
        {
            winner = c;
        }
    }


    private void ComputerPlay(int i, int j)
    {
        bool flag = true;
        int ti = UnityEngine.Random.Range(0, 2);
        int tj = UnityEngine.Random.Range(0, 2);
        while (flag)
        {
            if (matrix[ti][tj] == 'n')
            {
                flag = false;
                matrix[ti][tj] = 'c';
                checkWin('c');
                count++;
            }
            else
            {
                ti = UnityEngine.Random.Range(0, 3);
                tj = UnityEngine.Random.Range(0, 3);
            }
        }
    }
}
