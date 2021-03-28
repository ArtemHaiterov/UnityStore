using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> items;
    [SerializeField]
    private List<GameObject> cells;
    [SerializeField]
    private RectTransform parent;
    [SerializeField]
    private Sprite badResult;
    [SerializeField]
    private Sprite goodResult;
    private const string anim = "isActive";
    private Animator animator;
    public bool isActive = false;
    public SellerCloud sellerCloud;
    public Buyer buyer;
    //количество товаров заданных покупателем 
    public int countOfItems;
    //коллекция с индексами товаров покупателя, для сравнения продавцом
    public List<int> indexOfItems = new List<int>();

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetBool();
    }

    public void ComeToCashierMachine()
    {
        int randCountItem = Random.Range(1, 4);
        countOfItems = randCountItem;

        for(int i = 0; i < randCountItem; i++)
        {
            if(indexOfItems.Count == 0)
            {
                int rand = Random.Range(0, items.Count);
                indexOfItems.Add(rand);
                cells[i].GetComponent<Image>().sprite = items[rand];
            }
            else
            {
                bool isCorrect = true;
                while (isCorrect)
                {
                    int rand = Random.Range(0, items.Count);
                    if (!indexOfItems.Contains(rand))
                    {
                        cells[i].GetComponent<Image>().sprite = items[rand];
                        indexOfItems.Add(rand);
                        isCorrect = false;
                    }
                }             
            }
           
        }
       
    }
    public void ShowResultEmotion()
    {
        for(int i = 0; i < countOfItems; i++)
        {
            if (i == 0) cells[i].GetComponent<Image>().sprite = sellerCloud.correctItems == countOfItems ? goodResult : badResult;
            else
            {
                cells[i].GetComponent<Image>().sprite = null;
            }

        }
        sellerCloud.correctItems = 0;
        buyer.isBought = true;
            
    }

    public void SetBool()
    {
            if (isActive == false)
            {
                animator.SetBool(anim, false);
            }

            if (isActive == true)
            {
                animator.SetBool(anim, true);
            }
    }
}
