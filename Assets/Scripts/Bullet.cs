using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IBullet
{
    bool IsActive();
    void SetPosition(Vector3 pos);
    void Shoot(Vector2 _dir);
}
public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private float speed = 1f;
    
    private Vector2 dir;
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void Shoot(Vector2 _dir)
    {
        dir = _dir;
    }

    void Update()
    {
        if (dir == Vector2.zero)
        {
            return;
        }

        var pos = dir * speed;
        transform.position += new Vector3(pos.x,pos.y,0);
    }
}
