﻿/* ========================================================
 *	类名称：LevelComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-13 16:19:44
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Unique]
public class LevelComponent : IComponent
{
    public int level;
}
