using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
    #region Singleton
    public static CoreGameSignals Instance;
    private void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    #endregion
    public UnityAction<byte> onlevelInitialize = delegate { };
    public UnityAction onClearActiveLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onReset = delegate { };
    public Func<byte> onGetLevelValue = delegate { return 0; }; // bu func hem de�er al�yor hem veriyor
    //ongetlevelvalue return olan bir fonksiyon i�eriyor ondan dolay� b�yle


}
//observer, sing, factory, sinyalleri (delegate, unity events,untiy acction , funk ),command pattern
//ara�t�r
