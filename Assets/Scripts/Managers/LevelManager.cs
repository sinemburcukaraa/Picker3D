using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Transform levelHolder;
    [SerializeField] private byte totalLevelCount;

    private short _currentLevel;
    private LevelData _levelData;
    private OnLevelLoaderCommand _levelLoaderCommand;
    private OnLevelDestroyerCommand _levelDestroyerCommand;


    private void Awake()
    {
        //_levelData=GetLevelData();
        //_currentLevel= GetActiveLevel();
        init();
    }

    [Button]
    public void LevelLoader(byte levelIndex)
    {
        _levelLoaderCommand.Execute(levelIndex);
    }
    [Button]
    public void LevelDestroy()
    {
        _levelDestroyerCommand.Execute();
    }
    private void init()
    {
        _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
        _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
    }

    private byte GetActiveLevel()
    {
        return (byte)_currentLevel;
    }

    private LevelData GetLevelData()
    {
        return Resources.Load<CD_Level>("Data/CD_Level").levels[_currentLevel];
    }
    private void OnEnable() => SubscribeEvents();

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onlevelInitialize += _levelLoaderCommand.Execute;
        CoreGameSignals.Instance.onClearActiveLevel += _levelDestroyerCommand.Execute;
        CoreGameSignals.Instance.onGetLevelValue += OnGetLevelValue;
        CoreGameSignals.Instance.onNextLevel += OnNextLevel;
        CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;


    }//sýngleton u sinyaller dýþýnda kullanmayý tavsiye etmedi
    public void OnNextLevel()
    {
        _currentLevel++;
        CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
        CoreGameSignals.Instance.onReset?.Invoke();
        CoreGameSignals.Instance.onlevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));

    }
    private void OnRestartLevel()
    {
        CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
        CoreGameSignals.Instance.onReset?.Invoke();
        CoreGameSignals.Instance.onlevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
    }
    public byte OnGetLevelValue() { return (byte)_currentLevel; }

    private void OnDisable() => UnSubscribeEvents();

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onlevelInitialize -= _levelLoaderCommand.Execute;
        CoreGameSignals.Instance.onClearActiveLevel -= _levelDestroyerCommand.Execute;
        CoreGameSignals.Instance.onGetLevelValue -= OnGetLevelValue;
        CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
        CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;


    }
    private void Start()// seviye oluþturma
    {
        CoreGameSignals.Instance.onlevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
            
        //UI SÝGNAL
    }

}
