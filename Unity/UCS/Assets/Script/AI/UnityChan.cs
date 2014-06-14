using UnityEngine;
using System.Collections;

namespace AI
{
    [RequireComponent(typeof(Vision))]
    [RequireComponent(typeof(ActionSelector))]
    public class UnityChan : MonoBehaviour
    {
        private Vision _vision;
        private ActionSelector _actionSelector;

        // Use this for initialization
        void Start()
        {
            _vision = GetComponent<Vision>();
            _actionSelector = GetComponent<ActionSelector>();

            _vision.OnFindObject += _actionSelector.OnNearWall;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}