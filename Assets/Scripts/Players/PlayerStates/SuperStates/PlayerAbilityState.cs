using System.Collections;
using System.Collections.Generic;
using Players.Core;
using Players.PlayerFiniteStateMachine;
using UnityEngine;

namespace Players.PlayerStates.SuperStates
{
    public class PlayerAbilityState : PlayerState {
        protected bool isAbilityDone;

        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

        private Movement movement;
        private CollisionSenses collisionSenses;

        private bool isGrounded;

        public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) {
        }

        public override void DoChecks() {
            base.DoChecks();

            if (CollisionSenses) {
                isGrounded = CollisionSenses.Ground;
            }
        }

        public override void Enter() {
            base.Enter();

            isAbilityDone = false;
        }

        public override void Exit() {
            base.Exit();
        }

        public override void LogicUpdate() {
            base.LogicUpdate();

            if (isAbilityDone) {
                if (isGrounded && Movement.CurrentVelocity.y < 0.01f) {
                    stateMachine.ChangeState(player.IdleState);
                } else {
                    stateMachine.ChangeState(player.InAirState);
                }
            }
        }

        public override void PhysicsUpdate() {
            base.PhysicsUpdate();
        }
    }

}