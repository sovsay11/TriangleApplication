using System;

namespace TriangleApplication
{
    internal class Triangle
    {
        // properties for the triangle
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double AngleB { get; set; }
        public double AngleA { get; set; }
        public double AngleC { get; set; }

        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
            if (IsTriangle()) SetTriangleAngles();
        }

        /// <summary>
        /// Gets the type of triangle based on the side lengths.
        /// Will return either scalene, isosceles, or equilateral.
        /// Returns a string value.
        /// </summary>
        /// <returns></returns>
        public string GetTriangleSideType()
        {
            string sideType = (SideA == SideB && SideA == SideC) ? "equilateral" : (SideA != SideB && SideA != SideC && SideB != SideC) ? "scalene" : "isosceles";
            return sideType;
        }

        /// <summary>
        /// Determines the type of triangle based
        /// on the angles calculated from the sides.
        /// </summary>
        /// <returns></returns>
        public string GetTriangleAngleType()
        {
            string angleType = (AngleA == 90 || AngleB == 90 || AngleC == 90) ? "right" : (AngleA > 90 || AngleB > 90 || AngleC > 90) ? "obtuse" : "acute";
            return angleType;
        }

        /// <summary>
        /// Calculates the angle values for the triangle given the sides.
        /// </summary>
        public void SetTriangleAngles()
        {
            // assignment of power variables for the equations below
            double powA = Math.Pow(SideA, 2);
            double powB = Math.Pow(SideB, 2);
            double powC = Math.Pow(SideC, 2);

            // calculate the angles and round them to 2 decimal places, converts to degrees
            AngleA = Math.Round(Math.Acos((powA + powB - powC) / (2 * SideA * SideB)) * (180 / Math.PI), 2);
            AngleB = Math.Round(Math.Acos((powB + powC - powA) / (2 * SideB * SideC)) * (180 / Math.PI), 2);
            AngleC = Math.Round(Math.Acos((powC + powA - powB) / (2 * SideC * SideA)) * (180 / Math.PI), 2);
        }

        /// <summary>
        /// Checks if the provided side values
        /// produce a valid triangle. Returns a boolean value.
        /// </summary>
        /// <returns></returns>
        public bool IsTriangle()
        {
            return SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA;
        }
    }
}
