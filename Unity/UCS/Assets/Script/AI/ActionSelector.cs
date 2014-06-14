using UnityEngine;
using System.Collections;

namespace AI
{
    [RequireComponent(typeof(Actor))]
    public class ActionSelector : MonoBehaviour
    {
        private Actor _actor;

        enum ActionState { }

        void Start()
        {
            _actor = GetComponent<Actor>();
        }

        void Update()
        {
        }
    }
}