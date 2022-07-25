using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class InventoryManager : InventoryData
{
    public static InventoryManager instance;
    public InventoryManager()
    {
        instance = this;
        SetItem(1, 99);
        //inventoryData = _inventoryData;
    }

    //public InventoryData inventoryData { get; }

    public void SetItem(int itemCode, int count)
    {
        if (invenDic.ContainsKey(itemCode))
        {
            count = invenDic[itemCode].Value + count;
            invenDic[itemCode].SetValueAndForceNotify(count);
        }
        else
        {
            invenDic.Add(itemCode,new ReactiveProperty<int>());
            invenDic[itemCode].SetValueAndForceNotify(count);
        }
    }
}

public class InventoryData : DataBasic
{
    protected ReactiveDictionary<int, ReactiveProperty<int>> invenDic = new ReactiveDictionary<int, ReactiveProperty<int>>();
    public IReactiveDictionary<int, ReactiveProperty<int>> InvenDic => invenDic;

}

public interface IDataBasic
{
    
}
public class DataBasic : IDataBasic
{
    
}
