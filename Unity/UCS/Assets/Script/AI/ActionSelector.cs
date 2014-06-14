using UnityEngine;
using System.Collections;
using Util;
using System;
using Debug = UnityEngine.Debug;

namespace AI
{
    [RequireComponent(typeof(Actor))]
    public class ActionSelector : MonoBehaviour
    {
        private Actor _actor;
        private WaitTimer _wait;

        enum ActionState { Stand, Walk };
        private ActionState _state;

        void Start()
        {
            _actor = GetComponent<Actor>();
            _state = ActionState.Stand;

            _wait = new WaitTimer(TimeSpan.FromSeconds(3));
            _wait.Start();
        }

        void Update()
        {
            if (_wait.Check())
            {
                ChangeState();
                _wait.Start();
            }
        }

        void ChangeState()
        {
            switch (_state)
            {
                case ActionState.Stand:
                    _state = ActionState.Walk;
                    _actor.Walk();
                    break;
                case ActionState.Walk:
                    _state = ActionState.Stand;
                    _actor.Stand();
                    break;
            }
        }
    }
}