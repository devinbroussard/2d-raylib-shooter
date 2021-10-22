using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace Math_For_Games
{
    class Player : Character
    {
        private float _timeBetweenShots;
        private float _cooldownTime;

        public Player(char icon, float x, float y, float speed, Color color, float collisionRadius, float cooldownTime, string name = "actor")
            : base(icon, x, y, color)
        {
            _speed = speed;
            CollisionRadius = collisionRadius;
            _cooldownTime = cooldownTime;
        }

        public override void Update(float deltaTime)
        {
            //Adds deltaTime to time between shots
            _timeBetweenShots += deltaTime;

            //Gets the xDirection and yDirection of the players input
            int xDireciton = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            Vector2 moveDirection = new Vector2(xDireciton, yDirection);

            int xDirectionForBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
           + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT));
            int yDirectionForBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));

            Bullet bullet;

            if ((xDirectionForBullet != 0 || yDirectionForBullet != 0) && (_timeBetweenShots >=  _cooldownTime))
            {
                _timeBetweenShots = deltaTime;
                bullet = new Bullet('o', Position, Color.GOLD, 2000, "Player Bullet", xDirectionForBullet, yDirectionForBullet);
                Engine.CurrentScene.AddActor(bullet);
            }

            Velocity = moveDirection.Normalized * Speed * deltaTime;
            Position += Velocity;
        }

        public override void OnCollision(Actor actor)
        {
           
        }
    }
}
