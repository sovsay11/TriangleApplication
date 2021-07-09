﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleApplication
{
    class Triangle
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
            SetTriangleAngles();
        }

        /// <summary>
        /// Gets the type of triangle based on the side lengths.
        /// Will return either scalene, isosceles, or equilateral.
        /// Returns a string value.
        /// </summary>
        /// <returns></returns>
        public string GetTriangleSideType()
        {
            // we can assume all the values are valid at this point
            // the types
            // Scalene(side)
            // Isosceles(side)
            // Equilateral(side)
            if (SideA == SideB && SideA == SideC)
            {
                return "equilateral";
            }
            else if (SideA != SideB && SideA != SideC && SideB != SideC)
            {
                return "scalene";
            }
            return "isosceles";

        }

        /// <summary>
        /// Determines the type of triangle based
        /// on the angles calculated from the sides.
        /// </summary>
        /// <returns></returns>
        public string GetTriangleAngleType()
        {
            // determine the type of triangle based on the angles
            if (AngleA == 90 || AngleB == 90 || AngleC == 90)
            {
                return "right";
            }
            else if (AngleA > 90 || AngleB > 90 || AngleC > 90)
            {
                return "obtuse";
            }
            return "acute";
        }

        /// <summary>
        /// Sets the angle values for the triangle given the sides.
        /// Also determines whether the provided angles create an obtuse,
        /// acute, or right triangle.
        /// </summary>
        /// <returns></returns>
        public void SetTriangleAngles()
        {
            // cos(C) = (a2 + b2 − c2) / 2ab
            // cos(A) = (b2 + c2 − a2) / 2bc
            // cos(B) = (c2 + a2 − b2) / 2ca
            double powA = Math.Pow(SideA, 2);
            double powB = Math.Pow(SideB, 2);
            double powC = Math.Pow(SideC, 2);

            // calculate the angles and round them to 2 decimal places
            AngleA = Math.Round(Math.Acos((powA + powB - powC) / (2 * SideA * SideB)) * (180 / Math.PI), 2);
            AngleB = Math.Round(Math.Acos((powB + powC - powA) / (2 * SideB * SideC)) * (180 / Math.PI), 2);
            AngleC = Math.Round(Math.Acos((powC + powA - powB) / (2 * SideC * SideA)) * (180 / Math.PI), 2);
        }

        /// <summary>
        /// Checks if the provided side values
        /// produces a valid triangle. Returns a boolean value.
        /// </summary>
        /// <returns></returns>
        public bool IsTriangle()
        {
            return SideA + SideB > SideC &&
                SideA + SideC > SideB &&
                SideB + SideC > SideA;
        }
    }
}
