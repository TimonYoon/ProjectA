using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FollowCamera : MonoBasic
{
    private GameObject _player;
    public override void OnInit()
    {
        Subscribe(MainInstaller.Instance.OnMainInstrollerComplete, OnMainInstrollerComplete);
    }

    void OnMainInstrollerComplete(bool isComplete)
    {
        SetPlayer(MainInstaller.Instance.PlayerObject);
    }

    void SetPlayer(GameObject player)
    {
        _player = player;
    }

    private Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector3 targetPosition = _player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
