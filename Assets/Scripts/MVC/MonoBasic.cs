using System;
using UnityEngine;
using UniRx;
using System.Collections.Generic;using GameUtility;

public class MonoBasic : MonoBehaviour
{
    private List<IDisposable> _disposableList;
    protected void Subscribe<T>(IObservable<T> source, Action<T> onNext)
    {
        _disposableList ??= new List<IDisposable>();

        source.Subscribe(onNext).AddTo(_disposableList);
    }

    protected void OnDispose()
    {
        foreach (var disposable in _disposableList)
        {
            disposable.Dispose();
        }
        _disposableList.Clear();
    }

    protected void OnDestroy()
    {
        OnDispose();
    }

    public virtual void OnInit()
    {
        
    }
}
