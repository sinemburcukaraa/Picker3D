using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelData
{
    public List<PoolData> Pools;
    public LevelData(List<PoolData> pools)// class olmadýðý için new iþlemini bu þekilde yapabiliriz.
    {
        Pools = pools;
    }
}
