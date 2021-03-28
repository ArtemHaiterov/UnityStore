using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellerCloud : MonoBehaviour
{
    [SerializeField]
    private AudioSource addMoney;
    [SerializeField]
    private AudioSource disappearCloud;
    [SerializeField]
    private List<Sprite> items;
    [SerializeField]
    private List<Sprite> wrongSprites;
    [SerializeField]
    private List<Sprite> correctSprits;
    [SerializeField]
    private List<GameObject> cells;
    [SerializeField]
    private GameObject scoreText;
    private const string anim = "isActive";
    private Animator animator;
    private int money = 0;
    public StoragePanel storage;
    public OrderController orderController;
    public bool isActive = false;
    public int correctItems = 0;
    public List<int> selectedItems = new List<int>();

    private void Start()
    {
        LoadGame();
        animator = GetComponent<Animator>();
        scoreText.GetComponent<Text>().text = "$" + money;
    }

    private void Update()
    {
        SetBool();
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", money);
        PlayerPrefs.Save();
    }
    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            money = PlayerPrefs.GetInt("SavedInteger");
        }
        
    }

    public void ShowOrder()
    {
        for (int i = 0; i < selectedItems.Count; i++)
        {
            cells[i].GetComponent<Image>().sprite = items[selectedItems[i]];
        }     
        StartCoroutine("CheckOrder");
    }

    
    private void ClearTheSellersCloud()
    {
        for (int i = 0; i < orderController.countOfItems; i++)
        {
            cells[i].GetComponent<Image>().sprite = null;
           
        }
    }

    private void AddMoney()
    {
        if (correctItems == orderController.countOfItems)
        {
            money += correctItems * 20;
        }
        else
        {
            money += correctItems * 10;
        }
        addMoney.Play();
        scoreText.GetComponent<Text>().text = "$" + money;
    }
    private void SetBool()
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

    IEnumerator CheckOrder()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < orderController.countOfItems; i++)
        {

            if (orderController.indexOfItems.Contains(selectedItems[i]))
            {
                cells[i].GetComponent<Image>().sprite = correctSprits[selectedItems[i]];
                correctItems++;
                yield return new WaitForSeconds(0.5f);
            }
            else if (!orderController.indexOfItems.Contains(selectedItems[i]))
            {
                cells[i].GetComponent<Image>().sprite = wrongSprites[selectedItems[i]];
                yield return new WaitForSeconds(0.5f);
            }
        }
        yield return new WaitForSeconds(1);
        AddMoney();

        orderController.ShowResultEmotion();
        isActive = false;
        disappearCloud.Play();
        ClearTheSellersCloud();
        storage.currentCount = 0;
        selectedItems.Clear();
        orderController.isActive = true;


    }
}
