using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSlotMachine : MonoBehaviour
{
    public RectTransform circleIndicator; // The circle overlay that will move to the option
    public RectTransform[] optionTransforms; // The RectTransforms for each text option
    public float spinTime = 2.0f; // Total time of the spin
    public Image circleIndicatorImage; // The Image component of the circle 
    public Image i1, i2, i3;
    public Image selectedImage;
    public Button drawButton;

    private void Awake()
    {
        // Get the Image component from the circle indicator
        circleIndicatorImage = circleIndicator.GetComponent<Image>();
    }

    public void StartSlotMachineEffect()
    {
        circleIndicatorImage.enabled = true;
        StartCoroutine(SlotMachineEffect());
        drawButton.gameObject.SetActive(false);

    }

    private IEnumerator SlotMachineEffect()
    {
        float timer = 0.0f;
        int optionIndex = 0;
        float delay = 0.05f;
        float maxDelay = 0.1f; // Starting max delay for variability
        float delayIncrease = 0.0f;


        while (timer < spinTime)
        {
            // Randomly adjust the delay increase factor to create variation in slowing down
            delayIncrease = Random.Range(0.001f, 0.005f);

            // Ensure the delay only increases, never decreases
            delay = Mathf.Min(maxDelay, delay + delayIncrease);

            // Move the circle indicator to the current option's RectTransform position
            circleIndicator.position = optionTransforms[optionIndex].position;

            // Increment the option index and loop back to the start if necessary
            optionIndex = (optionIndex + 1) % optionTransforms.Length;

            // Wait for a bit before the next update
            yield return new WaitForSeconds(delay);

            // Update the timer
            timer += delay;
        }

        // Finish with a final slow down sequence to stop at an option
        while (delay < 0.5f) // Final delay to end the cycle
        {
            delay *= 1.1f; // Apply a slowing down factor
            circleIndicator.position = optionTransforms[optionIndex].position;
            optionIndex = (optionIndex + 1) % optionTransforms.Length;
            yield return new WaitForSeconds(delay);
        }

        // Snap the circle indicator to the final option's RectTransform position
        circleIndicator.position = optionTransforms[optionIndex].position;

        // Start blinking the indicator
        Debug.Log(optionIndex);
        // You can now handle the selected option

        if (optionIndex == 0)
        {
            selectedImage = i1;

        }
        if (optionIndex == 1)
        {
            selectedImage = i2;

        }
        if (optionIndex == 2)
        {
            selectedImage = i3;
        }
        yield return StartCoroutine(BlinkIndicator(3, 0.5f));

    }

    private IEnumerator BlinkIndicator(int blinks, float interval)
    {
        for (int i = 0; i < blinks * 2; i++) // Multiply by 2 for on and off states
        {
            // Toggle the visibility
            selectedImage.enabled = !selectedImage.enabled;

            // Wait for half the interval
            yield return new WaitForSeconds(interval / 2);
        }

        // Make sure the indicator is visible after the last blink
        selectedImage.enabled = true;

        // You can now handle the end of the effect
        OnEffectEnd();
    }

    private IEnumerator HandleSelectedOption(int selectedOptionIndex)
    {

        // Handle the selected option here
        Debug.Log("Selected Option Index: " + selectedOptionIndex);
        if (selectedOptionIndex == 1)
        {
            selectedImage = i1;

        }
        if (selectedOptionIndex == 2)
        {
            selectedImage = i2;

        }


        yield return StartCoroutine(BlinkIndicator(3, 0.5f));


    }

    private void OnEffectEnd()
    {
        circleIndicatorImage.enabled = false;
        // Handle the end of the slot machine effect here
        Debug.Log("Slot Machine effect has ended.");
    }
}
