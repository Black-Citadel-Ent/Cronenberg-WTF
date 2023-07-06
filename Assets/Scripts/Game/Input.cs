using Modular;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    [AddComponentMenu("Modular/Game/Input")]
    public class Input : Attachment
    {
        public override string[] LinkedFloatNames => new[] { "Move", "Down" };
        public override string[] LinkedBoolNames => new[] { "Jump" };

        private float _move;
        private float _down;
        private bool _jump;

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return _move;
            if (valueName.Equals(LinkedFloatNames[1]))
                return _down;
            return base.LoadLinkedFloat(valueName);
        }

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return _jump;
            return base.LoadLinkedBool(valueName);
        }

        private void OnMove(InputValue value)
        {
            _move = value.Get<float>();
        }

        private void OnJump(InputValue value)
        {
            _jump = !value.Get<float>().NearZero();
        }

        private void OnVertical(InputValue value)
        {
            _down = Mathf.Min(value.Get<float>(), 0);
        }
    }
}
