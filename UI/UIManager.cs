using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //This is a singleton design pattern which means that this class will exactly have one object

    /*Static keyword is used to keep the value of the object throught out the entire program 
     meaning you can access the varaible in any function aand value won't change */

    //it automaticallys initializes the variable to zero meaning clears all the garbage

    // instance means object and instantiation means the process of creating an object

    //First we need to create an instance(object) variable that is going to run along all classes
    private static UIManager _instance;

    //Then we create a property to acess that instance(object), which is _instance

    //this is the property
    public static UIManager Instance
        //we don't need the set. This is just going to grab the object and return it
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is Empty");
            }
            return _instance;
        }
    }

    //called when script is being loaded
    void Awake()
    {
        _instance = this;
    }

    public Text playerGemCount;
    public Image selectionimg;
    public Text gemCount;
    public Image[] lifeUnits;

    public void OpenShop(int gemCount)
    {
        playerGemCount.text = "" + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionimg.rectTransform.anchoredPosition = new Vector2(selectionimg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCount.text = "" + count;
    }

    public void UpdateLiveBars(int livesRemaining)
    {
        for(int i=0; i <= livesRemaining; i++)
        {
            if(i == livesRemaining)
            {
                lifeUnits[i].enabled = false;
            }
        }
    }
}
