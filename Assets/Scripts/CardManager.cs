using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour
{

    public List<CardSO> playerCards;
    public List<EnemySO> enemiesCards;
    public List<Card> allCards;
    public CardDataBaseSO cardsDB;
    public EnemyDataBase enemiesDB;

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

    public CardSO GetCardById(int id)
    {
        CardSO card = cardsDB.allCards.Find(x => x.id == id);
        return card;
    }
    public EnemySO GetEnemyById(int id)
    {
        EnemySO enemy = enemiesDB.allEnemies.Find(x => x.id == id);
        return enemy;
    }

    public List<EnemySO> GetAllEnemiesCards()
    {
        foreach (EnemySO cardSO in enemiesDB.allEnemies)
        {
            enemiesCards.Add(cardSO);
        }

        return enemiesCards;
    }

    public List<CardSO> GetAllPlayerCards()
    {
        
        //foreach (CardSO cardSO in cardsDB.allCards)
        //{
        //    playerCards.Add(cardSO);
        //}

        return cardsDB.allCards;
    }

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

    public List<Card> GetAllCards(List<Card> playerCards, List<Card> enemiesCards)
    {
        allCards.AddRange(playerCards);
        allCards.AddRange(enemiesCards);
        return allCards;
    }

    public Card ConvertSOToCard(CardSO cardSO)
    {
        return new Card(cardSO);
    }

    public Card ConvertSOToCard(EnemySO enemySO)
    {
        return new Card(enemySO);
    }

    public List<Card> ConvertSOToCards(List<CardSO> cardSOs)
    {
        List<Card> cards = new List<Card>();
        foreach (CardSO cardSO in cardSOs)
        {
            cards.Add(new Card(cardSO));
        }
        return cards;
    }

    public List<Card> ConvertSOToCards(List<EnemySO> enemySOs)
    {
        List<Card> cards = new List<Card>();
        foreach(EnemySO enemySO in enemySOs)
        {
            cards.Add(new Card(enemySO));
        }
        return cards;
    }


    public CardSO GetRandomCard(List<CardSO> cards)
    {
        CardSO card = cards[Random.Range(0, cards.Count)];
        return card;
    }

    public EnemySO GetRandomCard(List<EnemySO> cards)
    {
        EnemySO card = cards[Random.Range(0, cards.Count)];
        return card;
    }

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
