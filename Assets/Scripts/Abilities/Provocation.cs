using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Provocation : Ability
{
    public int provocAmount;

    public override void Activate(GameObject truc)
    {
        Debug.Log("Provoc ? " + truc.name);
        truc.transform.GetComponent<Card>().hasProvocation = true;
        truc.transform.GetComponent<Card>().provocImage.gameObject.SetActive(true);
    }

}
