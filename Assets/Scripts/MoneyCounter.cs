using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public Text moneyText;
    public static int moneyAmount;
    void Start()
    {
        moneyText = GetComponent<Text>();
    }
    private void Update()
    {
        moneyText.text = moneyAmount.ToString() + " $";
    }
    //public void AddMoney()
    //{
    //    moneyAmount += 100;
    //    moneyText.text = moneyAmount.ToString() + " $";
    //}

}
