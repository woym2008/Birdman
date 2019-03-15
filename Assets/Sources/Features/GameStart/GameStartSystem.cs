/* ========================================================
 *	类名称：GameStartSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-12 14:36:55
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

public class GameStartSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly GameContext game;

    IGroup<GameEntity> deleteOnNextLevel;

    public GameStartSystem(Contexts contexts)
        : base(contexts.game)
    {
        game = contexts.game;
        deleteOnNextLevel = game.GetGroup(GameMatcher.DeleteOnNextLevel);
    }

    public void Initialize()
    {
        game.SetLevel(1);

        SetGameScene(1);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        int level = game.level.level;
        //delete last
        //foreach(var entity in deleteOnExitGroup.GetEntities())
        //{

        //}
        //如果之前存储了 cache 了level 可以传进去level
        


    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return new Collector<GameEntity>(
            new[] { context.GetGroup(GameMatcher.GameObject) },
            new[] { GroupEvent.Removed }
        );
    }

    //开始游戏 创建关卡 和 主角
    void SetGameScene(int level)
    {
        Debug.Log("Setup level " + level);

        //level
        //先不管传进来的level,初始化第一关
        var level1 = game.CreateEntity();
        level1.AddResource(Prefab.Level);
        level1.isDeleteOnExit = true;
        level1.AddPosition(new Vector3(0, 0, 0));

        

    }
}
