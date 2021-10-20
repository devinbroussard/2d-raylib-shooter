using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace Math_For_Games
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Actor _actorToChase;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Enemy(char icon, float x, float y, float speed, Color color, Actor actor, string name = "actor")
            : base(icon, x, y, color)
        {
            _speed = speed;
            _actorToChase = actor;
        }

        public override void Update(float deltaTime)
        {
            //The Enemy runs towards the player's position
            Vector2 moveDirection = _actorToChase.Position - Position;

            //The enemy runs away from the player's position
            //Vector2 moveDirection = Position - _actorToChase.Position;

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            if(IsTargetInSight())
                Position += Velocity;

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public bool IsTargetInSight()
        {
            Vector2 directionOfTarget = (_actorToChase.Position - Position).Normalized;
            float distanceOfTarget = Vector2.GetDistance(_actorToChase.Position, Position);

            return (Math.Acos(Vector2.GetDotProduct(directionOfTarget, Forward)) * 180/Math.PI) < 75 && distanceOfTarget < 200;
        }

        public override void OnCollision(Actor actor)
        {
            Engine.CloseApplication();
        }
    }
}
