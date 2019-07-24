using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice3 : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        if (!GameControl4.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl4.diceSideThrown = randomDiceSide + 1;

        if (whosTurn == 1)
        {
            GameControl4.MovePlayer(1);
            whosTurn = 2;
        }
        else if (whosTurn == 2)
        {
            GameControl4.MovePlayer(2);
            whosTurn = 1;
        }


        coroutineAllowed = true;
    }
}
