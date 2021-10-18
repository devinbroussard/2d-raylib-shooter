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
        private Player _playerToChase;

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

        public Enemy(char icon, float x, float y, float speed, Color color, Player player, string name = "actor")
            : base(icon, x, y, color)
        {
            _speed = speed;
            _playerToChase = player;
        }

        public override void Update(float deltaTime)
        {

            Vector2 moveDirection = _playerToChase.Position;

            Velocity = moveDirection.Normalized * Speed * deltaTime;
            Position += Velocity;
        }

        public override void Draw()
        {
            base.Draw();

        }

        public override void OnCollision(Actor actor)
        {
            Engine.CloseApplication();
        }
    }
}
