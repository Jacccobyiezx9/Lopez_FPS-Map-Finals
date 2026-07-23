using UnityEngine;

public class TrialStarter : MonoBehaviour, IInteractable
{
    public TrialManager manager;

    private bool used = false;

    public void Interact()
    {
        if (used) return;

        used = true;
        manager.StartTrial();
    }
}