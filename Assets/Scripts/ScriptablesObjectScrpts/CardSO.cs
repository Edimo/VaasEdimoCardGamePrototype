using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Assets/Card")]
public class CardSO : ScriptableObject
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    [TextArea]
    public string cardDescription;
    public Sprite cardImage;
}
