using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;




    public GameObject mainScreen, gameScreen, doDrinkDevilScreen;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMainScreen()
    {
        mainScreen.SetActive(true);

        gameScreen.SetActive(false);
        doDrinkDevilScreen.SetActive(false);
    }
    public void SetGameScreen()
    {
        TriggerPressAnimation();
        mainScreen.SetActive(false);

        gameScreen.SetActive(true);
        doDrinkDevilScreen.SetActive(false);
    }
    public void SetDoDrinkOrDevilScreen()
    {
        TriggerPressAnimation();
        mainScreen.SetActive(false);

        gameScreen.SetActive(false);
        doDrinkDevilScreen.SetActive(true);
    }
    public Vector3 pressedOffset = new Vector3(0, -5f, 0); // Offset to apply when button is pressed
    public float animationDuration = 0.1f; // Duration of the press animation

    // Call this method to trigger the press animation
    public void TriggerPressAnimation()
    {
        StartCoroutine(PressAnimation());
    }

    private IEnumerator PressAnimation()
    {
        Vector3 originalPosition = transform.localPosition;
        Vector3 pressedPosition = originalPosition + pressedOffset;

        // Move to pressed position
        transform.localPosition = pressedPosition;

        // Wait for the duration of the animation
        yield return new WaitForSeconds(animationDuration);

        // Move back to original position
        transform.localPosition = originalPosition;

    }


}

