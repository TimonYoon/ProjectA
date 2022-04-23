using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (Camera.main is { })
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D ray2D = new Ray2D(pos, Vector2.zero);
                RaycastHit2D hit2D = Physics2D.Raycast(ray2D.origin, ray2D.direction);

                if (hit2D.collider != null)
                {
                    Debug.Log($"선택 {hit2D.transform.name}");
                    target = hit2D.collider.transform;
                }
            }           
        }

        if (Input.GetMouseButton(0))
        {
            if (target != null)
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var x = Mathf.Round(pos.x);
                var y = Mathf.Round(pos.y);
                pos = new Vector3(x, y, 0);
                target.transform.position = pos;
                return;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            target = null;
        }
    }
}
