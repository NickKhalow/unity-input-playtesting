using Constructors;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inputs
{
    public class ConstInput : AbstractInput, IConstructable<Vector2>
    {
        [SerializeField] private Vector2 axis = Vector2.zero;

        public override Vector2 Axis()
        {
            return axis;
        }

        public void Construct(Vector2 value)
        {
            axis = value;
        }
    }
}