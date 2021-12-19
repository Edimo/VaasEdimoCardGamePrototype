using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;

    public virtual void Activate()
    {
        
    }
    public virtual void Activate(GameObject gameObject)
    {

    }
}
