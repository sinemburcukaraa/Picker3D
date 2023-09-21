using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class OnLevelDestroyerCommand
{
    private Transform _levelHolder;
    public OnLevelDestroyerCommand(Transform levelHolder)//constructer ,  strategy pattern
    {
        _levelHolder = levelHolder;
    }
    [Button]
    public void Execute()
    {
        if (_levelHolder.transform.childCount <= 0) return;
        Object.Destroy(_levelHolder.transform.GetChild(0).gameObject); // monobeahivur olmadýðýndan dolayý destroya object ile ulaþtýk.
    }
    
}
