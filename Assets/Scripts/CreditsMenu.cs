using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CreditsMenu : MonoBehaviour
{
    public float scrollSpeed = 35f; // Speed of scrolling
    public RectTransform creditsText; // Reference to the UI Text RectTransform
    public TextMeshProUGUI titleText; // Reference to the title text (TextMesh Pro)

    public float fadeDuration = 1.5f; // Duration for the fade effect
    public float startPositionY = -600; // Starting Y position for credits
    public float endPositionY; // Ending Y position for credits

    public float timeBeforeFading = 2f; // Time before the title begins to fade

    private void Start()
    {
        // Directly set the starting position to -300
        startPositionY = -600f; // Desired starting position
        endPositionY = Screen.height; // Ends above the view

        // Set the initial position to startPositionY
        creditsText.anchoredPosition = new Vector2(creditsText.anchoredPosition.x, startPositionY);

        // Start the fading process for the title text
        StartCoroutine(FadeTitle());
        // Start the scrolling process for the credits
        StartCoroutine(ScrollCredits());
    }

    private IEnumerator ScrollCredits()
    {
        // Loop until the credits text has fully scrolled up
        while (creditsText.anchoredPosition.y < endPositionY)
        {
            // Move the credits upwards
            creditsText.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Optionally, disable the game object or scene after scrolling completes
        // gameObject.SetActive(false); // Disable credits text object
        // SceneManager.LoadScene("MainMenu"); // Load main menu scene
    }

    private IEnumerator FadeTitle()
    {
        // Wait for a specified amount of time before starting to fade
        yield return new WaitForSeconds(timeBeforeFading);

        // Get the initial color of the title text
        Color titleColor = titleText.color;

        // Fade out
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            titleColor.a = alpha;

            // Assign the new color back to the title text
            titleText.color = titleColor;

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the title text is fully transparent after fading
        titleColor.a = 0f;
        titleText.color = titleColor;

        // Optionally, you can disable the title text after fading
        // titleText.gameObject.SetActive(false);
    }
}
