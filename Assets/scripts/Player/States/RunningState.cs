
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Player
{
    public class RunningState : State
    {
        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
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

            if (!player.playerControls.Ground.Move.triggered)
            {
                player.CheckForIdle();
            }

            
            Debug.Log("checking for idle");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}