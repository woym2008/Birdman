using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    public ScriptableGameConfig config;

    GameSystem _gameSystem;
    // Start is called before the first frame update
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.config.SetGameConfig(config);

        _gameSystem = new GameSystem(contexts);
        _gameSystem.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _gameSystem.Execute();
    }
}
