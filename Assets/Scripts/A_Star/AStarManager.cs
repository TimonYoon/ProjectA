using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AStarManager : MonoBehaviour
{
    [SerializeField] private GameObject _label;
    [SerializeField] private Transform _labelGroup;
    [SerializeField] private Transform _target;
    //private Dictionary<Vector2, Text> posDic = new Dictionary<Vector2, Text>();

    public int count = 5;
    private List<Text> _textList = new List<Text>();
    [GameUtility.Inspector.Button]
    void Test()
    {
        Debug.Log("!!!!");

        var curPos = _target.position;
        var x = Mathf.RoundToInt(curPos.x);
        var y =Mathf.RoundToInt(curPos.y);

        var index = 0;
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                CreatePos(index++,new Vector2(i, j));
                CreatePos(index++,new Vector2(-i, -j));
                CreatePos(index++,new Vector2(i, -j));
                CreatePos(index++,new Vector2(-i, j));
                // var _xPlus = x + i;
                // var _xMinus = x - i;
                // var _yPlus = y + i;
                // var _yMinus = y - i;
                // CreatePos(index++,new Vector2(_xPlus, _yPlus));
                //
                // CreatePos(index++,new Vector2(_xMinus, _yMinus));
            }            
        }

    }
    
    void CreatePos(int index, Vector2 pos)
    {
        Text label;
        if (index >= _textList.Count)
        {
            var go = Instantiate(_label, _labelGroup);
            label = go.GetComponent<Text>();
            _textList.Add(label);
        }
        else
        {
            label = _textList[index];
        }        
        
        label.transform.position = Camera.main.WorldToScreenPoint(pos);
        label.text = $"({(int) pos.x},{(int) pos.y})";

    }
}
