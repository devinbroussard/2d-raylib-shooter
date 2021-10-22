using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace Math_For_Games
{
    class Enemy : Character
    {
        private Actor _actorToChase;
        private float _maxFov;
        private static int _enemyCount;

        public Enemy(char icon, float x, float y, Color color, float speed, int health, Actor actor, float maxFov, Vector2 forward, float collisionRadius = 20, string name = "Enemy")
            : base(icon, x, y, color, speed, health, name, collisionRadius)
        {
            _actorToChase = actor;
            _maxFov = maxFov;
            _enemyCount++;
            Forward = forward;
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

            return (Math.Acos(Vector2.GetDotProduct(directionOfTarget, Forward)) * 180/Math.PI) < _maxFov
                && distanceOfTarget < 200;
        }

        private void TakeDamage()
        {
            Health--;
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Bullet)
            {
                if (Health > 0)
                    TakeDamage();
                if (Health == 0)
                {
                    if (_enemyCount == 0)
                    {
                        UIText winText = new UIText(500, 500, "Win Text", Color.WHITE, 200, 200, 50, "You won!");
                        Engine.CurrentScene.AddActor(winText);
                    }
                    DestroySelf();
                }
                actor.DestroySelf();
            }
        }
    }
}
