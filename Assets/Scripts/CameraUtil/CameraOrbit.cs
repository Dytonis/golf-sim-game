using UnityEngine;
using System.Collections;

namespace Assets.Scripts.CameraUtil
{
    [RequireComponent(typeof(Engine.Phys.PhysObject))]
    public class CameraOrbit : MonoBehaviour
    {
        public GameObject Camera;
        public GameObject Rotator;

        public void Update()
        {
            if(Input.GetMouseButton(1))
            {
                Rotator.transform.eulerAngles += new Vector3(-Input.GetAxisRaw("Mouse Y"), 0, 0);
                transform.eulerAngles += new Vector3(0, Input.GetAxisRaw("Mouse X"), 0);
            }

            Camera.transform.position += Camera.transform.forward * Input.mouseScrollDelta.y;
        }
    }
}
