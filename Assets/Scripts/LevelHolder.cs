using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    public int level;
    public static LevelHolder instance;

    private void Start()
    {
        instance = this;
    }
}
