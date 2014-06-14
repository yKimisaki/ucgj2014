using UnityEngine;
using System.Collections;

namespace AI
{
    public class Vision : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            var ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitObject = hit.transform.gameObject;
                if (hitObject == null)
                    return;

                var player = hitObject.GetComponent<Player>();
                if (player != null)
                {
                    // プレイヤーを見つけた処理
                }
                else
                {
                    // 他を見つけた処理
                }
            }
        }
    }
}