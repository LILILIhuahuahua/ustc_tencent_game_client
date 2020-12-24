using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    [HideInInspector]
    public int segment = 3;
    [HideInInspector]
    public Vector3[] posList;
    private void Awake()
    {
        posList = new Vector3[segment];
    }
    public void InitPosList(Vector3 pos)
    {
        for (int i = 0; i < posList.Length; i++)
        {
            posList[i] = pos;
        }
    }
    public void Move(Vector3 target)
    {
        for (int i = posList.Length - 1; i > 0; i--)
        {
            posList[i] = posList[i - 1];
        }
        posList[0] = target;
        transform.localPosition = posList[segment / 2];
    }
}
