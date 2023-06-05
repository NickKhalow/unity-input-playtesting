using UnityEngine;

namespace Inputs
{
    public class KeyboardInput : AbstractInput
    {
        public override Vector2 Axis()
        {
            return new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            );
        }
    }
}