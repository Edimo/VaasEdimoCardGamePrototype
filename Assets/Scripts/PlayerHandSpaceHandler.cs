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
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gLG = GetComponent<GridLayoutGroup>();
        spacer = 0;
        changeChecker = gm.playerHand.Count;
        increm = 4f;
    }

    private void Update()
    {
        spacer = increm * gm.playerHand.Count;
        if (changeChecker != gm.playerHand.Count)
        {
            gLG.spacing = new Vector2(gLG.spacing.x - spacer, gLG.spacing.y);
            changeChecker = gm.playerHand.Count;
            increm -= 0.25f;
        }

    }

}
