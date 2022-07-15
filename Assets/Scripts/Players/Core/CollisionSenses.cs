using UnityEngine;

namespace Players.Core
{
    public class CollisionSenses : CoreComponent
    {
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask whatIsGround;
        
        public Transform GroundCheck {
            get => TryGet(groundCheck, core.transform.parent.name);
            private set => groundCheck = value;
        }
        
        public bool Ground {
            get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
        }

        
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(GroundCheck.position, groundCheckRadius);
        }
    }
}