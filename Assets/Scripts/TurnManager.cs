using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum TurnState { START, PLAYERTURN, INVOCTURN, ENEMYTURN, WON, LOST}

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
        
    }

    private IEnumerator SetupBattle()
    {
        Debug.Log("Spawning Enemy");
        yield return new WaitForSeconds(1f);
        //Set on 1 for now, but will need to access the current lvl in gameManager or SpawnManager
        spawnManager.SpawnEnemies(1);

        yield return new WaitForSeconds(3f);
        
        turnState = TurnState.PLAYERTURN;
        PlayerTurn();
    }

    private void PlayerTurn()
    {   
        StartCoroutine(spawnManager.DrawNewHand());
        playerManager.currentEnergy = playerManager.maxEnergy;       
        Debug.Log("Your Turn To Play !");
    }

    public void OnEndTurnButton()
    {
        if (turnState != TurnState.PLAYERTURN)
            return;
        StartCoroutine(EndTurn());
    }

    public IEnumerator EndTurn()
    {
        Debug.Log("Ending turn...");
        //discard
        
        yield return new WaitForSeconds(1f);
        StartCoroutine(playerManager.DiscardHand());
        turnState = TurnState.INVOCTURN;
        aiManager.ResolveInvocsAttack();
    }
}
