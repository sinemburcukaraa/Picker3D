using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PoolData 
{
    public byte RequiredObjectCount;// optimizasyon açýsýndan level sisteminde int gibi deðer aralýðý yüksek deðiþken kullanmamýza gerek yok 
    //byte 0-250 arasýný kapsar
}
