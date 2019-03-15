/* ========================================================
 *	类名称：LoadResourceSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-13 15:18:03
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

public class LoadResourceSystem : ReactiveSystem<GameEntity>
{
    public LoadResourceSystem(Contexts contexts)
        : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            var resname = "Prefabs/" + e.resource.name;
            var res = Resources.Load<GameObject>(resname);
            GameObject obj = null;
            try
            {
                obj = GameObject.Instantiate(res);
            }
            catch (Exception)
            {
                Debug.Log("Not Instantiate " + resname);
            }
            if(obj == null)
            {
                continue;
            }

            if (e.hasPosition)
            {
                obj.transform.position = e.position.position;
            }

            e.AddGameObject(obj);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Resource);
    }
}
