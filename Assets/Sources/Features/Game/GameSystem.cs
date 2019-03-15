using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : Feature
{
    public GameSystem(Contexts contexts)
    {
        //
        Add(new GameStartSystem(contexts));
        Add(new GameOverSystem(contexts));
        //
        Add(new LoadResourceSystem(contexts));
        Add(new InputSystem(contexts));

        Add(new SetPositionSystem(contexts));
        Add(new FlySystem(contexts));
        Add(new MoveSystem(contexts));
    }
}
