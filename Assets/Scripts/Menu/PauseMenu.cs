using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool wasInventoryOpen;
    public static bool wasQuestOpen;
    public GameObject PausePanel;
    public GameObject InventoryPanel;
    public GameObject QuestPanel;
    public GameObject HPPanel;
    public GameObject ProgressPanel;

    void Start()
    {
        PausePanel.SetActive(false);
        InventoryPanel.SetActive(false);
        QuestPanel.SetActive(false);
        HPPanel.SetActive(true);
        ProgressPanel.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            } else
            {
                wasInventoryOpen = InventoryPanel.activeSelf;
                wasQuestOpen = QuestPanel.activeSelf;
                PausePanel.SetActive(true);
                InventoryPanel.SetActive(false);
                QuestPanel.SetActive(false);
                HPPanel.SetActive(false);
                ProgressPanel.SetActive(false);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        if (wasInventoryOpen) 
        {
            InventoryPanel.SetActive(true);
        }

        if (wasQuestOpen)
        {
            QuestPanel.SetActive(true);
        }
        HPPanel.SetActive(true);
        ProgressPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
