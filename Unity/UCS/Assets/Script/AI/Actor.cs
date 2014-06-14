using UnityEngine;
using System.Collections;

namespace AI
{
    [RequireComponent(typeof(Animator))]
    public class Actor : MonoBehaviour
    {
        public Animator Animator;

        void Start()
        {
            Animator = GetComponent<Animator>();
        }

        public void Stand(int waitNumber)
        {
            if (!Animator.GetCurrentAnimatorStateInfo(0).IsName("WAIT0" + waitNumber.ToString()))
                Animator.Play("WAIT0" + waitNumber.ToString());
        }

        public void LookAround()
        {
        }

        public void FindPlayer()
        {
        }

        public void Walk()
        {
            transform.position = transform.position + transform.forward * 0.03f;

            if (!Animator.GetCurrentAnimatorStateInfo(0).IsName("WALK00_F"))
                Animator.Play("WALK00_F");
        }

        public void Run()
        {
            transform.position = transform.position + transform.forward * 0.06f;

            if (!Animator.GetCurrentAnimatorStateInfo(0).IsName("RUN00_F"))
                Animator.Play("RUN00_F");
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