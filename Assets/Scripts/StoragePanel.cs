using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoragePanel : MonoBehaviour
{
    [SerializeField]
    private AudioSource apearCloud;
    [SerializeField]
    private Button sellButton;
    private Animator animator;
    private const string anim = "isOpen";
    public OrderController orderController;
    public SellerCloud sellerCloud;
    public int currentCount = 0;
    public bool isOpen = false;
    public bool isMayChooseItem = true;
    public bool isSell = false;
    public bool isChecked = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetBool();
        MayChooseItem(orderController.countOfItems, currentCount);
    }

    public void MayChooseItem(int max, int currentCount)
    {
        if (currentCount >= max)
        {
            isMayChooseItem = false;
        }
        else
        {
            isMayChooseItem = true;
        }
        if (currentCount == max)
        {
            sellButton.enabled = true;
            sellButton.image.color = new Color(255, 255, 255, 1f);
            isSell = true;
        }
        else
        {
            sellButton.enabled = false;
            sellButton.image.color = new Color(255, 255, 255, 0.5f);
            isSell = false;
        }          
    }

    public void CloseStorage()
    {
        if (isSell == true)
        {
            isOpen = false;
            apearCloud.Play();
            sellerCloud.isActive = true;
        }
    }
    
    private void SetBool()
    {
        if (isOpen == false)
        {
            animator.SetBool(anim, false);
        }


        if (isOpen == true)
        {
            animator.SetBool(anim, true);
        }
    }
}
