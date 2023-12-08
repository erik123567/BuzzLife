using System.Collections;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public GameObject frontImage; // Assign the GameObject with the front image
    public GameObject backImage; // Assign the GameObject with the back image
    public GameObject mainCanvas;
    public CardGame cardGame;


    private bool coroutineAllowed, facedUp;

    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
        facedUp = true;
        backImage.SetActive(false);
        frontImage.SetActive(true);
        cardGame = mainCanvas.GetComponent<CardGame>();
    }

    public void SwipeBack()
    {
        Debug.Log("swiped Back");

        OnStartFlip();
    }

    public void SwipeNext()
    {
        Debug.Log("swiped next");
        OnStartFlip();
        //Set next card
        cardGame.SetNextCard();

    }

    public void OnStartFlip()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        if (!facedUp)
        {
            // Flipping from back to front
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.localEulerAngles = new Vector3(0f, i, 0f);
                if (i >= 90f)
                {
                    backImage.SetActive(false);
                    frontImage.SetActive(true);
                    // Adjust the rotation of the front image to correct the orientation
                    frontImage.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                }
                yield return new WaitForSeconds(0.0075f);
            }
        }
        else
        {
            // Flipping from front to back
            frontImage.transform.localEulerAngles = Vector3.zero; // Reset front image rotation
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.localEulerAngles = new Vector3(0f, i, 0f);
                if (i <= 90f)
                {
                    frontImage.SetActive(false);
                    backImage.SetActive(true);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineAllowed = true;
        facedUp = !facedUp;
    }
}
