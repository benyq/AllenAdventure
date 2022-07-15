using System;
using UnityEngine;

namespace Players.Core
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D RB { get; private set; }
        public int FacingDirection { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }
        
        private Vector2 workspace;

        protected override void Awake()
        {
            base.Awake();
            RB = GetComponentInParent<Rigidbody2D>();
            
            FacingDirection = 1;
        }

        private void Update()
        {
            CurrentVelocity = RB.velocity;
        }

        public void SetVelocityX(float velocity)
        {
            workspace.Set(velocity, CurrentVelocity.y);
            RB.velocity = workspace;
        }
        
        public void SetVelocityY(float velocity)
        {
            RB.velocity = new Vector2(RB.velocity.x, velocity);
        }
        
        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
            {
                Flip();
            }
        }
        
        public void Flip()
        {
            FacingDirection *= -1;
            RB.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
}