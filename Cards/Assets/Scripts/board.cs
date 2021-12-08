using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board
{
    public int boardSize;

    public List<Card> cardsOnBoard;

    public Dictionary<int, int> cardsPositions;

    public List<GameObject> cardObjectsOnBoard = new List<GameObject>();

    public GameObject zone;

    public board(List<Card>cards, GameObject zone)
    {
        cardsOnBoard = cards;
    }

    public board(int boardSize, GameObject zone)
    {
        this.boardSize = boardSize;
    }

    public board(int boardSize, List<Card> cards, GameObject zone)
    {
        this.boardSize = boardSize;
        cardsOnBoard = cards;
    }

    /// <summary>
    /// You give an int that represent the amount of extra card socket this board is gonna get
    /// </summary>
    /// <param name="emptyCardSocket">Numbers of card socket you want to add to this board</param>
    /// <returns></returns>
    public int addBoardSize(int emptyCardSocket)
    {
        if (emptyCardSocket >=0)
        {
            boardSize += emptyCardSocket;
            return boardSize;
        }
        
        return boardSize;
    }

    /// <summary>
    /// You give an int that represent the amount of extra card socket this board is gonna get
    /// </summary>
    /// <param name="emptyCardSocket">Numbers of card socket you want to take away from this board</param>
    /// <returns></returns>
    public int diminishBoardSize(int emptyCardSocket)
    {
        if (emptyCardSocket >= 0)
        {
            boardSize -= emptyCardSocket;
            return boardSize;
        }

        return boardSize;
    }

    public Dictionary<int, int> GetCardsPositions()
    {

        return cardsPositions;
    }

}
