using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public PlayerControls playerControls;

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpState jumpState;

        public StateMachine sm;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            jumpState = new JumpState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        void OnEnable()
        {
            playerControls.Enable();
        }

        void OnDisable()
        {
            playerControls.Disable();
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press I for idle / R for run");

        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public void CheckForRun()
        {
            if (playerControls.States.RunningState.triggered)
            {
                sm.ChangeState(runningState);
                return;
            }

        }


        public void CheckForIdle()
        {
            if (Input.GetKey("i") ) // key held down
            {
                sm.ChangeState(idleState);
            }

        }





    }

}