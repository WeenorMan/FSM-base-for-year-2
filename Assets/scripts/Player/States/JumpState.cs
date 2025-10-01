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

            //jump animation start

            // set y velocity to a positive number
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
            
            //player.CheckForIdle();

            //check for hitting platform or ground
            Debug.Log("checking for idle");

            if(player.RayCollisionCheck(0, 0) == true )
            {
                player.CheckForJump();
                sm.ChangeState(player.jumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}



