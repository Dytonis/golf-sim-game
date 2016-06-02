using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Engine.Phys
{
    public class PhysObject : MonoBehaviour
    {
        public Vector3 Velocity;
        public bool PhysEnabled;

        public bool FreezeTranslationX;
        public bool FreezeTranslationY;
        public bool FreezeTranslationZ;

        // Update is called once per frame
        void Update()
        {
            Vector3 translate = new Vector3(FreezeTranslationX ? 0 : Velocity.x, FreezeTranslationY ? 0 : Velocity.y, FreezeTranslationZ ? 0 : Velocity.z);

            if (PhysEnabled)
                transform.Translate(translate * Time.deltaTime);
        }

        public void AddVelocity(float x, float y, float z)
        {
            Velocity += new Vector3(x, y, z);
        }
    }
}
