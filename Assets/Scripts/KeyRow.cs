using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRow : MonoBehaviour
{
    public KeyTile[] keys { get; private set; }

    private void Awake()
    {
        keys = GetComponentsInChildren<KeyTile>();
    }
}
