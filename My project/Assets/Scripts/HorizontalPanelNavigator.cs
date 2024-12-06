using UnityEngine;
using UnityEngine.UI;

public class HorizontalPanelNavigator : MonoBehaviour
{
    public RectTransform panelContainer; // The container holding all panels
    public Button forwardButton; // The button to move forward
    public float transitionDuration = 0.5f; // Time for smooth transition (seconds)

    private int currentIndex = 0;
    private int panelCount;
    private float panelWidth;

    private void Start()
    {
        if (panelContainer == null)
        {
            Debug.LogError("PanelContainer is not assigned.");
            return;
        }

        // Calculate panel width and count
        panelWidth = panelContainer.rect.width / panelContainer.childCount;
        panelCount = panelContainer.childCount;

        // Add listener to the button
        if (forwardButton != null)
        {
            forwardButton.onClick.AddListener(MoveToNextPanel);
        }
    }

    private void MoveToNextPanel()
    {
        if (currentIndex < panelCount - 1)
        {
            currentIndex++;
            StartCoroutine(SmoothTransition(-currentIndex * panelWidth));
        }
    }

    private System.Collections.IEnumerator SmoothTransition(float targetX)
    {
        Vector2 startPosition = panelContainer.anchoredPosition;
        Vector2 targetPosition = new Vector2(targetX, startPosition.y);
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            panelContainer.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / transitionDuration);
            yield return null;
        }

        panelContainer.anchoredPosition = targetPosition;
    }
}
