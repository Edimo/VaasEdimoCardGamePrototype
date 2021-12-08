using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card 
{
    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;
    public Image cardImage;

    public int id;
    public int onBoardId;
    public int lvl;
    public string cardName;
    public int hp;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite cardSprite;
    public GameObject cardPrefab;

    public void Start()
    {
        SetUI();
        //cardPrefab = this; autoreference ?
    }

    public void Update()
    {

    }

    public Card(int Id, string CardName, int Cost, int Power, string CardDescription, Sprite CardImage)
    {
        this.id = Id;
        this.cardName = CardName;
        this.cost = Cost;
        this.power = Power;
        this.cardDescription = CardDescription;

        cardSprite = CardImage;

    }

    public Card(CardSO cardSO)
    {
        this.id = cardSO.id;
        this.cardName = cardSO.cardName;
        this.cost = cardSO.cost;
        this.power = cardSO.power;
        this.cardDescription = cardSO.cardDescription;
    }

    public Card(EnemySO enemySO)
    {
        this.id = enemySO.id;
        this.lvl = enemySO.lvl;
        this.cardName = enemySO.enemyName;
        this.power = enemySO.power;
        this.cardDescription = enemySO.enemyDescription;
    }

    public void SetUI()
    {
        nameText.text = "" + this.cardName;
        costText.text = "" + this.cost;
        powerText.text = "" + this.power;
        descriptionText.text = "" + this.cardDescription;
        cardImage.sprite = this.cardSprite;
    }
}
