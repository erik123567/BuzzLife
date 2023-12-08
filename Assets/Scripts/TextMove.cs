using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextMove : MonoBehaviour
{
    public TextMeshProUGUI doText, drinkText, devilText, nextText;
    public IEnumerator StartAnimations()
    {
        //transform.LeanMoveLocal(new Vector2(500, -250), 1);
        doText.transform.LeanMoveLocalX(100, 1);
        // wait 1 second
        yield return new WaitForSeconds(1);
        drinkText.transform.LeanMoveLocalX(0, 1);
        yield return new WaitForSeconds(1);
        devilText.transform.LeanMoveLocalX(0, 1);
        yield return new WaitForSeconds(.5f);
        nextText.transform.LeanMoveLocalY(-375, 1);
        yield return null;
    }

    public void StartDoMove()
    {
        StartCoroutine(StartAnimations());
    }



}
