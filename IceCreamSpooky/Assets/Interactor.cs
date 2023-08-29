using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{

    public Transform InteractorSource;
    public float InteractRange;

    private int interactableLayerMask = 1 << 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                Debug.DrawRay(InteractorSource.position, InteractorSource.forward * InteractRange, Color.red, 1.0f, false);

                if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange, interactableLayerMask))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        interactObj.Interact();
                    }
                }
            }
        }
    }
}
