using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int redTeamScore = 0;
    public int blueTeamScore = 0;
    public int currentRound = 0;
    public GameObject endOfTurnScreen;
    public InGameNav canvasNav;
    public int scoreThisTurn;
    public Audio audioScript;


    public GameObject cardsScreen;

    public enum Team { Red, Blue }
    public Team activeTeam = Team.Red; // Initialize with Red Team as the starting active team

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

    public void SwitchActiveTeam()
    {
        Debug.Log("WAS" + activeTeam);
        activeTeam = (activeTeam == Team.Red) ? Team.Blue : Team.Red;
        Debug.Log("Now" + activeTeam);
    }

    public void IncrementRedTeamScore()
    {
        if (activeTeam == Team.Red)
        {
            redTeamScore++;
        }
    }

    public void IncrementBlueTeamScore()
    {
        if (activeTeam == Team.Blue)
        {
            blueTeamScore++;
        }
    }

    public void EndRound()
    {
        Debug.Log("END OF ROUND");
        currentRound++;
        if (currentRound > 3)
        {
            Debug.Log("In here ned 2 do");
            // show other scene in nav and DONT switch scenes
            canvasNav.endOfGameScreen.SetActive(true);
        }
        else
        {
            SetBetweenScene();
        }

    }
    public void EndTurn()
    {
        Debug.Log("END OF Turn");
        // RESET TIMER

        //Change card
        //Hide reg card and unhide other card
        endOfTurnScreen.SetActive(true);
        SwitchActiveTeam();
        canvasNav.startingScreenPlayerText.text = activeTeam.ToString();
        if (scoreThisTurn == 0)
        {
            canvasNav.scoreThisTurn.text = "";
        }
        else
        {
            canvasNav.scoreThisTurn.text = "Pass out " + scoreThisTurn + " sips!";
        }

        //update front

    }

    public void ResetEverything()
    {
        //Points
        // Rounds
        //Cards?
        GameManager.instance.currentRound = 0;
        GameManager.instance.redTeamScore = 0;
        GameManager.instance.blueTeamScore = 0;

    }

    public void HomeButtonClick()
    {

        // RESET Everything
        ResetEverything();
        SceneManager.LoadScene(0);
        // Go back to home scene
    }
    public void PlayAgainButton()
    {
        ResetEverything();
        SceneManager.LoadScene(2);
        //RESET everything
        // Go back to scene1?
    }

    public void LoadDoDrinkDraw()
    {
        SceneManager.LoadScene(4);
    }


    public void SetGameScreen()
    {
        SceneManager.LoadScene(3);
    }
    public void SetCardsReferences()
    {
        cardsScreen = GameObject.FindGameObjectWithTag("Card");
        endOfTurnScreen = GameObject.FindGameObjectWithTag("SecondCard");
        canvasNav = GameObject.FindAnyObjectByType<InGameNav>();
        Debug.Log(cardsScreen);
        endOfTurnScreen.SetActive(false);
    }



    public void SetChooseGameScreen()
    {
        SceneManager.LoadSceneAsync("1SelectGame");
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }
    public void SetMainScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        Scene scene = SceneManager.GetActiveScene();

    }

    public void SetBetweenScene()
    {
        SceneManager.LoadSceneAsync("2InBetweenRules");
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }
}

