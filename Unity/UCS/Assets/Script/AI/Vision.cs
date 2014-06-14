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
                if (hitObject == null)
                {
                    _lookState = LookState.None;
                    return;
                }

                var player = hitObject.GetComponent<Player>();
                if (player != null)
                {
                    if (_lookState != LookState.Player)
                    {
                        // プレイヤーを見つけた処理
                        Debug.Log("Player found.");
                        _lookState = LookState.Player;
                        if (OnFindPlayer != null)
                            OnFindPlayer();
                    }
                }
                else
                {
                    if (_lookState != LookState.Object)
                    {
                        // 他を見つけた処理
                        Debug.Log("Other found.");
                        _lookState = LookState.Object;
                        if (OnFindObject != null)
                            OnFindObject();
                    }
                }
            }
        }
    }
}