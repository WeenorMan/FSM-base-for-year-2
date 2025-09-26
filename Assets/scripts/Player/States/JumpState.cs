using UnityEngine;
namespace Player
{
    public class JumpState : State
    {
        public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.CheckForIdle();
            Debug.Log("checking for idle");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}



