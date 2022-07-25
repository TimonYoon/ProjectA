using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool isDie = true;
    private void OnEnable()
    {
        isDie = false;
    }

    private void OnDisable()
    {
        isDie = true;
    }

    void Update()
    {
        if(isDie)
            return;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.01f);
    }
}
