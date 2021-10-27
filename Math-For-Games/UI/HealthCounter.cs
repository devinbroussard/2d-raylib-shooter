using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using Math_Library;

namespace Math_For_Games
{
    class HealthCounter : UIText
    {
        private Character _character;

        public HealthCounter(float x, float y, string name, Color color, Character character)
            : base(x, y, name, color)
        {
            _character = character;
            Text = _character.Health.ToString();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (_character.Health >= 0)
            {
                Position = new Vector2(_character.Position.X - 10, _character.Position.Y - 25);
                Text = _character.Health.ToString();
            }
            else
                Engine.CurrentScene.RemoveUIElement(this);
        }
    }
}
