using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WordDisplay : MonoBehaviour
{
    public Text wordText;
    public Text redTeamScoreText;
    public Text blueTeamScoreText;
    public Text wordsLeftText;
    public List<string> wordList = new List<string>();

    private void Start()
    {
        GameManager.instance.SetCardsReferences();
        InitializeWordList();
        Shuffle(wordList);
        UpdateScores();
        DisplayRandomWord();
    }

    private void InitializeWordList()
    {
        wordList = new List<string>
        {
            "Apple",
            "Banana",
            "Car",
            "Dog",
            "Elephant",
            "Fish",
            "Giraffe",
            "Hat",
            "Ice Cream",
            "Jacket"
        };

        wordsLeftText.text = "Cards Left: " + wordList.Count.ToString();
    }

    private void UpdateScores()
    {
        redTeamScoreText.text = GameManager.instance.redTeamScore.ToString();
        blueTeamScoreText.text = GameManager.instance.blueTeamScore.ToString();
    }

    private void DisplayRandomWord()
    {
        if (wordList.Count > 0)
        {
            wordText.text = wordList[0]; // Always take the first word from the shuffled list
        }
        else
        {

            GameManager.instance.EndRound();
            wordText.text = "No more words left.";
            // GameManager.instance.EndRound(); // Call this if you have a method to end the round.
        }
    }

    public void SwipeRight()
    {
        if (wordList.Count > 0)
        {
            GameManager.instance.audioScript.playSfx1();
            // Update the score based on the active team
            UpdateScore(GameManager.instance.activeTeam);


            // Remove the correctly guessed word from the list
            wordList.RemoveAt(0);

            // Update remaining words count
            wordsLeftText.text = "Cards Left: " + wordList.Count.ToString();

            // Display the next word
            DisplayRandomWord();
        }
    }

    public void SwipeLeft()
    {
        if (wordList.Count > 0)
        {
            // Move the current word to the end of the list for recycling
            string currentWord = wordList[0];
            wordList.RemoveAt(0);
            wordList.Add(currentWord);

            // Display the next word
            DisplayRandomWord();
        }
    }

    private void UpdateScore(GameManager.Team team)
    {

        GameManager.instance.scoreThisTurn++;

        if (team == GameManager.Team.Red)
        {
            GameManager.instance.IncrementRedTeamScore();
            redTeamScoreText.text = GameManager.instance.redTeamScore.ToString();
        }
        else if (team == GameManager.Team.Blue)
        {
            GameManager.instance.IncrementBlueTeamScore();
            blueTeamScoreText.text = GameManager.instance.blueTeamScore.ToString();
        }
    }

    // Utility method to shuffle a list
    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            string temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }
}
