using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardManager : MonoBehaviour
{
    private Portal portal;
    public GameObject playerZone;

    public GameObject enemyZone;

    public List<GameObject> cardsOnBoard = new List<GameObject>();
    public List<GameObject> enemiesOnBoard = new List<GameObject>();

    private TurnManager turnManager;

    public int maxPlayerBoardSize = 5;
    public int maxEnemyBoardSize = 5;

    public void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        portal = GameObject.Find("Portal").GetComponent<Portal>();
        Debug.Log("Start of Board Manager");
        board playerBoard = new board(maxPlayerBoardSize, playerZone);
        board enemyBoard = new board(maxEnemyBoardSize, enemyZone);
    }

    public void initiateBoard()
    {

    }

    /*public void ResolveInvocsAttacks()
    {
        if (cardsOnBoard.Count == 0)
        {
            Debug.Log("NO CARDS ON BOARD :  ENNEMY TURN");
            turnManager.turnState = TurnManager.TurnState.ENEMYTURN;
            return;
        }
        for (int i = 0; i <= cardsOnBoard.Count; i++)
        {
            Debug.Log(enemiesOnBoard[0].GetComponent<Card>().name + " has " + enemiesOnBoard[0].GetComponent<Card>().hp + " HP ");
            
            if (!cardsOnBoard[i].GetComponent<Card>().Attack(enemiesOnBoard))
            {
                Destroy(enemiesOnBoard[0]);
                enemiesOnBoard.RemoveAt(0);

                if(enemiesOnBoard.Count == 0)
                {
                    portal.intensity++;
                    turnManager.turnState = TurnManager.TurnState.PORTALTURN;                   
                    return;
                }
            }
        }
        Debug.Log("End of attacks");
    }*/

    public void createEmptyCardsSockets()
    {

    }
}
