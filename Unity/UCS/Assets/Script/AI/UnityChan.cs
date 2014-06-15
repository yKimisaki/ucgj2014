using UnityEngine;
using System.Collections;

namespace AI
{
    [RequireComponent(typeof(Vision))]
    [RequireComponent(typeof(ActionSelector))]
    [RequireComponent(typeof(NearWall))]
    public class UnityChan : MonoBehaviour
    {
        private Vision _vision;
        private ActionSelector _actionSelector;
        private NearWall _nearWall;

        // Use this for initialization
        void Start()
        {
            _vision = GetComponent<Vision>();
            _actionSelector = GetComponent<ActionSelector>();
            _nearWall = GetComponent<NearWall>();

            _nearWall.OnNearWall += _actionSelector.OnNearWall;
            _vision.OnFindPlayer += _actionSelector.OnFindPlayer;
            _nearWall.OnHungPlayer += GameOver;
            _nearWall.OnHungPlayer += _actionSelector.LastMotion;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void GameOver()
        {
            Debug.Log("GAME OVER");
			Application.LoadLevel("gameover");
        }
    }
}