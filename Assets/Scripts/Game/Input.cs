using Modular;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    [AddComponentMenu("Modular/Game/Input")]
    public class Input : Attachment
    {
        public override string[] LinkedFloatNames => new[] { "Move" };
        public override string[] LinkedBoolNames => new[] { "Jump" };

        private float _move;
        private bool _jump;

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals("Move"))
                return _move;
            return base.LoadLinkedFloat(valueName);
        }

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals("Jump"))
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
    }
}
