using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Config, Unique, ComponentName("GameConfig")]
public interface IConfig
{
    float maxTime { get; }
}
