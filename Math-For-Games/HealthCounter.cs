using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using Math_Library;

namespace Math_For_Games
{
    class HealthCounter : UIText
    {
        private Enemy _enemy;

        public HealthCounter(float x, float y, string name, Color color, Enemy enemy)
            : base(x, y, name, color)
        {
            _enemy = enemy;
            Text = _enemy.Health.ToString();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (_enemy.Health != 0)
                Position = new Vector2(_enemy.Position.X, _enemy.Position.Y - 20);
            else
                Engine.CurrentScene.RemoveUIElement(this);
            Text = _enemy.Health.ToString();

        }
    }
}
