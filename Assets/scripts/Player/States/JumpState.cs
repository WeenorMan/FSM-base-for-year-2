using Unity.Android.Gradle.Manifest;
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
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, 0);
            player.rb.AddForce(Vector2.up * player.jumpPower, ForceMode2D.Impulse);


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
            DoVariableJump();
            
            //player.CheckForIdle();

            //check for hitting platform or ground
            Debug.Log("checking for idle");
            
            if(player.rb.linearVelocity.y == 0 && player.RayCollisionCheck(0, 0))
            {
                sm.ChangeState(player.idleState);
            }
            

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        void DoVariableJump()
        {
            Vector2 vel;

            vel = Vector2.up* Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;

            Debug.Log("vel.y=" + vel.y);

            if( player.jumpButton )
            {
                if( player.rb.linearVelocity.y > 1 )
                {
                    player.rb.linearVelocity += -vel;
                }
            }

           
        }
    }
}



