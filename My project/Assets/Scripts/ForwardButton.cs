using UnityEngine;

public class ForwardButton : MonoBehaviour
{
    public GameObject[] panels; // Array of panels to navigate through
    private int currentPanelIndex = 0; // Tracks the currently active panel

    public void ShowNextPanel()
    {
        if (panels.Length == 0) return; // Ensure panels are assigned

        // Deactivate the current panel
        panels[currentPanelIndex].SetActive(false);

        // Move to the next panel (loop back if at the end)
        currentPanelIndex = (currentPanelIndex + 1) % panels.Length;

        // Activate the new current panel
        panels[currentPanelIndex].SetActive(true);
    }
}
