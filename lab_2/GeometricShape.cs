using System;

namespace Lab_2_sem3
{
    public abstract class GeometricShape: IComparable
    {
        public virtual double CalculateShapeArea()
        {
            throw new Exception("Method not implemented");
        }

        public int CompareTo(object obj)
        {
            if (!obj.GetType().IsSubclassOf(typeof(GeometricShape)))
            {
                throw new Exception($"Value: {obj} of type: {obj.GetType()} not derived type GeometricShape");
            }
            var tmp = (GeometricShape)obj;
            var objArea = tmp.CalculateShapeArea();
            var curArea = CalculateShapeArea();
            if (objArea == curArea)
            {
                return 0;
            }
            if (objArea > curArea)
            {
                return -1;
            }
            return 1;
        }
    }
}
