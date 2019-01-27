using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private static TMP_Text remainingFundsText;
    private static Button buyButton;

    // Start is called before the first frame update
    void Start()
    {
        buyButton = transform.Find("BuyPanel").GetComponentInChildren<Button>();
        buyButton.interactable = false;
        buyButton.onClick.AddListener(BuyItems);
        remainingFundsText = transform.Find("Funds Remaining").GetComponentInChildren<TMP_Text>();
        remainingFundsText.text = "Funds Remaining: $" + GameData.playerFunds.ToString();
    }

    public static void UpdateFunds()
    {
        remainingFundsText.text = "Funds Remaining: $" + (GameData.playerFunds - GameData.totalShopPurchasePrice);
        if (GameData.totalShopPurchasePrice != 0)
        {
            buyButton.interactable = true;
        }
        else buyButton.interactable = false;
    }

    void BuyItems()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().DrawInventory();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
