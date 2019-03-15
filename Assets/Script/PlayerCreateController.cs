using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlayerCreateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var contexts = Contexts.sharedInstance;

        //var player = contexts.game.playerEntity;

        //player.AddPosition(this.transform.position);

        //player.isControllable = true;

        //player
        var player = contexts.game.CreateEntity();
        player.AddResource(Prefab.Player);
        player.isControllable = false;
        player.isDeleteOnExit = true;
        player.AddPosition(this.transform.position);
        player.AddFly(0);
        player.AddFlySpeed(0f, 0f);
        player.isControllable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
