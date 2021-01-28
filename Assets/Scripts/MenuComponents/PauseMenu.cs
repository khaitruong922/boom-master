#pragma warning disable 0649

using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    private bool isPausing = false;
    [SerializeField]
    private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField]
    private GameObject pauseLayer;
    private void Start()
    {
        Resume();
    }
    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
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
    }
    public void Pause()
    {
        isPausing = true;
        pauseLayer.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        isPausing = false;
        pauseLayer.SetActive(false);
        Time.timeScale = 1f;
    }
}