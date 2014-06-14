using UnityEngine;
using System.Collections;
using System;
using Debug = UnityEngine.Debug;

namespace AI
{
    public class NearWall : MonoBehaviour
    {
        public event Action<Vector3> OnNearWall;

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("pipo");

            if (other.gameObject.GetComponent<Player>() != null)
                return;

            var normal = other.transform.forward;
            if (OnNearWall != null)
                OnNearWall(normal);
        }
    }
}