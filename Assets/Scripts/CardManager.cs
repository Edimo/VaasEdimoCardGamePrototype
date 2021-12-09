using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour
{
    // Une Liste de toutes les Cartes alliées
    public List<CardSO> playerCards;
    // Une Liste de toutes les Cartes ennemies
    public List<EnemySO> enemiesCards;
    // Liste comprenant toutes les cartes
    public List<Card> allCards;
    // Cards Databases
    public CardDataBaseSO cardsDB;
    public EnemyDataBase enemiesDB;

    /// <summary>
    /// During the start we fill the playerCards and enemiesCards variable with the databases content
    /// </summary>
    public void Start()
    {
        this.playerCards = cardsDB.allCards;
        this.enemiesCards = enemiesDB.allEnemies;
    }

    public void Update()
    {
        
    }

    //public CardManager(CardDataBaseSO cardsDB, EnemyDataBase enemiesDB)
    //{

    //    //this.playerCards = GetAllPlayerCards();
    //    //this.enemiesCards = GetAllEnemiesCards();
    //    //this.allCards = GetAllCards(playerCards, enemiesCards);
    //}

    /// <summary>
    /// Returns a CardSO object from the database filtering by ID
    /// </summary>
    /// <param name="id">Id of a Card</param>
    /// <returns>CardSO</returns>
    public CardSO GetCardById(int id)
    {
        CardSO card = cardsDB.allCards.Find(x => x.id == id);
        return card;
    }

    /// <summary>
    ///  Returns a EnemySO object from the database filtering by ID
    /// </summary>
    /// <param name="id">Id of a Card</param>
    /// <returns>EnemySO</returns>
    public EnemySO GetEnemyById(int id)
    {
        EnemySO enemy = enemiesDB.allEnemies.Find(x => x.id == id);
        return enemy;
    }
    /// <summary>
    /// Returns a List of EnemySO from the Enemy database
    /// </summary>
    /// <returns>List<EnemySO></returns>
    public List<EnemySO> GetAllEnemiesCards()
    {
        foreach (EnemySO cardSO in enemiesDB.allEnemies)
        {
            enemiesCards.Add(cardSO);
        }

        return enemiesCards;
    }

    /// <summary>
    /// Returns a list of all the CardSO from the Database
    /// </summary>
    /// <returns>List<CardSO></returns>
    public List<CardSO> GetAllPlayerCards()
    {
        
        //foreach (CardSO cardSO in cardsDB.allCards)
        //{
        //    playerCards.Add(cardSO);
        //}

        return cardsDB.allCards;
    }

    /// <summary>
    /// Returns a list of all the Cards from the Database
    /// </summary>
    /// <returns>List<Card></returns>
    public List<Card> GetAllCards()
    {
        foreach (CardSO card in cardsDB.allCards)
        {
            allCards.Add(new Card(card));
        }
        foreach (EnemySO card in enemiesDB.allEnemies)
        {
            allCards.Add(new Card(card));
        }
        return allCards;
    }

    /// <summary>
    /// Convert an SO to a Card and returns it
    /// </summary>
    /// <param name="cardSO"></param>
    /// <returns>Card</returns>
    public Card ConvertSOToCard(CardSO cardSO)
    {
        return new Card(cardSO);
    }
    /// <summary>
    /// Convert an SO to a Card and returns it
    /// </summary>
    /// <param name="enemySO"></param>
    /// <returns>Card</returns>
    public Card ConvertSOToCard(EnemySO enemySO)
    {
        return new Card(enemySO);
    }
    /// <summary>
    /// Convert a List of SO's to a List of Card
    /// </summary>
    /// <param name="cardSOs"></param>
    /// <returns>List<Card></returns>
    public List<Card> ConvertSOToCards(List<CardSO> cardSOs)
    {
        List<Card> cards = new List<Card>();
        foreach (CardSO cardSO in cardSOs)
        {
            cards.Add(new Card(cardSO));
        }
        return cards;
    }
    /// <summary>
    /// Convert a List of SO's to a List of Card
    /// </summary>
    /// <param name="cardSOs"></param>
    /// <returns>List<Card></returns>
    public List<Card> ConvertSOToCards(List<EnemySO> enemySOs)
    {
        List<Card> cards = new List<Card>();
        foreach(EnemySO enemySO in enemySOs)
        {
            cards.Add(new Card(enemySO));
        }
        return cards;
    }
    /// <summary>
    /// Takes a list of Cards and return a random one from the list
    /// </summary>
    /// <param name="cards">A List of So's from wich we will pick</param>
    /// <returns>CardSO</returns>
    public CardSO GetRandomCard(List<CardSO> cards)
    {
        CardSO card = cards[Random.Range(0, cards.Count)];
        return card;
    }

    /// <summary>
    /// Takes a list of Cards and return a random one from the list
    /// </summary>
    /// <param name="cards">A List of SO's from wich we will pick</param>
    /// <returns>CardSO</returns>
    public EnemySO GetRandomCard(List<EnemySO> cards)
    {
        EnemySO card = cards[Random.Range(0, cards.Count)];
        return card;
    }

    /// <summary>
    /// Takes a list of Id's and add their power then returns it
    /// </summary>
    /// <param name="cardIdList">A list of card Id's</param>
    /// <returns></returns>
    public int GetCardsPower(List<int> cardIdList)
    {
        int cardsPower = 0;
        foreach (int cardId in cardIdList)
        {
            cardsPower += GetEnemyById(cardId).power;
        }
        return cardsPower;
    }
}
