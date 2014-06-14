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

        enum ActionState { Stand, Walk, Turn };
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
            if (_state == ActionState.Stand && _wait.Check())
            {
                StartWalk();
            }

            switch (_state)
            {
                case ActionState.Stand:
                    _actor.Stand();
                    break;
                case ActionState.Walk:
                    _actor.Walk();
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

        void StartWalk()
        {
            _state = ActionState.Walk;
        }

        void StartStand()
        {
            _wait.Start();
            _state = ActionState.Stand;
        }

        void StartTurn()
        {
            _state = ActionState.Turn;
        }
    }
}