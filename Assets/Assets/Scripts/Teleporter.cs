using UnityEngine;

public class Teleporter : MonoBehaviour, IInteractable
{
    [Header("Destination")]
    [SerializeField] private Transform destination;

    [Header("Settings")]
    [SerializeField] private float exitOffset = 1.5f;

    private bool canTeleport = true;

    public void Interact()
    {
        if (!canTeleport || destination == null)
            return;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        CharacterController controller = player.GetComponent<CharacterController>();

        // Disable CharacterController before moving
        if (controller != null)
            controller.enabled = false;

        player.transform.position = destination.position + destination.up * exitOffset;

        if (controller != null)
            controller.enabled = true;

        // Prevent instantly teleporting back
        Teleporter other = destination.GetComponent<Teleporter>();
        if (other != null)
        {
            other.canTeleport = false;
            Invoke(nameof(ResetTeleport), 0.5f);
            other.Invoke(nameof(ResetTeleport), 0.5f);
        }
    }

    private void ResetTeleport()
    {
        canTeleport = true;
    }
}