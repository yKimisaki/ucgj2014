using UnityEngine;
using System.Collections;

namespace AI
{
    public class Actor : MonoBehaviour
    {
        public Animation Animation;

        public void Stand()
        {
        }

        public void LookAround()
        {
        }

        public void FindPlayer()
        {
        }

        public void Walk()
        {
            transform.position = transform.position + transform.forward * 0.05f;
        }

        public void Run()
        {
        }

        public void FollowPlayer(Player player)
        {
        }

        public void Turn(float angle)
        {
            transform.Rotate(Vector3.up, angle);
        }

        public void Hit()
        {
        }
    }
}