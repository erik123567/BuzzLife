using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using TMPro;

public class CardGame : MonoBehaviour
{
    public Text doText, drinkText;
    public TextMeshProUGUI devil1Text, devil2Text, devil3Text;

    public Image dot1, dot2;
    public GameObject overlay1, overlay2, mainCanvas, overLayScreenMain;
    private SimpleSlotMachine slotMachine;
    public bool showDot1 = true;

    // Define the Card class
    [Serializable]
    public class Card
    {
        public string type;
        public int rating;
        public string action;
    }
    [Serializable]
    public class CardCollection
    {
        public Card[] doCards;
        public Card[] drinkCards;
        public Card[] devilCardsModifier1;
        public Card[] devilCardsModifier2;
        public Card[] devilCardsModifier3;
    }


    public CardCollection cardCollection;
    private System.Random random = new System.Random();
    public Card selectedDoCard;
    public Card selectedDrinkCard;
    public Card selectedDevilCardModifier1;
    public Card selectedDevilCardModifier2;
    public Card selectedDevilCardModifier3;

    private List<Card> cards;
    private List<string> wildcards;

    // Start is called before the first frame update
    void Start()
    {
        //InitializeCards();
        // InitializeWildcards();
        // SetCards();
        slotMachine = GetComponent<SimpleSlotMachine>();
        overLayScreenMain.GetComponent<TextMove>().StartDoMove();
        LoadCardData();
        SelectCardsForTurn();
        SetOverLayScreen();


    }
    public void SetNextCard()
    {
        //reset button
        Debug.Log(slotMachine.drawButton);
        slotMachine.drawButton.gameObject.SetActive(true);
        //reenable image for dot


        //reset select

        slotMachine.selectedImage.enabled = false;
        slotMachine.selectedImage = null;
        //reset border
        Debug.Log("got here");
        SelectCardsForTurn();
    }
    private void SelectCardsForTurn()
    {
        // Roll the dice for severity
        int severity = RollDice();

        // Select one card from each array based on severity
        selectedDoCard = cardCollection.doCards[severity - 1];
        selectedDrinkCard = cardCollection.drinkCards[severity - 1];
        selectedDevilCardModifier1 = cardCollection.devilCardsModifier1[severity - 1];
        selectedDevilCardModifier2 = cardCollection.devilCardsModifier2[severity - 1];
        selectedDevilCardModifier3 = cardCollection.devilCardsModifier3[severity - 1];

        // Display the selected cards on the screen
        // This is a placeholder for your UI display logic
        DisplaySelectedCards();
    }
    private void DisplaySelectedCards()
    {
        // Display the selected cards on the screen
        // Implement your UI logic here to show the cards to the player
        // Debug.Log("Do Card: " + selectedDoCard.action);
        // Debug.Log("Drink Card: " + selectedDrinkCard.action);
        // Debug.Log("Devil Card (Mod 1): " + selectedDevilCardModifier1.action);
        // Debug.Log("Devil Card (Mod 2): " + selectedDevilCardModifier2.action);
        // Debug.Log("Devil Card (Mod 3): " + selectedDevilCardModifier3.action);
        drinkText.text = selectedDrinkCard.action;
        doText.text = selectedDoCard.action;
        devil1Text.text = selectedDevilCardModifier1.action;
        devil2Text.text = selectedDevilCardModifier2.action;
        devil3Text.text = selectedDevilCardModifier3.action;

    }
    private void LoadCardData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("cards");
        cardCollection = JsonUtility.FromJson<CardCollection>(jsonFile.text);

        // Example: Print the first 'Do' card action
        Debug.Log("First 'Do' Card Action: " + cardCollection.doCards[1].action);
        Debug.Log("First 'Do' Card Action: " + cardCollection.devilCardsModifier1[1].action);
    }



    private int RollDice()
    {
        return random.Next(1, 6); // Roll a dice between 1 and 5
    }

    // public void SetCards()
    // {
    //     Card newCard = GetRandomCard();
    //     dareText.text = newCard.Dare;
    //     drinkText.text = newCard.NumberOfDrinks.ToString() + "sip /(s)";

    // }

    // Initialize the cards with sample data
    // private void InitializeCards()
    // {
    //     cards = new List<Card>
    //     {
    //         new Card("Sing a song",12),
    //         new Card("Do a dance", 1),
    //          new Card("Do a dance", 1),
    //           new Card("Do a dare3", 1),
    //            new Card("Do a dare4", 1)
    //         // ... Add other cards here
    //     };
    // }

    // Initialize the wildcards with sample data
    private void InitializeWildcards()
    {
        wildcards = new List<string>
        {
            "Drink double the amount",
            "Drink three times the amount",
            "Take one sip",
            "Skip your turn",
            "Give the number of sips to the person next to you",
            "Give the sips to the person of your choosing",
            // ... Add other wildcards here
        };
    }

    // Function to get a random card
    // public Card GetRandomCard()
    // {
    //     if (cards.Count == 0)
    //     {
    //         Debug.Log("No more cards available.");
    //         return null; // Or handle this case as needed
    //     }

    //     int randomIndex = Random.Range(0, cards.Count);
    //     Card selectedCard = cards[randomIndex];
    //     cards.RemoveAt(randomIndex); // Remove the card from the list
    //     return selectedCard;
    // }

    // Function to apply a wildcard effect
    // public string ApplyRandomWildcard()
    // {
    //     if (wildcards.Count == 0)
    //     {
    //         Debug.Log("No more wildcards available.");
    //         return null; // Or handle this case as needed
    //     }

    //     int randomIndex = Random.Range(0, wildcards.Count);
    //     string selectedWildcard = wildcards[randomIndex];
    //     wildcards.RemoveAt(randomIndex); // Remove the wildcard from the list
    //     return selectedWildcard;
    // }

    public void DealWithDevil()
    {
        //Start animation
        Debug.Log("Started animaiton");
    }

    // Function to set a new card
    // public void SetNewCard()
    // {
    //     Card randomCard = GetRandomCard();
    //     if (randomCard != null)
    //     {
    //         // Optionally apply a wildcard effect here
    //         //string wildcard = ApplyRandomWildcard();
    //         Debug.Log($"Dare: {randomCard.Dare}, Drinks: {randomCard.NumberOfDrinks}");
    //         // Update the game state/UI with the new card details
    //     }
    // }

    public void ChangeOverLayScreen()
    {
        Debug.Log("ab");
        showDot1 = !showDot1;
        SetOverLayScreen();
    }

    public void SetOverLayScreen()
    {
        Debug.Log("ra");
        mainCanvas.SetActive(false);

        if (showDot1)
        {
            //Show screen 1
            // show 1 on image for dots
            dot1.color = Color.black;
            dot2.color = Color.white;
            overlay1.SetActive(true);
            overlay2.SetActive(false);


        }
        else
        {
            //Show screen 2
            //navigation dots
            dot1.color = Color.white;
            dot2.color = Color.black;
            overlay1.SetActive(false);
            overlay2.SetActive(true);
        }
    }

    public void SetStartScreen()
    {
        Debug.Log("Game has started");
        overlay1.SetActive(false);
        overlay2.SetActive(false);
        mainCanvas.SetActive(true);
        dot1.gameObject.SetActive(false);
        dot2.gameObject.SetActive(false);
    }
}
