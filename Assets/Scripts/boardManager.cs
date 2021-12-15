using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardManager : MonoBehaviour
{

    public GameObject playerZone;

    public GameObject enemyZone;

    public List<GameObject> cardsOnBoard = new List<GameObject>();
    public List<GameObject> enemiesOnBoard = new List<GameObject>();

    public int maxPlayerBoardSize = 5;
    public int maxEnemyBoardSize = 5;

    public void Start()
    {
        Debug.Log("Start of Board Manager");
        board playerBoard = new board(maxPlayerBoardSize, playerZone);
        board enemyBoard = new board(maxEnemyBoardSize, enemyZone);
    }

    public void initiateBoard()
    {

    }

    public void createEmptyCardsSockets()
    {

    }
}
