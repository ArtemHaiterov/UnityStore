using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    [SerializeField]
    private AudioSource dissapearCloud;
    [SerializeField]
    private AudioSource apearCloud;
    [SerializeField]
    private RectTransform rectTransform;
    private Animator animator;
    private const string anim = "isBought";
    private const float rotationY = 0.9992328f;
    private const float rotationW = 0.03916302f;
    public OrderController orderController;
    public StoragePanel storagePanel;
    public bool isBought = true;



    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetBool();
    }

    public void MakeAnOrder()
    {
        apearCloud.Play();
        orderController.ComeToCashierMachine();
        orderController.isActive = true;
        StartCoroutine("OpenStorage");
    }

    public void NextBuyer()
    {
        orderController.isActive = false;
        isBought = false; 
        StartCoroutine("DelayBetweenBuyers");

    }
    IEnumerator OpenStorage()
    {
        yield return new WaitForSeconds(5);
        storagePanel.isOpen = true;
        dissapearCloud.Play();
        orderController.isActive = false;
    }
    IEnumerator DelayBetweenBuyers()
    {
        yield return new WaitForSeconds(1);
    }


    private void SetBool()
    {
        if (isBought == false)
        {
            animator.SetBool(anim, false);
            rectTransform.localRotation = new Quaternion(0, 0, 0, 1);
        }

        if (isBought == true)
        {
            animator.SetBool(anim, true);
            rectTransform.localRotation = new Quaternion(0, rotationY, 0, rotationW);
        }
    }
}
