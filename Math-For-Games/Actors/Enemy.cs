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
        public static int EnemyCount;
        private float _timeBetweenShots;
        private float _cooldownTime;

        public Enemy(float x, float y, float speed, int health, Actor actor, float maxFov, float cooldownTime, string name = "Enemy", string path = "Sprites/cookie.png")
            : base(x, y, speed, health, name, path)
        {
            _actorToChase = actor;
            _maxFov = maxFov;
            EnemyCount++;
            Tag = ActorTag.ENEMY;
            _cooldownTime = cooldownTime;
        }

        public override void Update(float deltaTime)
        {
            Rotate(3 * deltaTime);

            base.Update(deltaTime);
        }

        public bool IsTargetInSight()
        {
            Vector2 directionOfTarget = (_actorToChase.LocalPosition - LocalPosition).Normalized;
            float distanceOfTarget = Vector2.GetDistance(_actorToChase.LocalPosition, LocalPosition);

            return (Math.Acos(Vector2.GetDotProduct(directionOfTarget, Forward)) * 180/Math.PI) < _maxFov
                && distanceOfTarget < 200;
        }

        public void TakeDamage()
        {
            Health--;
        }

        public override void OnCollision(Actor actor)
        { }

        public override void Draw()
        {
            base.Draw();
            //if (Collider != null)
                //Collider.Draw();
        }
    }
}
