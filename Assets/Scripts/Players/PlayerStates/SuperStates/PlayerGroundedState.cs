using Players.Core;
using Players.PlayerFiniteStateMachine;
using UnityEngine;

namespace Players.PlayerStates.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected int xInput;
        protected int yInput;
        
        protected Movement Movement { get => movement ? movement : core.GetCoreComponent(ref movement); }
        private Movement movement;
        
        private CollisionSenses CollisionSenses { get => collisionSenses ? collisionSenses : core.GetCoreComponent(ref collisionSenses); }
        private CollisionSenses collisionSenses;
        
        private bool isGrounded;
        
        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
            player.HeavyAttackEvent += (sender, args) =>
            {
                Debug.Log("蓄力一击");
            };

            player.LightAttackEvent += (sender, args) =>
            {
                Debug.Log("摸一下");
            };
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            xInput = player.XInput;

            if (player.JumpInput)
            {
                player.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }else if (!isGrounded) {
                stateMachine.ChangeState(player.InAirState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isGrounded = CollisionSenses.Ground;
            
            Debug.Log("isGrounded: " + isGrounded);
        }

    }
}