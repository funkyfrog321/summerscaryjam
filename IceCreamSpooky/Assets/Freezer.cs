using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour, IInteractable
{
    Animation lidAnimation;
    Animator animator;
    bool open = false;
    public void Interact()
    {
        animator.SetTrigger("Interact");

        //if (open)
        //{
        //    Debug.Log("Close Freezer");
        //    lidAnimation.Play("Close_Freezer");
        //    open = false;
        //}
        //else
        //{
        //    Debug.Log("Open Freezer");
        //    lidAnimation.Play("Open_Freezer");
        //    open = true;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        //lidAnimation = transform.GetChild(0).GetComponent<Animation>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
