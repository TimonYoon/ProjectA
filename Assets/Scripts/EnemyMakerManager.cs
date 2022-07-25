using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefab;
    private List<GameObject> enemyObjectList = new List<GameObject>();
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            var enemy = GetEnemyObject();
            enemy.transform.position = GetCreatePos();
            enemy.SetActive(true);
        }

    }

    GameObject GetEnemyObject()
    {
        var go = enemyObjectList.Find(x => x.activeSelf == false);
        if (go == null)
        {
            go = Instantiate(enemyPrefab, transform, false);
            enemyObjectList.Add(go);
        }        
        return go;
    }

    [SerializeField] private float dis = 10f;
    Vector3 GetCreatePos()
    {
        
        var isPlusX = UnityEngine.Random.Range(0, 2) == 1;
        var isPlusY = UnityEngine.Random.Range(0, 2) == 1;

        var x = player.transform.position.x;
        var y = player.transform.position.y;

        x = isPlusX ? x + dis : x - dis;
        y = isPlusY ? y + dis : y - dis;

        return new Vector3(x, y, 0);
    }
}
