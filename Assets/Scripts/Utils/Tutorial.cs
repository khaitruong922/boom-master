using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image guideBackground;
    [SerializeField] private TextMeshProUGUI guideText;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemyClone;
    private GameManager gameManager;
    private bool isProceeding = false;
    private int stage = 0;
    private bool stageInProgress = false;
    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnVictory += HideGuide;
    }
    private void OnDestroy()
    {
        gameManager.OnVictory -= HideGuide;
    }
    private void Update()
    {
        if (isProceeding) return;
        if (stage == 0)
        {
            if (!stageInProgress)
            {
                stageInProgress = true;
                guideText.text = "Hold W,A,S,D to move your character.";
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (stageInProgress) Proceed();
            }
            return;
        }
        if (stage == 1)
        {
            if (!stageInProgress)
            {
                stageInProgress = true;
                guideText.text = "Press Space to place a bomb.\nThe bomb will explode after a while.";
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (stageInProgress) Proceed();
            }
            return;
        }
        if (stage == 2)
        {
            if (!stageInProgress)
            {
                stageInProgress = true;
                guideText.text = "Place bomb to defeat your enemy.";
                enemyClone = Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
            if (enemyClone == null)
            {
                if (stageInProgress) Proceed();
            }
            return;
        }
        if (stage == 3)
        {
            if (!stageInProgress)
            {
                stageInProgress = true;
                guideText.text = "You have finished the tutorial. Let's begin your journey.";
            }
        }
    }
    public void Proceed()
    {
        StartCoroutine(Proceeding());
    }
    private IEnumerator Proceeding()
    {
        isProceeding = true;
        stageInProgress = false;
        stage++;
        yield return new WaitForSeconds(2);
        isProceeding = false;
    }
    private void HideGuide()
    {
        guideBackground.gameObject.SetActive(false);
    }
}
