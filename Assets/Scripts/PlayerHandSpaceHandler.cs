using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandSpaceHandler : MonoBehaviour
{
    public float spacer;
    public float increm;
    private int changeChecker;

    private GridLayoutGroup gLG;
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        gLG = GetComponent<GridLayoutGroup>();
        spacer = 0;
        changeChecker = playerManager.cardsInHand.Count;
        increm = 4f;
    }

    private void Update()
    {
        spacer = increm * playerManager.cardsInHand.Count;
        if (changeChecker != playerManager.cardsInHand.Count)
        {
            gLG.spacing = new Vector2(gLG.spacing.x - spacer, gLG.spacing.y);
            changeChecker = playerManager.cardsInHand.Count;
            increm -= 0.25f;
        }

    }

}
