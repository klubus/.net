﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ShapeFactory
    {
        public Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    return new  Circle();
                case ShapeType.Triangle:
                    return new Triangle();
                case ShapeType.Rectangle:
                    return new Rectangle();
                default:
                    throw new Exception($"Shape type {type} is not handled");
            }
        }
    }
}
