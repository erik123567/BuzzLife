using UnityEngine;
using UnityEngine.UI;

public class ButtonVisualFeedback : MonoBehaviour
{
    public Button myButton;
    public Color pressedColor = Color.red;
    public Vector3 pressedScale = new Vector3(0.95f, 0.95f, 0.95f);

    private Color originalColor;
    private Vector3 originalScale;
    private Image buttonImage;

    void Start()
    {
        buttonImage = myButton.GetComponent<Image>();
        originalColor = buttonImage.color;
        originalScale = myButton.transform.localScale;

        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        buttonImage.color = pressedColor;
        myButton.transform.localScale = pressedScale;
        Invoke("ResetButton", 0.1f); // Reset after 0.1 seconds
    }

    void ResetButton()
    {
        buttonImage.color = originalColor;
        myButton.transform.localScale = originalScale;
    }
}
