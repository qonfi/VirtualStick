//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;
using VirtualStick;

namespace VirtualStick
{
    public class VirtualStickTester : MonoBehaviour
    {
        // インターフェイスを通じてアクセスする設計だが、インターフェイスではインスペクタにスロットを表示できないので。
        [SerializeField] private VirtualStick stickL;
        [SerializeField] private VirtualStick stickR;

        private void Start()
        {
            Camera.main.transform.parent = this.transform;
            //Camera.main.transform.position = Vector3.zero;
        }

        private void Update()
        {
            transform.Translate(stickL.StickMovement.x, 0.00f, stickL.StickMovement.y);
            this.transform.Rotate(0.00f, stickR.StickMovement.x ,0.00f);
        }
    }
}