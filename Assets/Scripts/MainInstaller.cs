using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;

public class MainInstaller : MonoBehaviour
{
    private static MainInstaller _installer;
    public static MainInstaller Instance => _installer;

    [SerializeField] 
    private List<MonoBasic> _monoBasicList;
    public GameObject PlayerObject { get; private set; }

    private ReactiveCommand<bool> onMainInstrollerComplete = new ReactiveCommand<bool>();
    public IReactiveCommand<bool> OnMainInstrollerComplete => onMainInstrollerComplete;
    private void Awake()
    {
        _installer = this;
        var inventoryManager = new InventoryManager();

        foreach (var monoBasic in _monoBasicList)
        {
            monoBasic.OnInit();
        }
    }

    private void Start()
    {
        CreatePlayer();

        onMainInstrollerComplete.Execute(true);
    }

    void CreatePlayer()
    {
        var path = "Prefab/Char/Player";
        var loadObject = Resources.Load(path);
        PlayerObject = Instantiate(loadObject) as GameObject;
        PlayerObject.transform.position = Vector3.zero;
    }
}
