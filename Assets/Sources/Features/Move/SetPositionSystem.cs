/* ========================================================
 *	类名称：SetPositionSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-13 17:49:31
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Entitas;

public class SetPositionSystem : ReactiveSystem<GameEntity>
{
    public SetPositionSystem(Contexts contexts)
        : base(contexts.game)
    {
        
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var pos = e.position.position;
            e.gameObject.gameobject.transform.position = new Vector3(pos.x, pos.y, 0f);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(Matcher<GameEntity>.AllOf(
            GameMatcher.Position,
            GameMatcher.GameObject));
    }
}
