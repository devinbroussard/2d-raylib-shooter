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
        private float _lastHitTime;

        public Player(char icon, float x, float y, Color color, float speed, int health, float cooldownTime, float collisionRadius = 20, string name = "Player")
            : base(icon, x, y, color, speed, health, name, collisionRadius)
        {
            Speed = speed;
            _cooldownTime = cooldownTime;
        }

        public override void Update(float deltaTime)
        {
            _lastHitTime += deltaTime;
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
                bullet = new Bullet('.', Position, Color.GOLD, 2000, "Player Bullet", xDirectionForBullet, yDirectionForBullet);
                Engine.CurrentScene.AddActor(bullet);
            }

            Velocity = moveDirection.Normalized * Speed * deltaTime;
            Position += Velocity;
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
            {
                if (Health > 0 && _lastHitTime > 3)
                {
                    _lastHitTime = 0;
                    Health--;
                }
                if (Health <= 0)
                {
                    UIText deathText = new UIText(500, 500, "Death Text", Color.WHITE, 200, 200, 50, "You died!");
                    Engine.CurrentScene.AddActor(deathText);
                }
            }
        }
    }
}
