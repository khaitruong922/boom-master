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
        isPausing = true;
        pauseLayer.SetActive(true);
        Time.timeScale = 0f;
    }
    private void Resume()
    {
        isPausing = false;
        pauseLayer.SetActive(false);
        Time.timeScale = 1f;
    }
}