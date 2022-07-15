using Players.PlayerFiniteStateMachine;
using Players.PlayerStates.SuperStates;

namespace Players.PlayerStates.SubStates
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int amountOfJumpsLeft;

        public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }

        public override void Enter() {
            base.Enter();
            player.UseJumpInput();
            Movement.SetVelocityY(player.jumpVelocity);
            isAbilityDone = true;
            amountOfJumpsLeft--;
        }

        public bool CanJump() {
            if (amountOfJumpsLeft > 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}