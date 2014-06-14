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

        enum ActionState { Stand, Walk, Run, Turn, FindPlayer };
        private ActionState _actionState;
        private bool _isFollow = false;
        private Player _follow;

        private int _waitNumber = 0;

        void Start()
        {
            _actor = GetComponent<Actor>();
            _actionState = ActionState.Stand;

            _wait = new WaitTimer();
            _wait.Start(TimeSpan.FromSeconds(3));
        }

        void Update()
        {
            if (_isFollow)
            {
                switch (_actionState)
                {
                    case ActionState.Turn:
                        _actor.Turn(Random.Range(60, 60));
                        _actionState = ActionState.Run;
                        break;
                    case ActionState.Run:
                        _actor.Run();
                        var ray = new Ray(this.transform.position,
                            (_follow.transform.position- transform.position).normalized);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                            if (hit.transform.gameObject.GetComponent<Player>() != null)
                                _actionState = ActionState.FindPlayer;
                        break;
                    case ActionState.FindPlayer:
                        _actor.FollowPlayer(_follow);
                        break;
                }
                return;
            }

            if (_actionState == ActionState.FindPlayer)
            {
                if (!_wait.Check())
                {
                    _actor.FindPlayer();
                    return;
                }

                _isFollow = true;
                return;
            }

            if (_actionState == ActionState.Stand && _wait.Check())
            {
                StartWalkOrRun();
            }

            switch (_actionState)
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

        public void OnFindPlayer(Player player)
        {
            if (_isFollow)
                return;

            _follow = player;
            _actionState = ActionState.FindPlayer;
            _wait.Start(TimeSpan.FromSeconds(3));
        }

        void StartWalkOrRun()
        {
            if (Random.Range(0, 100) > 90)
                _actionState = ActionState.Run;
            else
                _actionState = ActionState.Walk;
        }

        void StartStand()
        {
            _waitNumber = Random.Range(-5, 3);
            _waitNumber = _waitNumber < 0 ? 0 : _waitNumber;

            var waitTime = _waitNumber == 1 ?  7 : Random.Range(2, 5);
            _wait.Start(TimeSpan.FromSeconds(waitTime));
            _actionState = ActionState.Stand;
        }

        void StartTurn()
        {
            _actionState = ActionState.Turn;
        }
    }
}