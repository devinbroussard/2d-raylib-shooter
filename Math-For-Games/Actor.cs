using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace Math_For_Games
{
    struct Icon
    {
        public char Symbol;
        public Color Color;
    }

    class Actor
    {
        private Icon _icon;
        private string _name;
        private Vector2 _position;
        private bool _started;
        /// <summary>
        /// The forward facing direction of the actor
        /// </summary>
        private Vector2 _forward = new Vector2(1, 0);
        private float _collisionRadius;

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }
        }

        public Vector2 Forward
        {
            get { return _forward; }
            set { _forward = value; }
        }
        
        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started
        {
            get { return _started; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Icon Icon
        {
            get { return _icon; }
        }

        public Actor(char icon, float x, float y, Color color, string name = "Actor", float collisionRadius = 0) :
            this(icon, new Vector2 { X = x, Y = y }, color, name)
        {
        }

        public Actor(char icon, Vector2 position, Color color, string name = "Actor", float collisionRadius = 0)
        {
            _icon = new Icon { Symbol = icon, Color = color};
            _position = position;
            _name = name;
            _collisionRadius = collisionRadius;
        }

        public Actor()
        { }

        public virtual void Start() 
        {
            _started = true;
        }

        public virtual void Update(float deltaTime) 
        {
        }

        public virtual void Draw() 
        {
            Raylib.DrawText(Icon.Symbol.ToString(), (int)Position.X, (int)Position.Y, 20, Icon.Color);
        }

        public virtual void End()
        { }

        public void DestroySelf()
        {
            Engine.CurrentScene.RemoveActor(this);
        }

        public virtual void OnCollision(Actor actor)
        {

        }

        /// <summary>
        /// Checks if this actor collided with another actor
        /// </summary>
        /// <param name="other"The actor to check for a collision against></param>
        /// <returns>True if a collision has occured</returns>
        public virtual bool CheckForCollision(Actor other)
        {
            float combinedRadii = other.CollisionRadius + CollisionRadius;
            float distance = Vector2.GetDistance(Position, other.Position);

            return distance <= combinedRadii;
        }
    }
}
