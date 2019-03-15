/* ========================================================
 *	类名称：InputSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-12 16:06:24
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

public class InputSystem : IExecuteSystem
{
    readonly InputContext input;
    readonly GameContext game;

    float _defaultPower = .5f;
    float _addPower = .2f;
    float _maxPressTime = 0.5f;
    float _curPressTime = 0;

    bool _pushedButton = false;

    readonly IGroup<GameEntity> _flys;

    public InputSystem(Contexts contexts)
    {
        input = contexts.input;
        game = contexts.game;

        _flys = game.GetGroup(GameMatcher.Fly);
    }

    public void Execute()
    {
        if(game.isGameOver)
        {
            return;
        }

        float deltaTime = Time.deltaTime;

        float power = GetInputPower();

        foreach(var e in _flys)
        {
            Debug.Log("power: " + power);
            e.ReplaceFly(power);
            if(e.flySpeed.gravity == 0 && power>0)
            {
                e.ReplaceFlySpeed(1, -2.0f);

                if (!e.hasMove)
                {
                    e.AddMove(1.0f);
                }
            }            
        }        
    }

    float GetInputPower()
    {
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        return GetTouchPower();
#else
        return GetMouseInputPower();
#endif
    }

    float GetMouseInputPower()
    {        
        if (Input.GetMouseButtonDown(0) && !_pushedButton)
        {
            _curPressTime += Time.deltaTime;
            return _defaultPower;
        }
        else if(Input.GetMouseButton(0) && !_pushedButton)
        {
            _curPressTime += Time.deltaTime;
            if(_curPressTime > _maxPressTime)
            {
                _pushedButton = true;
                _curPressTime = 0;
            }
            return _addPower;
        }

        _pushedButton = false;
        _curPressTime = 0;

        return 0;
    }

    float GetTouchPower()
    {
        if(Input.touchCount > 0)
        {
            Touch firstTouch = Input.touches[0];
            if (firstTouch.phase == TouchPhase.Began && !_pushedButton)
            {
                _curPressTime += Time.deltaTime;
                return _defaultPower;
            }
            else if ((firstTouch.phase == TouchPhase.Moved ||
                firstTouch.phase == TouchPhase.Stationary)&& !_pushedButton)
            {
                _curPressTime += Time.deltaTime;
                if (_curPressTime > _maxPressTime)
                {
                    _pushedButton = true;
                    _curPressTime = 0;
                }
                return _addPower;
            }

            _pushedButton = false;
            _curPressTime = 0;
        }

        return 0;
    }
}
