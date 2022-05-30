using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum players {player1, player2};
    public enum balls {none, color, variant};
    public players player = players.player1;
    public balls ball1 = balls.none, ball2 = balls.none;
    public int player1BallCount, player2BallCount;
    [SerializeField] int player1BallLast = 7, player2BallLast = 7;
    public bool player1Pool, player2Pool;
    [SerializeField] GameObject winPanel;
    [SerializeField] Text playerWin;

    void Awake()
    {
        instance = this;
    }

    public void ChangePlayer(players who)
    {
        player = who;
    }

    public void SwitchPlayer()
    {
        switch (player)
        {
            case players.player1:
                player = players.player2;
                break;
            
            case players.player2:
                player = players.player1;
                break;
        }
    }

    public void ChangeBallType(GameObject target)
    {   
        CountBall();
        if (ball1 is balls.none)
        {
            switch (player)
            {
                case players.player1:
                    if (target.tag == "Color") 
                    {
                        ball1 = balls.color;
                        ball2 = balls.variant;
                    }
                    else 
                    {
                        ball1 = balls.variant;
                        ball2 = balls.color;
                    }
                    break;
                
                case players.player2:
                    if (target.tag == "Color") 
                    {
                        ball2 = balls.color;
                        ball1 = balls.variant;
                    }
                    else 
                    {
                        ball2 = balls.variant;
                        ball1 = balls.color;
                    }
                    break;
            }
        }
    }

    void CountBall()
    {
        if (ball1 is balls.color)
        {
            player1BallCount = GameObject.FindGameObjectsWithTag("Warna").Length;
            player2BallCount = GameObject.FindGameObjectsWithTag("Corak").Length;
        }
        else
        {
            player1BallCount = GameObject.FindGameObjectsWithTag("Corak").Length;
            player2BallCount = GameObject.FindGameObjectsWithTag("Warna").Length;
        }
    }

    public void CheckCount()
    {
        switch (player)
        {
            case players.player1:
                if (player1BallCount < player1BallLast && !player1Pool)
                {
                    player1BallLast = player1BallCount;
                }
                else if (player2BallCount < player2BallLast && !player1Pool)
                {
                    SwitchPlayer();
                }
                else
                {
                    SwitchPlayer();
                }
                break;
            
            case players.player2:
                if (player2BallCount < player2BallLast && !player2Pool)
                {
                    player2BallLast = player2BallCount;
                }
                else if (player1BallCount < player1BallLast && !player2Pool)
                {
                    SwitchPlayer();
                }
                else
                {
                    SwitchPlayer();
                }
                break;
        }

        if (player1BallCount == 0)
        {
            player1Pool = true;
        }
        if (player2BallCount == 0)
        {
            player2Pool = true;
        }
    }

    public void Win(players player)
    {
        winPanel.SetActive(true);
        switch (player)
        {
            case players.player1:
                playerWin.text = "Player 1 Win";
                break;

            case players.player2:
                playerWin.text = "Player 2 Win";
                break;
        }
    }
}
