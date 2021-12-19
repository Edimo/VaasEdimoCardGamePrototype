using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    private TurnManager turnManager;
    private boardManager boardManager;
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        boardManager = GameObject.Find("BoardManager").GetComponent<boardManager>();
    }

    public void ResolveInvocsAttackTurn()
    {
        foreach(GameObject card in boardManager.cardsOnBoard)
        {
            GameObject target = SelectTarget(card, boardManager.enemiesOnBoard);
            card.GetComponent<Card>().Attack(target);
        }
        //boardManager.ResolveInvocsAttacks();
    }

    private GameObject SelectTarget(GameObject card, List<GameObject> enemiesList)
    {
        int targetIndex = SearchTargetByType(card.GetComponent<Card>().type, enemiesList);
        if(targetIndex == -1)
        {
            return enemiesList[0];
        }
        return enemiesList[targetIndex];
    }

    private int SearchTargetByType(Card.cardtype cardtype, List<GameObject> enemiesList)
    {
        int targetIndex = -1;
        if(cardtype == Card.cardtype.ASSASSIN)
        {
            targetIndex = GetAssassinTarget(enemiesList);
        }
        else if (cardtype == Card.cardtype.CASTER)
        {
            targetIndex = GetCasterTarget(enemiesList);
        }
        else if (cardtype == Card.cardtype.ELDRICH)
        {
            targetIndex = GetEldrichTarget(enemiesList);
        }
        else if (cardtype == Card.cardtype.GUNSLINGER)
        {
            targetIndex = GetGunslingerTarget(enemiesList);
        }
        else if (cardtype == Card.cardtype.RIDER)
        {
            targetIndex = GetRiderTarget(enemiesList);
        }
        return targetIndex;
    }

    private int GetRiderTarget(List<GameObject> enemiesList)
    {
        for (int i = 0; i <= enemiesList.Count; i++)
        {
            if(enemiesList[i].GetComponent<Card>().type == Card.cardtype.GUNSLINGER)
            {
                return (i);
            }
        }
        return -1;
    }

    private int GetGunslingerTarget(List<GameObject> enemiesList)
    {
        for (int i = 0; i <= enemiesList.Count; i++)
        {
            if (enemiesList[i].GetComponent<Card>().type == Card.cardtype.SUPPORT)
            {
                return (i);
            }
        }
        return -1;
    }

    private int GetEldrichTarget(List<GameObject> enemiesList)
    {
        for (int i = 0; i <= enemiesList.Count; i++)
        {
            if (enemiesList[i].GetComponent<Card>().type == Card.cardtype.ELDRICH)
            {
                return (i);
            }
        }
        return -1;
    }

    private int GetCasterTarget(List<GameObject> enemiesList)
    {
        for (int i = 0; i <= enemiesList.Count; i++)
        {
            if (enemiesList[i].GetComponent<Card>().type == Card.cardtype.ELDRICH)
            {
                return (i);
            }
        }
        return -1;
    }

    private int GetAssassinTarget(List<GameObject> enemiesList)
    {
        for (int i = 0; i <= enemiesList.Count; i++)
        {
            if (enemiesList[i].GetComponent<Card>().type == Card.cardtype.CASTER)
            {
                return (i);
            }
        }
        return -1;
    }

    public void ResolveEnemiesAttacksTurn()
    {

    }
}
