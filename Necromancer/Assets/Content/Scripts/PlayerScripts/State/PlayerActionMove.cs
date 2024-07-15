using UnityEngine;

namespace Content.Scripts.PlayerScripts.State
{
    public class PlayerActionMove : PlayerActionBase
    {
        private Camera _camera;

        public override void StartState()
        {
            base.StartState();
            if (_camera == null)
            {
                _camera = Camera.main;
            }
        }

        public override void ProcessState()
        {
            Machine.PlayerMovement.MyInput();
            Machine.PlayerAnimator.UpdateDirectional(Machine.PlayerMovement.Direction);
            Machine.PlayerMovement.Rotate();
            Machine.PlayerMovement.Movement();
            Machine.PlayerFollow.UpdatePointMove();
            
            Machine.PlayerArmy.TryCaptureUnit();
        }
        
        

        public override void EndState()
        {
            base.EndState();
        }
    }
}
