using UnityEngine;
using System.Collections;

namespace AI
{
    public class Actor : MonoBehaviour
    {
        public Animation Animation;

        public void Stand()
        {
            Debug.Log("とまります");
        }

        public void LookAround()
        {
        }

        public void FindPlayer()
        {
        }

        public void Walk()
        {
            Debug.Log("歩きます");
        }

        public void Run()
        {
        }

        public void FollowPlayer(Player player)
        {
        }

        public void Turn(float angle)
        { 
        }

        public void Hit()
        {
        }
    }
}