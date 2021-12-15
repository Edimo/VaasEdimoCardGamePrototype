using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;

    private TurnManager turnManager;

    private GameObject DropZone;
    private Vector2 originalPos;

    private Card thisCard;
    private PlayerManager playerManager;

    void Start()
    {
        thisCard = GetComponent<Card>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        DropZone = GameObject.Find("DropZone");
        originalPos = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        Debug.Log("Coliding");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        Debug.Log("Not Coliding");
    }

    public void StartDrag()
    {
        if (turnManager.turnState == TurnManager.TurnState.PLAYERTURN)
        {
            originalPos = transform.position;
            isDragging = true;
        }
    }

    public void EndDrag()
    {
        if (turnManager.turnState == TurnManager.TurnState.PLAYERTURN)
        {
            if (isOverDropZone && playerManager.CardPlayableVerif(thisCard.cost))
            {
                GetComponent<BoxCollider2D>().enabled = false; 
                playerManager.PlayCard(this.gameObject);
                GetComponent<DragDrop>().enabled = false;
            }
            else
            {
                transform.position = originalPos;
            }
            isDragging = false;
        }
    }

    //Ne sera probablement pas ici : assigne la carte à la dropzone et joue ses effets. BoardManager ? CardManager ?
    //private void PlayCard()
    //{
    //    GetComponent<BoxCollider2D>().enabled = false;
    //    gameObject.transform.SetParent(DropZone.transform, false);
    //    GetComponent<DragDrop>().enabled = false;
    //}
}
