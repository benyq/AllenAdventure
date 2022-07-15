using Players.PlayerFiniteStateMachine;
using Players.PlayerStates.SuperStates;

namespace Players.PlayerStates.SubStates
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement.CheckIfShouldFlip(xInput);
            Movement.SetVelocityX(player.movementVelocity * xInput);
            
            if (!isExitingState) {
                if (xInput == 0)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
            }
        }
    }
}