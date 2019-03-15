/* ========================================================
 *	类名称：FlySystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-12 18:11:03
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

public class FlySystem : IExecuteSystem
{
    GameContext _game;

    float _curspeed_v = 0;

    readonly IGroup<GameEntity> _flys;

    public FlySystem(Contexts contexts)
    {
        _game = contexts.game;

        _flys = _game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Fly,GameMatcher.GameObject));
    }

    //protected override bool Filter(GameEntity entity)
    //{
    //    return entity.hasFly;
    //}

    public void Execute()    
    {
        foreach(var e in _flys)
        {
            float flyPower = e.fly.power;
            e.fly.power = 0;
            //如果给力 则有个上升速度
            _curspeed_v += flyPower * e.flySpeed.flyspeed;
            //下落
            _curspeed_v += Time.deltaTime * e.flySpeed.gravity;

            GameObject obj = e.gameObject.gameobject;
            obj.transform.position = new Vector3(
                obj.transform.position.x,
                obj.transform.position.y + _curspeed_v * Time.deltaTime,
                obj.transform.position.z
                );
        }
        
    }

    //protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    //{
    //    throw new NotImplementedException();
    //}
}
