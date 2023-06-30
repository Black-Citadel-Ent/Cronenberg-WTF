using UnityEngine;

namespace Modular.Math
{
    [AddComponentMenu("Modular/Math/Float Comparison")]
    public class FloatCompare : Attachment
    {
        [SerializeField] private FloatLink value1;
        [SerializeField] private FloatLink value2;

        public override string[] LinkedFloatNames => new[] { "Lowest", "Highest" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals("Lowest"))
                return Mathf.Min(value1.FloatValue, value2.FloatValue);
            if (valueName.Equals("Highest"))
                return Mathf.Max(value1.FloatValue, value2.FloatValue);
            return base.LoadLinkedFloat(valueName);
        }
    }
}
