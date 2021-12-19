using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Assets/Entities")]

public class EntitySO : ScriptableObject
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public int lvl;
    public int xp;
    public int hp;

    public List<Ability> onPlayAbilities;
    public List<Ability> onDeathAbilities;
    public List<Ability> onKillAbilities;
    public enum cardtype { ASSASSIN, CASTER, GUNSLINGER, RIDER, SUPPORT, ELDRICH, FIGHTER }

    public cardtype type;

    [TextArea]
    public string Description;
    public Sprite Image;
}
