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

    public enum ActorTag
    {
        PLAYER,
        ENEMY,
        BULLET,
        GENERIC
    }
    class Actor
    {
        private Icon _icon;
        private string _name;
        private bool _started;
        /// <summary>
        /// The forward facing direction of the actor
        /// </summary>
        private Vector2 _forward = new Vector2(1, 0);
        private ActorTag _tag;
        private Collider _collider;
        private Matrix3 _transform = Matrix3.Identity;

        //The collider attached to this actor
        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public ActorTag Tag
        {
            get { return _tag; }
            set { _tag = value; }
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
            get { return new Vector2(_transform.M02, _transform.M12); }
            set 
            {
                _transform.M02 = value.X;
                _transform.M12 = value.Y;
            }
        }

        public Icon Icon
        {
            get { return _icon; }
        }

        public Actor(char icon, float x, float y, Color color, string name = "Actor", ActorTag tag = ActorTag.GENERIC) :
            this(icon, new Vector2 { X = x, Y = y }, color, name, tag)
        {
        }

        public Actor(char icon, Vector2 position, Color color, string name = "Actor", ActorTag tag = ActorTag.GENERIC)
        {
            _icon = new Icon { Symbol = icon, Color = color};
            Position = position;
            _name = name;
            Tag = tag;
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
            Raylib.DrawText(Icon.Symbol.ToString(), (int)Position.X - 9, (int)Position.Y - 14, 30, Icon.Color);
            //Circle hitbox vision
            //Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, 20, Color.WHITE);

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
            //Return false if either actor doesn't have a collider
            if (Collider == null || other.Collider == null)
                return false;

            return Collider.CheckCollision(other);
        }

        /// <summary>
        /// Changes the scale of the actor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScale(float x, float y)
        {
            _transform.M00 = x;
            _transform.M11 = y;
        }
    }
}
