using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int BaseHP;
    public int currentHP;
    public int maxEnergy;
    public int currentEnergy;
    public int nbrCardToDraw = 7;

    public Text hpText;
    public Text energyText;

    public List<GameObject> cardsInHand = new List<GameObject>();

    public boardManager boardManager;

    void Start()
    {
        Debug.Log("Start of Player Manager");
        boardManager = GameObject.Find("BoardManager").GetComponent<boardManager>();
        BaseHP = 100;
        maxEnergy = 4;
        currentEnergy = maxEnergy;
        currentHP = BaseHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CardPlayableVerif(int cost)
    {
        if(boardManager.cardsOnBoard.Count >= boardManager.maxPlayerBoardSize)
        {
            Debug.Log("Board Is Full");
            return false;
        }
        if(cost > currentEnergy)
        {
            Debug.Log("Not Enough Energy");
            return false;
        }
        return true;
    }

    public void PlayCard(GameObject card)
    {
        card.transform.SetParent(GameObject.Find("DropZone").transform, false);
        boardManager.cardsOnBoard.Add(card);
        currentEnergy -= card.GetComponent<Card>().cost;
        UpdatePlayerUI();
        cardsInHand.Remove(card);
    }

    public IEnumerator DiscardHand()
    {
        foreach(GameObject cardInhand in cardsInHand)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(cardInhand);
        }
        cardsInHand.Clear();
    }

    private void UpdatePlayerUI()
    {
        hpText.text = "Hp : " + currentHP + " / " + BaseHP;
        energyText.text = "Energy : " + currentEnergy + " / " + maxEnergy;
    }
}
