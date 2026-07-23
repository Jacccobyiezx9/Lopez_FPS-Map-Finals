using UnityEngine;
using TMPro;
using System.Collections;

public class TrialManager : MonoBehaviour
{
    public TMP_Text messageText;
    public GameObject objectToRemove;

    private int trialsCompleted = 0;
    private bool trialRunning = false;

    private void Start()
    {
        messageText.gameObject.SetActive(false);
    }
    public void StartTrial()
    {
        if (trialRunning) return;

        StartCoroutine(TrialRoutine());
    }

    private IEnumerator TrialRoutine()
    {
        trialRunning = true;

        messageText.gameObject.SetActive(true);
        messageText.text = "Trial Started!";
        yield return new WaitForSeconds(1f);

        // Countdown
        for (int i = 3; i > 0; i--)
        {
            messageText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        trialsCompleted++;
        messageText.text = "Trial Finished!";
        yield return new WaitForSeconds(2f);

        messageText.gameObject.SetActive(false);

        if (trialsCompleted >= 4)
        {
            Destroy(objectToRemove);
        }

        trialRunning = false;
    }
}