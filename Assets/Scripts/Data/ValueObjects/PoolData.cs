using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PoolData 
{
    public byte RequiredObjectCount;// optimizasyon a��s�ndan level sisteminde int gibi de�er aral��� y�ksek de�i�ken kullanmam�za gerek yok 
    //byte 0-250 aras�n� kapsar
}
