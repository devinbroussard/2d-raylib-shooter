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
        private Vector2 _position;
        private bool _started;
        /// <summary>
        /// The forward facing direction of the actor
        /// </summary>
        private Vector2 _forward = new Vector2(1, 0);
        private float _collisionRadius;
        private ActorTag _tag;
        private Collider _collider;

        //The collider attached to this actor
        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public ActorTag Tag
        {
            get { return Tag; }
            set { _tag = value; }
        }
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

        public Actor(char icon, float x, float y, Color color, string name = "Actor", float collisionRadius = 0, ActorTag tag = ActorTag.GENERIC) :
            this(icon, new Vector2 { X = x, Y = y }, color, name, collisionRadius, tag)
        {
        }

        public Actor(char icon, Vector2 position, Color color, string name = "Actor", float collisionRadius = 0, ActorTag tag = ActorTag.GENERIC)
        {
            _icon = new Icon { Symbol = icon, Color = color};
            _position = position;
            _name = name;
            _collisionRadius = collisionRadius;
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
            Raylib.DrawText(Icon.Symbol.ToString(), (int)Position.X - 8, (int)Position.Y - 15, 30, Icon.Color);
            //To see hitbox:
            //Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, _collisionRadius, Icon.Color);

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
    }
}
