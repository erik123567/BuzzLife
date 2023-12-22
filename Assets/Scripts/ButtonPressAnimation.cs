using UnityEngine;
using System.Collections;

public class ButtonPressAnimation : MonoBehaviour
{
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
