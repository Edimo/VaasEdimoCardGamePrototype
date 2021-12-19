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
    public List<Ability> onPlayAbilities;
    public List<Ability> onDeathAbilities;
    public List<Ability> onKillAbilities;
    public enum cardtype { ASSASSIN, CASTER, GUNSLINGER, RIDER, SUPPORT, ELDRICH, FIGHTER }

    public cardtype type;

    [TextArea]
    public string cardDescription;
    public Sprite cardImage;
}
