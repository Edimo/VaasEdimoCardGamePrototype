using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyCardPrefab;
    public GameObject alliedCardPrefab;
    public CardDataBaseSO cardsDB;
    public EnemyDataBase enemiesDB;
    public CardManager cardManager;
    private boardManager boardManager;
    private PlayerManager playerManager;
    private Portal portal;


    public void Start()
    {
        //boardManager = new boardManager();
        //cardManager = new CardManager(cardsDB, enemiesDB);
        Debug.Log("Start du Spawn Manager");
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        boardManager = GameObject.Find("BoardManager").GetComponent<boardManager>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        portal = GameObject.Find("Portal").GetComponent<Portal>();
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

    public void SpawnEnemies()
    {
        List<int> enemiesId = BuildEnemiesList(portal.intensity);

        foreach (int enemySelected in enemiesId)
        {
            GameObject enn = Instantiate(enemyCardPrefab, new Vector2(0, 0), Quaternion.identity);
            enn.transform.SetParent(boardManager.enemyZone.transform, false);
            enn.GetComponent<Card>().SetCard(cardManager.GetEnemyById(enemySelected));
            portal.SpawnMonsterCost(enn.GetComponent<Card>().power);
            boardManager.enemiesOnBoard.Add(enn);
        }
    }

    public void OnDrawCardButton()
    {
        GameObject cardInHand = Instantiate(alliedCardPrefab, new Vector2(0, 0), Quaternion.identity);
        //playerHand.Add(cardInHand);
        cardInHand.transform.SetParent(boardManager.playerZone.transform, false);

        cardInHand.GetComponent<Card>().SetUI(cardManager.GetCardById(cardManager.GetRandomCard(cardManager.playerCards).id));
    }

    public IEnumerator DrawNewHand()
    {
        for (int i = 0; i < playerManager.nbrCardToDraw; i++)
        {
            GameObject cardInHand = Instantiate(alliedCardPrefab, new Vector2(0, 0), Quaternion.identity);
            playerManager.cardsInHand.Add(cardInHand);
            cardInHand.GetComponent<Card>().SetCard(cardManager.GetCardById(cardManager.GetRandomCard(cardManager.playerCards).id));
            cardInHand.transform.SetParent(boardManager.playerZone.transform, false);
           
            yield return new WaitForSeconds(0.5f);
        }

    }
}
