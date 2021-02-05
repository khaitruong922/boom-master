#pragma warning disable 0649

using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    private bool isPausing = false;

    [SerializeField]
    private GameObject pauseLayer;
    private void Start()
    {
        Resume();
    }
    public void HandlePause()
    {
        if (isPausing)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    private void Pause()
    {
        if (Time.timeScale == 0) return;
        isPausing = true;
        pauseLayer.SetActive(true);
        Time.timeScale = 0;
    }
    private void Resume()
    {
        isPausing = false;
        pauseLayer.SetActive(false);
        Time.timeScale = 1;
    }
}