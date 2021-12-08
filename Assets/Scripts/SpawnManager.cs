using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyCardPrefab;
    public GameObject alliedCardPrefab;
    //public CardDataBaseSO cardsDB;
    //public EnemyDataBase enemiesDB;
    public CardManager cardManager;
    private boardManager boardManager;

    // Start is called before the first frame update
    public void Start()
    {
        //boardManager = new boardManager();
        //cardManager = new CardManager(cardsDB, enemiesDB);
        Debug.Log("Start du Spawn Manager");
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        boardManager = GameObject.Find("BoardManager").GetComponent<boardManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void spawnCard(int cardId, board spawnZone)
    {

    }

    public int FindSuitableEnemy(int powerRequired)
    {

        List<int> possibleEnnemies = new List<int>();
        foreach (EnemySO enemySO in cardManager.enemiesCards)
        {
            if (enemySO.lvl <= powerRequired)
            {
                possibleEnnemies.Add(enemySO.id);
            }
        }
        int enemy = possibleEnnemies[Random.Range(0, possibleEnnemies.Count)];
        return enemy;
    }

    public List<int> BuildEnemiesList(int intensity)
    {
        List<int> enemiesids = new List<int>();
        
        for (int i = 0; i < intensity; i = cardManager.GetCardsPower(enemiesids))
        {
            int powerRequired = intensity - cardManager.GetCardsPower(enemiesids);
            enemiesids.Add(FindSuitableEnemy(powerRequired));
        }
        return enemiesids;
    }

    public void SpawnEnemies(int intensity)
    {
        List<int> enemiesId = BuildEnemiesList(intensity);

        foreach (int enemySelected in enemiesId)
        {
            GameObject enn = Instantiate(enemyCardPrefab, new Vector2(0, 0), Quaternion.identity);
            enn.transform.SetParent(boardManager.enemyZone.transform, false);
            enn.GetComponent<Card>().id = enemySelected;
        }        
    }
}
