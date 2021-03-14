using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shapeRectangle = new Rectangle();
            IShape shapeSquare = new Square();
            IShape shapeCircle = new Circle();

            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(shapeRectangle);
            graphicEditor.DrawShape(shapeSquare);
            graphicEditor.DrawShape(shapeCircle);
        }
    }
}
