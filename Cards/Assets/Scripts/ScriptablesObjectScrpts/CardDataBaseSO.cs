using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card DataBase", menuName = "Assets/Databases/Card Database")]
public class CardDataBaseSO : ScriptableObject
{
    public List<CardSO> allCards;
}
