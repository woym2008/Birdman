/* ========================================================
 *	类名称：ScriptableGameConfig
 *	作 者：Zhangfan
 *	创建时间：2019-03-12 14:22:48
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "TestGame/Game Config")]
public class ScriptableGameConfig : IConfig
{
    [SerializeField] float _maxTime; public float maxTime => _maxTime;
}
