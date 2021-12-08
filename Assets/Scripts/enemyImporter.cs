using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyImporter : MonoBehaviour
{
    public int importId;

    public Text nameText;
    public Text hpText;
    public Text powerText;
    public Text descriptionText;

    public Image cardImage;

    public int currentHp;
    private CardManager cardManager;

    void Start()
    {
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        SetEnemyUI(cardManager.GetEnemyById(importId));
    }

    public void SetEnemyUI(EnemySO enemy)
    {
        nameText.text = "" + enemy.enemyName;
        hpText.text = "" + enemy.hp;
        powerText.text = "" + enemy.power;
        descriptionText.text = "" + enemy.enemyDescription;
        cardImage.sprite = enemy.enemyImage;

        currentHp = enemy.hp;
    }


    public void TakeDamage(int damage)
    {
        currentHp = currentHp - damage;
        hpText.text = "" + currentHp;
    }
}
