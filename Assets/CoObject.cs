using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoObject : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    private bool isStart = false;
    private bool isAuto = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isAuto)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }
        
        isStart = true;
        var position = transform.position;
        var pos = position;
        if (Camera.main is { })
        {
            rectTransform.position = Camera.main.WorldToScreenPoint(position);
        }

        StartObject();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isAuto)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        isStart = false;
        StopObject();
    }

    private Coroutine objectStartcoroutine;
    private void StartObject()
    {
        objectStartcoroutine = StartCoroutine(ObjectStartCoroutine());
    }

    private void StopObject()
    {
        if (objectStartcoroutine == null)
        {
            return;
        }

        StopCoroutine(objectStartcoroutine);
        objectStartcoroutine = null;
    }

    IEnumerator ObjectStartCoroutine()
    {
        while (isStart)
        {
            yield return new WaitForSeconds(1f);
            yield return null;
            Debug.Log("Get!! ");
        }
    }
}
