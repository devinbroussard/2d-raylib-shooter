using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;

namespace Math_For_Games
{
    class CircleCollider : Collider
    {
        private float _collisionRadius;

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }
        }

        public CircleCollider(float collisionRadius, Actor owner) 
            : base(owner, ColliderType.CIRCLE)
        {
            _collisionRadius = collisionRadius;
        }

        public override bool CheckCollisionCircle(CircleCollider other)
        {
            if (other.Owner == Owner)
                return false;

            //Gets the distance between the two collider owners
            float distance = Vector2.GetDistance(other.Owner.Position, Owner.Position);
            float combinedRadii = other.CollisionRadius + CollisionRadius;

            return distance <= combinedRadii;
        }
    }
}
