using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Library
{
    public struct Matrix3
    {
        public float M00, M01, M02, M10, M11, M12, M20, M21, M22;

        public Matrix3(
            float m00, float m01, float m02,
            float m10, float m11, float m12,
            float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        /// <summary>
        /// Varaible created to store an identity matrix.
        /// Made static so that it can be accessed easily.
        /// </summary>
        public static Matrix3 Identity
        {
            get {
                //returns a new identity matrix
                return new Matrix3(
                    1, 0, 0,
                    0, 1, 0,
                    0, 0, 1);
                 }
        }

        /// <summary>
        /// Creates a new matrix that has been rotated by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix3 CreateRotation(float radians)
        {

        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="translation">The position of the new matrix</param>
        public static Matrix3 CreateTranslation(float x, float y)
        {

        }

        /// <summary>
        /// Creates a new matrix that has been scaled by the given value
        /// </summary>
        /// <param name="scale">The result of the scale</param>
        public static Matrix3 CreateScale(float x, float y)
        {

        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {

        }

        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {

        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            Matrix3 result = new Matrix3(
                ((lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20)),
                ((lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21)),
                ((lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22)),
                ((lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20)),
        }
    }
}
