using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelData
{
    public List<PoolData> Pools;
    public LevelData(List<PoolData> pools)// class olmad��� i�in new i�lemini bu �ekilde yapabiliriz.
    {
        Pools = pools;
    }
}
