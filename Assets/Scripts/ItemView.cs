using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Text count_Label;
    [Header("Data")] [SerializeField] private int itemCode;
    private void Start()
    {
        SetUI(0);
        InventoryManager.instance.InvenDic.ObserveAdd().Subscribe(x=>
        {
            Debug.Log($"Add {x.Key} / {x.Value}");
            if (x.Key == itemCode)
            {
                x.Value.Subscribe(
                    o =>
                    {
                        Debug.Log($"change value {itemCode} / {o}");
                        SetUI(o);
                    }).AddTo(this);
            }
        }).AddTo(this);
    }

    void SetUI(int count)
    {
        count_Label.text = count.ToString();
    }
}
