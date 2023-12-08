using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject setupScreen, round1Screen, round2Screen, round3Screen;
    void Start()
    {
        setupScreen.SetActive(true);
        round1Screen.SetActive(false);
        round2Screen.SetActive(false);
        round3Screen.SetActive(false);
        Debug.Log(GameManager.instance.currentRound);
        if (GameManager.instance.currentRound == 0)
        {
            setupScreen.SetActive(true);
        }
        if (GameManager.instance.currentRound == 1)
        {
            setupScreen.SetActive(false);
            round1Screen.SetActive(true);
        }
        if (GameManager.instance.currentRound == 2)
        {
            setupScreen.SetActive(false);
            round1Screen.SetActive(false);
            round2Screen.SetActive(true);
        }
        if (GameManager.instance.currentRound == 3)
        {
            setupScreen.SetActive(false);
            round2Screen.SetActive(false);
            round3Screen.SetActive(true);
        }
    }
    public void getFirstScreen()
    {
        GameManager.instance.currentRound++;
        setupScreen.SetActive(false);
        round1Screen.SetActive(true);
    }




}