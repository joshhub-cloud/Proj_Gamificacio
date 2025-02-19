using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public ItemScriptableObject Item1;
    public Image Image1;
    public TextMeshProUGUI textItem1;
    public Button Buy1;

    // Update is called once per frame
    void OnEnable()
    {
        Image1.sprite = Item1.image;
        CheckIfCanBuy(Item1, textItem1, Buy1);
    }
    public void BuyItemBow()
    {
        GameManager.gameManager.ItemCollected(Item1.image, 0);
        GameManager.gameManager.CoinCollected(-Item1.price);
        CheckIfCanBuy(Item1, textItem1, Buy1);
    }

    private void CheckIfCanBuy(ItemScriptableObject item, TextMeshProUGUI insuCoins, Button buyButton)
    {
        if(GameManager.gameManager.coins >= item.price) 
        { 
            insuCoins.text = "" + item.price;
            insuCoins.color = Color.yellow;
            buyButton.interactable = true;
        }
        else
        {
            insuCoins.text = "insuficient coins: " + item.price;
            insuCoins.color = Color.red;
            buyButton.interactable = false;
        }
    }    
}
