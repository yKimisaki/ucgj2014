using UnityEngine;
using System;
using System.Collections;
using Debug = UnityEngine.Debug;

namespace AI
{
    public class Vision : MonoBehaviour
    {
        public event Action<Player> OnFindPlayer;

        private enum LookState { Player, None };
        private LookState _lookState;

        // Update is called once per frame
        void Update()
        {
            var ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitObject = hit.transform.gameObject;
                Debug.Log(hitObject);

                var player = hitObject.GetComponent<Player>();
                if (player != null && _lookState != LookState.Player)
                {

                    if ((hitObject.transform.position - transform.position).sqrMagnitude > 30)
                    {
                        Miss();
                        return;
                    }

                    FindPlayer(player);
                    return;
                }
            }

            Miss();
        }

        void FindPlayer(Player player)
        {
            _lookState = LookState.Player;
            if (OnFindPlayer != null)
                OnFindPlayer(player);
        }

        void Miss()
        {
            _lookState = LookState.None;
        }
    }
}