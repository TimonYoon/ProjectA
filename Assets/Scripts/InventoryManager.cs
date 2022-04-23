using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class InventoryManager : IDataBasic
{
    public static InventoryManager instance;
    public InventoryManager(InventoryData _inventoryData)
    {
        instance = this;
        inventoryData = _inventoryData;
    }

    public InventoryData inventoryData { get; }

    public void SetItem(int itemCode, int count)
    {
        if (inventoryData.InvenDic.ContainsKey(itemCode))
        {
            // inventoryData.InvenDic[itemCode] += count;
        }
    }
}

public class InventoryData : DataBasic
{
    private Dictionary<int, int> invenDic = new Dictionary<int, int>();
    public IReactiveDictionary<int, IReactiveProperty<int>> InvenDic = new ReactiveDictionary<int, IReactiveProperty<int>>(); //> invenDic;
}

public interface IDataBasic
{
    
}
public class DataBasic : IDataBasic
{
    
}
