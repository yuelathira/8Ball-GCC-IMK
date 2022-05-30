using UnityEngine;
using UnityEngine.UI;

public class StatusUi : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Text player, ballLeft, jenis;
    
    void Update()
    {
        if (gameManager.player == GameManager.players.player1)
        {
            player.text = "Player 1";
            ballLeft.text = gameManager.player1BallCount.ToString() + " - Bola Tersisa";
            switch (gameManager.ball1)
            {
                case GameManager.balls.color:
                    jenis.text = "Solid";
                    break;

                case GameManager.balls.variant:
                    jenis.text = "Stripe";
                    break;
            }
        }
        else
        {
            player.text = "Player 2";
            ballLeft.text = gameManager.player2BallCount.ToString() + " - Bola Tersisa";
            switch (gameManager.ball2)
            {
                case GameManager.balls.color:
                    jenis.text = "Solid";
                    break;

                case GameManager.balls.variant:
                    jenis.text = "Stripe";
                    break;
            }
        }
    }
}
