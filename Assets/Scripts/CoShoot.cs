using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Camera cam;
    private List<IBullet> bulletList = new List<IBullet>();
    
    public void Shoot(Vector2 dir)
    {
        var bullet = CreatBullet();
        bullet.SetPosition(transform.position);
        bullet.Shoot(dir);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector3(pos.x, pos.y, 0);
            var dir = (pos - transform.position).normalized;
            Shoot(dir);
        }
    }

    IBullet CreatBullet()
    {
        var index = bulletList.FindIndex(x => x.IsActive() == false);
        if (index >= 0)
        {
            return bulletList[index];
        }

        var go =  Instantiate(bulletPrefab);
        var bullet = go.GetComponent<IBullet>();
        bulletList.Add(bullet);
        return bullet;
    }
}
