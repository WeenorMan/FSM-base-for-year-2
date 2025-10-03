
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //idle animation start
        }

        public override void Exit()
        {
            base.Exit();

            //idle animation stop
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckForRun();
            CheckForJump();

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        bool CheckForRun()
        {
            if (player.GetHInput() <= -0.1f || player.GetHInput() >= 0.1f)
            {
                return true;

            }
            return false;
        }

        public void CheckForJump()
        {
            if (player.jumpButton && player.RayCollisionCheck(0, 0) == true)
            {
                sm.ChangeState(player.jumpState);
            }


        }
    }
}