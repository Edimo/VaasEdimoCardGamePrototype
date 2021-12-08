using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardManager : MonoBehaviour
{

    public GameObject playerZone;

    public GameObject enemyZone;


    public int playerBoardSize = 8;

    public int enemyBoardSize = 8;

    public void Start()
    {
        playerZone = GameObject.Find("PlayerZone");
        enemyZone = GameObject.Find("MonsterZone");
        board playerBoard = new board(playerBoardSize, playerZone);
        board enemyBoard = new board(enemyBoardSize, enemyZone);
    }

    public void initiateBoard()
    {

    }

    public void createEmptyCardsSockets()
    {

    }
}
