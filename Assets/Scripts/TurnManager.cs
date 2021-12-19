using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum TurnState { START, PLAYERTURN, WAIT, INVOCTURN, ENEMYTURN, PORTALTURN, WON, LOST}

    public TurnState turnState;

    private SpawnManager spawnManager;
    private PlayerManager playerManager;
    private AIManager aiManager;
    void Start()
    {
        Debug.Log("Start Of TurnManager");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        aiManager = GameObject.Find("AIManager").GetComponent<AIManager>();
        turnState = TurnState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        switch(turnState)
        {
            case TurnState.WON:
                
                break;
            case TurnState.LOST:
                break;
            case TurnState.PORTALTURN:
                Debug.Log("Portal turn combien ?");
                spawnManager.SpawnEnemies();
                StartCoroutine(PlayerTurn());
                turnState = TurnState.PLAYERTURN;
                break;             
        }
    }

    private IEnumerator SetupBattle()
    {
        Debug.Log("Spawning Enemy");
        yield return new WaitForSeconds(1f);
        //Set on 1 for now, but will need to access the current lvl in gameManager or SpawnManager
        spawnManager.SpawnEnemies();

        yield return new WaitForSeconds(3f);
        

        StartCoroutine(PlayerTurn());
    }

    private IEnumerator PlayerTurn()
    {   
        yield return StartCoroutine(spawnManager.DrawNewHand());
        playerManager.currentEnergy = playerManager.maxEnergy;
        turnState = TurnState.WAIT;
        Debug.Log("Your Turn To Play !");
    }

    public void OnEndTurnButton()
    {
        if (turnState != TurnState.WAIT)
            return;
        StartCoroutine(EndTurn());
    }

    public IEnumerator EndTurn()
    {
        Debug.Log("Ending turn...");
        //discard
        
        yield return StartCoroutine(playerManager.DiscardHand());
        Debug.Log("Discard Hand is done");
        turnState = TurnState.INVOCTURN;
        aiManager.ResolveInvocsAttackTurn();
    }
}
