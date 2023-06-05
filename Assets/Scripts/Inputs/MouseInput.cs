using UnityEngine;

namespace Inputs
{
    public class MouseInput : AbstractInput
    {
        [SerializeField] private float radius = 200;
        [Header("Debug")]
        [SerializeField] private Vector2 start;
        [SerializeField] private Vector2 current;
        [SerializeField] private Vector2 difference;


        public override Vector2 Axis()
        {
            if (Input.GetMouseButtonDown(0))
            {
                start = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                current = Input.mousePosition;
                difference = current - start;
                return Normalize(difference);
            }

            return Vector2.zero;
        }

        private Vector2 Normalize(Vector2 vector)
        {
            var applied = vector / radius;
            return new Vector2(
                Clamp(applied.x), Clamp(applied.y)
            );
        }

        private float Clamp(float value)
        {
            return Mathf.Clamp(value, -1, 1);
        }
    }
}