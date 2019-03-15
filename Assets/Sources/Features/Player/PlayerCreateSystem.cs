using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlayerCreateSystem : ReactiveSystem<GameEntity>
{
    public PlayerCreateSystem(Contexts contexts)
        : base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        //foreach(var e in entities)
        //{
        //    //e.position
        //    e.position
        //}
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayerCreator;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(Matcher<GameEntity>.AllOf(
            GameMatcher.Player,
            GameMatcher.Level));
    }
}
