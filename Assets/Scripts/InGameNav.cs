using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameNav : MonoBehaviour
{
    public GameObject timer;
    public GameObject overLayScreen, startingScreen, endOfTurnScreen, endOfGameScreen;
    public Text startingScreenPlayerText, scoreThisTurn, winningTeamText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.currentRound == 1)
        {
            overLayScreen.SetActive(true);
        }

        startingScreen.SetActive(true);
        endOfTurnScreen.SetActive(false);
        //Debug.Log(GameManager.instance.activeTeam.ToString() + "IngameNAv");
        startingScreenPlayerText.text = GameManager.instance.activeTeam.ToString();
    }
    public void RemoveOverLay()
    {
        overLayScreen.SetActive(false);
        startingScreen.SetActive(true);
        startingScreenPlayerText.text = GameManager.instance.activeTeam.ToString();
    }

    public void StartGamePlay()
    {
        startingScreen.SetActive(false);
        timer.GetComponent<CountdownTimer>().RestartTimer();
        timer.GetComponent<CountdownTimer>().canRun = true;
        GameManager.instance.scoreThisTurn = 0;
    }

    public void ResetButton()
    {
        GameManager.instance.currentRound = 0;
        GameManager.instance.redTeamScore = 0;
        GameManager.instance.blueTeamScore = 0;
    }

}
