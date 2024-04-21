using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalLogicSimulator
{

    #region Structs
    public struct Vector2
    {
        public float x, y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 up { get { return new Vector2(0, 1); } }
        public static Vector2 right { get { return new Vector2(1, 0); } }
        public static float Distance(Vector2 a, Vector2 b)
        {
            float dx = b.x - a.x;
            float dy = b.y - a.y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }
    }

    public struct Line
    {
        public Vector2 i, f;
        public Line(Vector2 i, Vector2 f)
        {
            this.i = i;
            this.f = f;
        }
    }
    public struct Rectangle
    {
        public Vector2 i, f;
        public System.Drawing.Rectangle toRectangle
        {
            get
            {
                // He tenido que hacer este follon porque no permite numeros negativos, un rectangulo de tamaño Size(-2,1) no se mostrara.
                // Aqui se calcula la diferencia de posiciones (|X - Xo|) al saber la diferencia el absoluto de esta acaba siendo la distancia
                int width = Math.Abs((int)(f.x - i.x));
                int height = Math.Abs((int)(f.y - i.y));
                // Esto no es mas que las posiciones
                int x = Math.Min((int)i.x, (int)f.x);
                int y = Math.Min((int)i.y, (int)f.y);

                return new System.Drawing.Rectangle(new Point(x, y), new Size(width, height));
            }
            private set { }
        }

        public Rectangle(Vector2 i, Vector2 f)
        {
            this.i = i;
            this.f = f;
        }
    }
    #endregion

    public class DrawHandler
    {
        Graphics graphics;
        Form currentForm;


        SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(255, 16, 16, 16));
        SolidBrush onBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
        SolidBrush offBrush = new SolidBrush(Color.FromArgb(255, 64, 64, 64));

        public DrawHandler(Graphics graphics, Form currentForm)
        {
            this.graphics = graphics;
            this.currentForm = currentForm;
        }

        public void Clear()
        {
            graphics.Clear(currentForm.BackColor);
        }

        public void DrawLine(Line line, Color color)
        {
            Vector2 i, f;
            i = line.i;
            f = line.f;

            graphics.DrawLine(new Pen(color), i.x, i.y, f.x, f.y);
        }
        public void DrawLine(Vector2 a, Vector2 b)
        {
            DrawLine(new Line(a,b),Color.Black);
        }

        public void DrawFillRectangle(Rectangle rectangle)
        {
            Vector2 i, f;
            i = rectangle.i;
            f = rectangle.f;

            graphics.FillRectangle(Brushes.Black, rectangle.toRectangle);
        }
        public void DrawFillRectangle(Vector2 position, Vector2 size, Color color)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle((int)position.x, (int)position.y, (int)size.x, (int)size.y);
            Brush brush = new SolidBrush(color);

            graphics.FillRectangle(brush, rect);
        }

        public void DrawComponent(Component comp)
        {
            Vector2 rectPos = comp.pos + (-Vector2.right * (Component.WIDTH / 2f) + -Vector2.up * (comp.height / 2f));
            DrawFillRectangle(rectPos, new Vector2(Component.WIDTH, comp.height), comp.color);

            DrawConnectors(comp, rectPos);
            DrawName(comp, rectPos);
        }
        void DrawConnectors(Component comp, Vector2 rectPos)
        {
            const int ellipseSize = (int)(Component.Connector.radius * 2);
            // IN
            float ellipseSpacing = comp.height / comp.numberOfInputs;
            for (int i = 0; i < comp.numberOfInputs; i++)
            {
                float halfHeight = comp.height * 0.5f;
                float offsetY = (comp.numberOfInputs - 1) * 0.5f * ellipseSpacing + (Component.HEIGHT / 2);

                float ellipsePosY = rectPos.y + halfHeight - offsetY + (ellipseSpacing * i);
                float ellipsePosX = rectPos.x - (Component.WIDTH / 2) + ellipseSize;
                Vector2 ellipsePos = new Vector2(ellipsePosX, ellipsePosY);
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle((int)ellipsePos.x, (int)ellipsePos.y, ellipseSize, ellipseSize);

                Brush brush;
                if (comp.inConnectors[i].isActive)
                    brush = onBrush;
                else
                    brush = offBrush;
                graphics.FillEllipse(brush, rect);
                graphics.DrawEllipse(new Pen(backgroundBrush, 2), rect);
            }

            // OUT
            ellipseSpacing = comp.height / comp.numberOfOutputs;
            for (int i = 0; i < comp.numberOfOutputs; i++)
            {
                float halfHeight = comp.height * 0.5f;
                float offsetY = (comp.numberOfOutputs - 1) * 0.5f * ellipseSpacing + (Component.HEIGHT / 2);

                float ellipsePosY = rectPos.y + halfHeight - offsetY + (ellipseSpacing * i);
                float ellipsePosX = rectPos.x + (Component.WIDTH / 2) + ellipseSize;
                Vector2 ellipsePos = new Vector2(ellipsePosX, ellipsePosY);
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle((int)ellipsePos.x, (int)ellipsePos.y, ellipseSize, ellipseSize);

                Brush brush;
                if (comp.outConnectors[i].isActive)
                    brush = onBrush;
                else
                    brush = offBrush;
                graphics.FillEllipse(brush, rect);
                graphics.DrawEllipse(new Pen(backgroundBrush, 2), rect);
            }
        }
        void DrawName(Component comp, Vector2 rectPos)
        {
            int fontSize = 16;
            Font font = new Font("Arial", 16,FontStyle.Bold);
            graphics.DrawString(comp.name, font, backgroundBrush, rectPos.x + (Component.WIDTH * 0.25f), rectPos.y + (fontSize * 0.25f) + (comp.height * 0.25f));
        }
        
        public static Color FromHSL(float hue, int saturation, int lightness)
        {
            double h = hue / 360.0;
            double s = saturation / 255.0;
            double l = lightness / 255.0;

            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h * 6) % 2 - 1));
            double m = l - c / 2;

            double r, g, b;
            if (h < 1.0 / 6.0)
            {
                r = c; g = x; b = 0;
            }
            else if (h < 2.0 / 6.0)
            {
                r = x; g = c; b = 0;
            }
            else if (h < 3.0 / 6.0)
            {
                r = 0; g = c; b = x;
            }
            else if (h < 4.0 / 6.0)
            {
                r = 0; g = x; b = c;
            }
            else if (h < 5.0 / 6.0)
            {
                r = x; g = 0; b = c;
            }
            else
            {
                r = c; g = 0; b = x;
            }

            byte red = Convert.ToByte((r + m) * 255);
            byte green = Convert.ToByte((g + m) * 255);
            byte blue = Convert.ToByte((b + m) * 255);

            return Color.FromArgb(255, red, green, blue);
        }
    }

}
