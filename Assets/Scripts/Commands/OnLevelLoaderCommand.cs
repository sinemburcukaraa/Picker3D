using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class OnLevelLoaderCommand
{
    private Transform _levelHolder;

    public OnLevelLoaderCommand(Transform levelHolder)//constructer , strategy pattern
    {
        _levelHolder = levelHolder;
    }
    public void Execute(byte levelIndex)
    {
        // yine monobeahiur olmadýðýndan object ile ulaþýyoruz
        Object.Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/Level {levelIndex}"), _levelHolder, true);
    }

}
