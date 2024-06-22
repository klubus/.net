using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeFactory = new ShapeFactory();
            var circle = shapeFactory.CreateShape(ShapeType.Circle);

            circle.Render();

            // Wzorzec fabryka oddziela kod, który tworzy konkretne obiekty od kodu, który faktycznie z nich korzysta
            // Dlatego w ten sposób jest dużo łatwiej rozszerzać kod tworzący nowe obiekty, bez konieczności ingerencji w resztę kodu.
        }
    }
}