using UnityEngine;
using System.Collections;
using System;
using Debug = UnityEngine.Debug;

namespace AI
{
    public class NearWall : MonoBehaviour
    {
        public event Action OnNearWall;

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("pipo");
            if (other.gameObject.GetComponent<Player>() != null)
                return;

            if (OnNearWall != null)
                OnNearWall();
        }
    }
}