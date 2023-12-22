using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
public class ButtonSlideTransition : MonoBehaviour
{
    // Transition parameters
    public Vector2 pressedOffset = new Vector2(5f, -5f); // Move 5 units right and 5 units down
    public float transitionDuration = 0.1f;

    // Reference to the button's RectTransform
    private RectTransform buttonRectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        // Get the RectTransform component of the button
        buttonRectTransform = GetComponent<RectTransform>();
        originalPosition = buttonRectTransform.anchoredPosition;
    }

    // Call this function to slide the button
    public void SlideButton(Button button)
    {
        StartCoroutine(SlideTransition(button));
    }

    private IEnumerator SlideTransition(Button button)
    {
        // Slide to the pressed position
        buttonRectTransform.anchoredPosition = originalPosition + pressedOffset;
        yield return new WaitForSeconds(transitionDuration);

        // Slide back to the original position
        buttonRectTransform.anchoredPosition = originalPosition;
    }
}
