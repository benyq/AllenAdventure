using Players.PlayerFiniteStateMachine;
using Players.PlayerStates.SuperStates;

namespace Players.PlayerStates.SubStates
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }


        public override void Enter()
        {
            base.Enter();
            Movement.SetVelocityX(0f);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState) {
                if (xInput != 0)
                {
                    stateMachine.ChangeState(player.MoveState);
                }
            }
        }

    }
}