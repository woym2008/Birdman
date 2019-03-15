/* ========================================================
 *	类名称：ResourceComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-12 19:54:54
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

[Game]
public class ResourceComponent : IComponent
{
    public Prefab prefab;

    public string name
    {
        get
        {
            return prefab.ToString();
        }
    }
}
