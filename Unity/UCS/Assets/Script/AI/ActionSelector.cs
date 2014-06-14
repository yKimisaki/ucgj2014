using UnityEngine;
using System.Collections;
using Util;
using System;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace AI
{
    [RequireComponent(typeof(Actor))]
    public class ActionSelector : MonoBehaviour
    {
        private Actor _actor;
        private WaitTimer _wait;

        enum ActionState { Stand, Walk, Run, Turn };
        private ActionState _state;

        private int _waitNumber = 0;

        void Start()
        {
            _actor = GetComponent<Actor>();
            _state = ActionState.Stand;

            _wait = new WaitTimer();
            _wait.Start(TimeSpan.FromSeconds(3));
        }

        void Update()
        {
            if (_state == ActionState.Stand && _wait.Check())
            {
                StartWalkOrRun();
            }

            switch (_state)
            {
                case ActionState.Stand:
                    _actor.Stand(_waitNumber);
                    break;
                case ActionState.Walk:
                        _actor.Walk();
                    break;
                case ActionState.Run:
                    _actor.Run();
                    break;
                case ActionState.Turn:
                    _actor.Turn(Random.Range(-60, 60));
                    StartStand();
                    break;
            }
        }

        public void OnNearWall(Vector3 normal)
        {
            this.transform.rotation = Quaternion.LookRotation(normal);
            StartTurn();
        }

        void StartWalkOrRun()
        {
            if (Random.Range(0, 100) > 90)
                _state = ActionState.Run;
            else
                _state = ActionState.Walk;
        }

        void StartStand()
        {
            _waitNumber = Random.Range(-5, 3);
            _waitNumber = _waitNumber < 0 ? 0 : _waitNumber;

            var waitTime = _waitNumber == 1 ?  7 : Random.Range(2, 5);
            _wait.Start(TimeSpan.FromSeconds(waitTime));
            _state = ActionState.Stand;
        }

        void StartTurn()
        {
            _state = ActionState.Turn;
        }
    }
}