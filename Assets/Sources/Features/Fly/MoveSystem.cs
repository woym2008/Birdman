/* ========================================================
 *	类名称：MoveSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-15 15:03:48
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    GameContext _game;

    float _curspeed_h = 0;

    readonly IGroup<GameEntity> _moves;

    public MoveSystem(Contexts contexts)
    {
        _game = contexts.game;

        _moves = _game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Move, GameMatcher.GameObject));
    }

    public void Execute()
    {
        foreach (var e in _moves)
        {
            float speed = e.move.speed;
            float x = e.gameObject.gameobject.transform.position.x;
            //下落
            x += Time.deltaTime * speed;

            GameObject obj = e.gameObject.gameobject;
            obj.transform.position = new Vector3(
                x,
                obj.transform.position.y,
                obj.transform.position.z
                );
        }

    }
}
