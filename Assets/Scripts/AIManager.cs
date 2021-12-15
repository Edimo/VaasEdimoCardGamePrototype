using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private TurnManager turnManager;
    private boardManager boardManager;
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        boardManager = GameObject.Find("BoardManager").GetComponent<boardManager>();
    }

    public void ResolveInvocsAttack()
    {
        if(boardManager.cardsOnBoard.Count == 0)
        {
            Debug.Log("NO CARDS ON BOARD :  ENNEMY TURN");
            turnManager.turnState = TurnManager.TurnState.ENEMYTURN;
            return;
        }
        for(int i = 0; i <= boardManager.cardsOnBoard.Count; i++)
        {
            Debug.Log("goblin has " + boardManager.enemiesOnBoard[0].GetComponent<Card>().hp + " HP ");
            
            boardManager.cardsOnBoard[i].GetComponent<Card>().Attack(boardManager.enemiesOnBoard[0]);
            Debug.Log("Card : " + boardManager.cardsOnBoard[i].GetComponent<Card>().cardName + " attacks " + boardManager.enemiesOnBoard[0].GetComponent<Card>().cardName + " and goblin has " + boardManager.enemiesOnBoard[0].GetComponent<Card>().hp + " left. ") ;
            //Check if ennemy 0 is dead;
        }
        Debug.Log("End of attacks");
    }

    public void ResolveEnemiesAttacks()
    {

    }

}
