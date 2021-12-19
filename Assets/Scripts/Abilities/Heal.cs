using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Heal : Ability
{
    public int healAmount;

    public override void Activate()
    {
        GameObject.Find("PlayerManager").GetComponent<PlayerManager>().currentHP += healAmount;
    }
}
