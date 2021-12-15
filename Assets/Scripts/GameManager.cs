using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int currentLevel;
    //public PlayerManager playerManager;

    public GameObject cardPrefab;
    public GameObject enemyPrefab;

    //private TurnState turnState;



    public CardDataBaseSO cardsDB;
    public EnemyDataBase enemiesDB;


    public GameObject dropZone;
    public GameObject monsterZone;
    public GameObject playerHandZone;

    public List<GameObject> playerHand = new List<GameObject>();


    private SpawnManager spawnManager;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        currentLevel = Random.Range(1, 10);
        Debug.Log(currentLevel);
        //turnState = TurnState.START;
        //StartCoroutine(SetupBattle());
    }

    /*public enum TurnState
    {
        START, PLAYERTURN, MONSTERTURN, INVOCTURN, MANAGINGTURN, AWAIT, GAMEOVER
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Spawning Enemy");   
        yield return new WaitForSeconds(3f);
        spawnManager.SpawnEnemies(currentLevel);

        yield return new WaitForSeconds(3f);
        turnState = TurnState.PLAYERTURN;

    }*/


    /*public void SpawnEnemies(int intensity)
    {
        List<int> enemiesId = BuildEnemiesList(intensity);
        Debug.Log(enemiesId.Count);
        foreach (int enemySelected in enemiesId)
        {
            // fonction a écrire pour trouver la bonne position pour spawn
            GameObject enn = Instantiate(enemyPrefab, GameObject.Find("DropZone").GetComponent<Transform>());
            enn.GetComponent<enemyImporter>().importId = enemySelected;
        }
    }

    public List<int> BuildEnemiesList(int intensity)
    {
        List<int> enemiesids = new List<int>();
        for (int i = 0; i < intensity; i = GetEnemiesPower(enemiesids))
        {
            int powerRequired = intensity - GetEnemiesPower(enemiesids);
            enemiesids.Add(FindSuitableEnemy(powerRequired));
        }
        return enemiesids;
    }

    public int GetEnemiesPower(List<int> enemiesidList)
    {
        int enemiesPower = 0;
        foreach (int enemy in enemiesidList)
        {
            enemiesPower += GetEnemyById(enemy).lvl;
        }
        return enemiesPower;
    }

    private object GetEnemyById(int enemy)
    {
        throw new System.NotImplementedException();
    }

    public int FindSuitableEnemy(int powerRequired)
    {

        List<int> possibleEnnemies = new List<int>();
        foreach (EnemySO e in instance.enemiesDB.allEnemies)
        {
            if (e.lvl <= powerRequired)
            {
                possibleEnnemies.Add(e.id);
            }
        }
        int enemy = possibleEnnemies[Random.Range(0, possibleEnnemies.Count)];
        return enemy;
    }*/


    /*public void OnEndTurnButton()
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
        turnState = TurnState.INVOCTURN;
        StartCoroutine(ResolveInvocsAttack());
    }

    public IEnumerator ResolveInvocsAttack()
    {

        yield break;
    }

    public void CheckIfEnemiesAlive()
    {
        //if enemies alive : call enemy turn function and set state to enemy turn
        //if no enemy remaining : call reward function and set state to managing turn

    }
    */
}
