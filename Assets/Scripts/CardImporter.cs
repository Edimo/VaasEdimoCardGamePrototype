using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardImporter : MonoBehaviour
{
    public int importId;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    public Image cardImage;

    private CardManager cardManager;
    

    void Start()
    {
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        SetCardUI(cardManager.GetCardById(importId));
    }

    public void SetCardUI(CardSO card)
    {
        nameText.text = "" + card.cardName;
        costText.text = "" + card.cost;
        powerText.text = "" + card.power;
        descriptionText.text = "" + card.cardDescription;
        cardImage.sprite = card.cardImage;

    }

}
