using System;

namespace Lab_2_sem3
{
    public abstract class GeometricShape
    {
        public virtual double CalculateShapeArea()
        {
            throw new Exception("Method not implemented");
        }        
    }
}
