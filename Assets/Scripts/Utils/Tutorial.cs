using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI guideText;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemyClone;
    private int stage = 0;
    private bool stageInProgress = false;
    private void Update()
    {
        if (stage == 0)
        {
            if (!stageInProgress)
            {
                stageInProgress = true;
                guideText.text = "Hold W,A,S,D to move your character.";
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Proceed();
            }
            return;
        }
        if (stage == 1)
        {
            if (!stageInProgress)
            {
                stageInProgress = true;
                guideText.text = "Press Space to place a bomb. The bomb will explode after a while.";
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Proceed();
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
                Proceed();
            }
            return;
        }
        if (stage == 3)
        {
            if (!stageInProgress)
            {
                stageInProgress = true;
                guideText.text = "You have finished the tutorial. Let's begin your journey";
                enemyClone = Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
        }
    }
    public void Proceed()
    {
        stage++;
        stageInProgress = false;
    }
}
