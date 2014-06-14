using UnityEngine;
using System;
using System.Collections;
using Debug = UnityEngine.Debug;

namespace AI
{
    public class Vision : MonoBehaviour
    {
        public event Action OnFindPlayer;
        public event Action OnFindObject;

        private enum LookState { Player, Object, None };
        private LookState _lookState;

        // Update is called once per frame
        void Update()
        {
            var ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitObject = hit.transform.gameObject;

                var player = hitObject.GetComponent<Player>();
                if (player != null && _lookState != LookState.Player)
                {
                    if ((hitObject.transform.position - transform.position).sqrMagnitude > 30)
                    {
                        Miss();
                        return;
                    }

                    FindPlayer();
                }
                else if (_lookState != LookState.Object)
                {
                    if ((hitObject.transform.position - transform.position).sqrMagnitude > 10)
                    {
                        Miss();
                        return;
                    }

                    FindObject();
                }
                else
                {
                    Miss();
                }
            }
        }

        void FindObject()
        {
            _lookState = LookState.Object;
            if (OnFindObject != null)
                OnFindObject();
        }

        void FindPlayer()
        {
            _lookState = LookState.Player;
            if (OnFindPlayer != null)
                OnFindPlayer();
        }

        void Miss()
        {
            _lookState = LookState.None;
        }
    }
}