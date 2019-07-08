using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Shop_Panel;
    private int CurrentItemSelected;
    private int CurrentItemCost;

    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.Diamonds);
            }

            Shop_Panel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Shop_Panel.SetActive(false);
        }
    }

    public void SelectItem(int ItemNo)
    {
        switch(ItemNo)
        {
            case 0: //flame Sword
                {
                    UIManager.Instance.UpdateShopSelection(62);
                    CurrentItemSelected = 0;
                    CurrentItemCost = 200;
                    break;
                }
            case 1: //Boots of flight
                {
                    UIManager.Instance.UpdateShopSelection(-26);
                    CurrentItemSelected = 1;
                    CurrentItemCost = 400;
                    break;
                }
            case 2: //Key to the Castle
                {
                    UIManager.Instance.UpdateShopSelection(-131);
                    CurrentItemSelected = 2;
                    CurrentItemCost = 100;
                    break;
                }
        }

        Debug.Log("Select Item is called");
    }

    public void BuyItem()
    {
        if(_player.Diamonds >= CurrentItemCost)
        {
            if(CurrentItemSelected == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            Debug.Log("You just bought " + CurrentItemSelected);
            _player.Diamonds -= CurrentItemCost;
            Debug.Log("current gems are: " + _player.Diamonds);
            Shop_Panel.SetActive(false);
        }
        else
        {
            Debug.Log("Sorry you dont have enough gems");
            Shop_Panel.SetActive(false);
        }
    }
}
