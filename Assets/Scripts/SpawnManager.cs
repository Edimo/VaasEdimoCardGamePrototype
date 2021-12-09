using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Prefab de la carte ennemie
    public GameObject enemyCardPrefab;
    //Prefab de la carte alliée
    public GameObject alliedCardPrefab;
    //Databases de cartes
    public CardDataBaseSO cardsDB;
    public EnemyDataBase enemiesDB;
    //Managers
    public CardManager cardManager;
    private boardManager boardManager;

    /// <summary>
    /// Lors de start:
    /// Initialisation des managers utile au fonctionnement du script SpawnManager
    /// </summary>
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

    /// <summary>
    /// Recupere un ennemie random dans la liste d'ennemie parmis ceux qui ont le power requis
    /// </summary>
    /// <param name="powerRequired">Puissance demandée pour l'ennemie (dérive de la difficultée)</param>
    /// <returns></returns>
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

    /// <summary>
    /// Retourne une liste d'ennemies qui représente une vague à la bonne difficultée
    /// </summary>
    /// <param name="intensity">Represente la difficultée</param>
    /// <returns></returns>
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

    /// <summary>
    /// Fait apparaitre une liste d'ennemies sur le board ennemie
    /// </summary>
    /// <param name="intensity">Represente la diffcultée</param>
    public void SpawnEnemies(int intensity)
    {
        List<int> enemiesId = BuildEnemiesList(intensity);

        foreach (int enemySelected in enemiesId)
        {
            GameObject enn = Instantiate(enemyCardPrefab, new Vector2(0, 0), Quaternion.identity);
            enn.transform.SetParent(boardManager.enemyZone.transform, false);
            enn.GetComponent<Card>().SetUI(cardManager.GetEnemyById(enemySelected));
        }        
    }

    /// <summary>
    /// Permet de faire apparaitre une carte alliée aléatoire dans la main du joueur
    /// </summary>
    public void OnDrawCardButton()
    {
        GameObject cardInHand = Instantiate(alliedCardPrefab, new Vector2(0, 0), Quaternion.identity);
        //playerHand.Add(cardInHand);
        cardInHand.transform.SetParent(boardManager.playerZone.transform, false);

        cardInHand.GetComponent<Card>().SetUI(cardManager.GetCardById(cardManager.GetRandomCard(cardManager.playerCards).id));
    }
}
