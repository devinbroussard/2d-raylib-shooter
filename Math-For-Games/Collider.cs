using System;
using System.Collections.Generic;
using System.Text;

namespace Math_For_Games
{
    enum ColliderType
    {
        CIRCLE,
        AABB
    }

    abstract class Collider
    {
        //Actor that the collider is attached to
        private Actor _owner;
        private ColliderType _colliderType;

        public Actor Owner 
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public ColliderType ColliderType
        {
            get { return ColliderType; }
        }

        public Collider(Actor owner, ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = colliderType;
        }

        public bool CheckCollision(Actor other)
        {
            if (other.Collider.ColliderType == ColliderType.CIRCLE)
            {
                return CheckCollisionCircle((CircleCollider)other.Collider);
            }

            return false;
        }

        public virtual bool CheckCollisionCircle(CircleCollider other)
        { return false; }

        //public virtual bool CheckCollisionAABB(AABB other)
        //{ return false; }
    }
}
