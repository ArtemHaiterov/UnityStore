using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Sprite selectSprite;
    private bool isSelectSprite = false;
    public StoragePanel storagePanel;
    public int indexI;
    public SellerCloud sellerCloud;

   
    public void ChangeSprite()
    {
        if(isSelectSprite == false && storagePanel.isMayChooseItem)
        {
            button.GetComponent<Image>().sprite = selectSprite;
            isSelectSprite = true;
            storagePanel.currentCount++;
            sellerCloud.selectedItems.Add(indexI);
        }
        else if(isSelectSprite == true)
        {
            button.GetComponent<Image>().sprite = sprite;
            isSelectSprite = false;
            storagePanel.currentCount--;
            sellerCloud.selectedItems.Remove(indexI);
        }

    }
    //Удаляем выбранные продукты, что бы следующий покупатель мог выбрать по новой.
    public void ClearTheStorage()
    {
        if(isSelectSprite == true) 
        { 
            button.GetComponent<Image>().sprite = sprite;
            isSelectSprite = false;
        }
    }

}
