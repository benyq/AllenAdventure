using System;
using Players.PlayerStates;
using Players.PlayerStates.SubStates;
using UnityEngine;

namespace Players.PlayerFiniteStateMachine
{
    public class Player : MonoBehaviour
    {
        public Core.Core Core { get; private set; }
        public Animator Anim { get; private set; }
        public Rigidbody2D RB { get; private set; }


        public event EventHandler HeavyAttackEvent;
        public event EventHandler LightAttackEvent;
        
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState;
        public PlayerMoveState MoveState;
        public PlayerJumpState JumpState;
        public PlayerInAirState InAirState;
        
        
        public int XInput { get; private set; }
        public bool JumpInput { get; private set; }


        [SerializeField] public float movementVelocity;
        [SerializeField] public float jumpVelocity;
            
        private void Awake()
        {
            Core = GetComponentInChildren<Core.Core>();
            
            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, "move");
            JumpState = new PlayerJumpState(this, StateMachine, "inAir");
            InAirState = new PlayerInAirState(this, StateMachine, "inAir");
        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();
            
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            StateMachine.CurrentState.LogicUpdate();

            XInput = (int)Input.GetAxisRaw("Horizontal");
            
            if (Input.GetButtonDown("Jump"))
            {
                JumpInput = true;
            }
            
            if (Input.GetMouseButtonDown(0))//左键
            {
                LightAttackEvent?.Invoke(this, null);
            }
            if (Input.GetMouseButtonDown(1))//右键
            {
                HeavyAttackEvent?.Invoke(this, null);
            }
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        
        
        public void UseJumpInput() => JumpInput = false;

    }
}