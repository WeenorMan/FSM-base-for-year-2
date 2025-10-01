using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.InputSystem;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public PlayerControls playerControls;
        public LayerMask groundLayerMask;


        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpState jumpState;

        public StateMachine sm;
        
        //inputs
        float hInput;
        bool jumpButton;
        bool attackButton;

        [Header("General Player Settings")]
        [SerializeField] float speed;
        [SerializeField] float jumpPower;

        [Header("Jump Tuning")]
        [SerializeField] float fallMultiplier = 2.5f;
        [SerializeField] float lowJumpMultiplier = 2f;


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
            rb.linearVelocity = new Vector2(hInput * speed, rb.linearVelocity.y);


        }

        public void HorizInput(InputAction.CallbackContext ctx)
        {
            hInput = ctx.ReadValue<Vector2>().x;
        }

        public void JumpInput(InputAction.CallbackContext ctx)
        {
            if (ctx.performed && RayCollisionCheck(0,0) == true)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                sm.ChangeState(jumpState);
                print("player has jumped");
            }

            if (ctx.canceled && rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0 * fallMultiplier - 1 * Time.deltaTime);
            }
        }


        public void CheckForIdle()
        {
             sm.ChangeState(idleState);
        }

        public bool RayCollisionCheck(float xoffs, float yoffs)
        {
            float rayLength = 0.5f; // length of raycast
            bool hitSomething = false;

            // convert x and y offset into a Vector3 
            Vector3 offset = new Vector3(xoffs, yoffs, 0);

            //cast a ray downward starting at the sprite's position
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);

            Color hitColor = Color.red;


            if (hit.collider != null)
            {
                print("Player has collided with Ground layer");
                hitColor = Color.green;
                hitSomething = true;
            }
            // draw a debug ray to show ray's position
            // You need to enable gizmos in th e editor to see these
            Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
            return hitSomething;
        }


        public float GetHInput()
        {
            return hInput;
        }





    }

}