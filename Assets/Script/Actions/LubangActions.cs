using UnityEngine;

public class LubangActions : MonoBehaviour
{ 
    GameManager gameManager;

    void Start() 
    {
        gameManager = GameManager.instance;
    }

    public void OnEnter(GameObject target)
    {
        switch (target.tag)
        {
            case "Player":
                target.transform.localPosition = new Vector3(0, 0, -1);
                target.GetComponent<Rigidbody>().velocity *= 0;
                gameManager.SwitchPlayer();
                break;

            case "8 Ball":
                if (gameManager.player is GameManager.players.player1)
                {
                    if (gameManager.player1Pool)
                    {
                        gameManager.Win(GameManager.players.player1);
                    }
                    else
                    {
                        gameManager.Win(GameManager.players.player2);
                    }
                }
                else
                {
                    if (gameManager.player2Pool)
                    {
                        gameManager.Win(GameManager.players.player2);
                    }
                    else
                    {
                        gameManager.Win(GameManager.players.player1);
                    }
                }
                Destroy(target);
                break;
            
            case "Warna":
                gameManager.ChangeBallType(target);
                Destroy(target);
                break;

            case "Corak":
                gameManager.ChangeBallType(target);
                Destroy(target);
                break;
        }
    }
}
