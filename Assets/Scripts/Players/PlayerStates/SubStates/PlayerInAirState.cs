using Players.Core;
using Players.PlayerFiniteStateMachine;
using UnityEngine;

namespace Players.PlayerStates.SubStates
{
    public class PlayerInAirState : PlayerState
    {
        
        protected Movement Movement { get => movement ? movement : core.GetCoreComponent(ref movement); }
        private Movement movement;
        
        private CollisionSenses CollisionSenses { get => collisionSenses ? collisionSenses : core.GetCoreComponent(ref collisionSenses); }
        private CollisionSenses collisionSenses;
        
        private bool isGrounded;
        
        public PlayerInAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                if (isGrounded && Movement.CurrentVelocity.y < 0.01f)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
            }


            player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));

        }

        public override void DoChecks()
        {
            base.DoChecks();
            isGrounded = CollisionSenses.Ground;
        }
    }
}