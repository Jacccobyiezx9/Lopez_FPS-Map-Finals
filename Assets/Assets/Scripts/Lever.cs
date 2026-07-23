using System.Collections.Generic;
using UnityEngine;


public class Lever : MonoBehaviour, IInteractable
{
    public bool isFlipped = false;

    [SerializeField] private Animator _animator;
    [SerializeField] private List<GameObject> doors = new List<GameObject>();
    [SerializeField] private List<GameObject> Portals = new List<GameObject>();
    public void Interact()
    {
        if (!isFlipped)
        {
            _animator.SetTrigger("Flip");
            foreach (var door in doors)
            {
                Destroy(door);
                
            }

            foreach (var portal in Portals)
            {
                portal.SetActive(true);
            }

            doors.Clear();
            isFlipped = true;
        }
    }
}
