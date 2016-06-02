using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Engine.Phys
{
    [RequireComponent(typeof(PhysObject))]
    public class Damping : Phys
    {
        public PhysObject obj;

        public Vector3 DampingValue;
        public PhysDampingStyle DampingStyle;

        public bool FreezeDampingX;
        public bool FreezeDampingY;
        public bool FreezeDampingZ;


        void Start()
        {
            obj = GetComponent<PhysObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if(PhysEnabled)
            {
                Vector3 damp = new Vector3(FreezeDampingX ? 0 : DampingValue.x, FreezeDampingY ? 0 : DampingValue.y, FreezeDampingZ ? 0 : DampingValue.z);

                if(DampingStyle == PhysDampingStyle.Linear)
                    obj.Velocity -= damp;
                else if(DampingStyle == PhysDampingStyle.Smooth)
                {
                    Vector3 adjust = new Vector3(
                        obj.Velocity.x / ((damp.x * 0.5f) + 1),
                        obj.Velocity.x / ((damp.y * 0.5f) + 1),
                        obj.Velocity.z / ((damp.z * 0.5f) + 1)
                        );

                    obj.Velocity = adjust;
                }
            }
        }
    }

    public enum PhysDampingStyle
    {
        Linear,
        Smooth
    }
}
