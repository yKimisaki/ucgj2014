using UnityEngine;
using System.Collections;
using System;
using Debug = UnityEngine.Debug;

namespace AI
{
    public class NearWall : MonoBehaviour
    {
        public event Action<Vector3> OnNearWall;
        public event Action OnHungPlayer;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                if (OnHungPlayer != null)
                    OnHungPlayer();
                return;
            }

            var normal = other.transform.forward;
            if (OnNearWall != null)
                OnNearWall(normal);
        }
    }
}