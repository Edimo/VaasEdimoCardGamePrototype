using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    public int id;
    public string enemyName;
    public int hp;
    public int lvl;
    public int power;
    public string enemyDescription;
    public Sprite enemyImage;

    public Enemy()
    {

    }

    public Enemy(int Id, string EnemyName, int Hp, int Lvl, int Power, string EnemyDescription, Sprite EnemyImage)
    {
        this.id = Id;
        this.enemyName = EnemyName;
        this.hp = Hp;
        this.power = Power;
        this.enemyDescription = EnemyDescription;

        this.enemyImage = EnemyImage;

    }
}
