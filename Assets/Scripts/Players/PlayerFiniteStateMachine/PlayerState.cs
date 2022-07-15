using UnityEngine;

namespace Players.PlayerFiniteStateMachine
{
    public class PlayerState
    {
        protected Player player;
        protected Core.Core core;

        protected PlayerStateMachine stateMachine;
        protected float startTime;
        protected bool isExitingState;

        private string animBoolName;
        
        public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
            core = player.Core;
        }
        
        public virtual void Enter()
        {
            DoChecks();
            player.Anim.SetBool(animBoolName, true);
            startTime = Time.time;

            isExitingState = false;
        }

        public virtual void Exit()
        {
            player.Anim.SetBool(animBoolName, false);
            isExitingState = true;
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }
 
    }
}