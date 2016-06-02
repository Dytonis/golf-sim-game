using UnityEngine;
using System.Collections;

namespace Assets.Scripts.CameraUtil
{
    [RequireComponent(typeof(Engine.Phys.PhysObject))]
    public class CameraMovement : MonoBehaviour
    {
        Engine.Phys.PhysObject physobj;
        public float Velocity;
        // Use this for initialization
        void Start()
        {
            physobj = GetComponent<Engine.Phys.PhysObject>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 normalizedMousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

            if (normalizedMousePosition.x < 0.01 || Input.GetAxisRaw("Horizontal") < 0)
                Left();
            if (normalizedMousePosition.x > 0.99 || Input.GetAxisRaw("Horizontal") > 0)
                Right();
            if (normalizedMousePosition.y < 0.01 || Input.GetAxisRaw("Vertical") < 0)
                Down();
            if (normalizedMousePosition.y > 0.99 || Input.GetAxisRaw("Vertical") > 0)
                Up();
        }

        private void Left()
        {
            physobj.AddVelocity(-Velocity, 0, 0);
        }
        private void Right()
        {
            physobj.AddVelocity(Velocity, 0, 0);
        }
        private void Up()
        {
            physobj.AddVelocity(0, 0, Velocity);
        }
        private void Down()
        {
            physobj.AddVelocity(0, 0, -Velocity);
        }
    }
}
