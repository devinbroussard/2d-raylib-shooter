using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace Math_For_Games
{
    public enum ActorTag
    {
        PLAYER,
        ENEMY,
        BULLET,
        GENERIC
    }
    class Actor
    {
        private string _name;
        private bool _started;
        /// <summary>
        /// The forward facing direction of the actor
        /// </summary>
        private Vector2 _forward = new Vector2(0, 0);
        private ActorTag _tag;
        private Collider _collider;
        private Matrix3 _transform = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Sprite _sprite;

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

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
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

        public Actor(float x, float y, string name = "Actor", string path = "", ActorTag tag = ActorTag.GENERIC) :
            this(new Vector2 { X = x, Y = y }, name, path, tag)
        {
        }

        public Actor(Vector2 position, string name = "Actor", string path = "", ActorTag tag = ActorTag.GENERIC )
        {

            SetTranslation(position.X, position.Y);
            _name = name;
            Tag = tag;

            if (path != "")
                _sprite = new Sprite(path);
        }

        public Actor()
        { }

        public virtual void Start() 
        {
            _started = true;
        }

        public virtual void Update(float deltaTime) 
        {
            _transform = _translation * _rotation * _scale;
        }

        public virtual void Draw() 
        {
            //Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, 20, Color.WHITE);
            if (_sprite != null)
                _sprite.Draw(_transform);
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
        /// Sets the position of the actor
        /// </summary>
        /// <param name="translationX">The new x position</param>
        /// <param name="translationY">The new y position</param>
        public void SetTranslation(float translationX, float translationY)
        {
            _translation = Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Applies the given values to the current translation
        /// </summary>
        /// <param name="translationX">The amount to move the x</param>
        /// <param name="translationY">The amount to move the y</param>
        public void Translate(float translationX, float translationY)
        {
            _translation *= Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Set the rotation of the actor.
        /// </summary>
        /// <param name="radians">The angle of the rotation in radians.</param>
        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Adds a rotation to the current transform's rotation.
        /// </summary>
        /// <param name="radians"></param>
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Changes the scale of the actor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);
        }

        /// <summary>
        /// Scales the actor by the given amount.
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis</param>
        public void Scale(float x, float y)
        {
            _scale *= Matrix3.CreateScale(x, y);
        }

    }
}
