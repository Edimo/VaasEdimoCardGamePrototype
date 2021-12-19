using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public int BasePortalHP = 100;
    public int currentPortalHP;
    public Text hpText;
    private TurnManager turnManager;
    private boardManager boardManager;
    public int intensity = 1;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        boardManager = GameObject.Find("BoardManager").GetComponent<boardManager>();
        currentPortalHP = BasePortalHP;
        UpdateUI();
    }

    public void SpawnMonsterCost(int cost)
    {
        currentPortalHP -= cost;
        UpdateUI();
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if(currentPortalHP <= 0 && boardManager.enemiesOnBoard.Count == 0)
        {
            currentPortalHP = 0;
            turnManager.turnState = TurnManager.TurnState.WON;
        }
    }

    private void UpdateUI()
    {
        hpText.text = "Portal HP : " + currentPortalHP + "/" + BasePortalHP;
    }
}
