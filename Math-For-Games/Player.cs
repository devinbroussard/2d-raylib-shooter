using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;
using System.Diagnostics;

namespace Math_For_Games
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        public Scene _scene;
        Stopwatch _stopwatch = new Stopwatch();
        private float _lastTime;
        private float _cooldownTime;

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

        public Player(char icon, float x, float y, float speed, Color color, float collisionRadius, Scene scene, float cooldownTime, string name = "actor")
            : base(icon, x, y, color)
        {
            _speed = speed;
            CollisionRadius = collisionRadius;
            _cooldownTime = cooldownTime;
            _scene = scene;
        }

        public override void Start()
        {
            base.Start();
            _stopwatch.Start();
        }

        public override void Update(float deltaTime)
        {
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

            float currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

            if ((xDirectionForBullet != 0 || yDirectionForBullet != 0) && (currentTime >= _lastTime + 0.3 || _lastTime == 0))
            {
                _lastTime = currentTime;
                bullet = new Bullet('o', Position, Color.GOLD, 2000, "Player Bullet", xDirectionForBullet, yDirectionForBullet);
                _scene.AddActor(bullet);
            }

            Velocity = moveDirection.Normalized * Speed * deltaTime;
            Position += Velocity;
        }

        public override void Draw()
        {
            base.Draw();

        }

        public override void OnCollision(Actor actor)
        {
           
        }
    }
}
