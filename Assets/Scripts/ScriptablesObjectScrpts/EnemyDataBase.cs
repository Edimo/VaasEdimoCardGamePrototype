using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy DataBase", menuName = "Assets/Databases/Enemy Database")]
public class EnemyDataBase : ScriptableObject
{
    public List<EnemySO> allEnemies;
}
