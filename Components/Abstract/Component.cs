using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalLogicSimulator
{
    public abstract class Component
    {
        public class Connector
        {
            public bool isActive;
            public Vector2 pos;
            public const float radius = (32f / 2f);

            bool isIn;

            public Connector(bool isIn)
            {
                this.isIn = isIn;
            }

            public bool IsInput()
            {
                return isIn;
            }
        }

        internal List<bool> truthTable;

        public string name;
        Label label;
        public Vector2 pos;
        public Color color;

        internal int numberOfInputs;
        internal int numberOfOutputs;

        public Connector[] inConnectors;
        public Connector[] outConnectors;

        public const float WIDTH = 100;
        public const float HEIGHT = 33;
        public float height { get { return HEIGHT * Math.Max(numberOfInputs, numberOfOutputs); } }

        public Vector2 componentBoundA { get { return new Vector2(pos.x - (WIDTH / 2) - Connector.radius, pos.y - (height / 2)); } private set { } }
        public Vector2 componentBoundB { get { return new Vector2(pos.x + (WIDTH / 2) + Connector.radius, pos.y + (height / 2)); } private set { } }

        public Component(Vector2 position)
        {
            this.pos = position;
        }

        public void InitializeComponent()
        {
            if(color == null)
                this.color = DrawHandler.FromHSL((float)(new Random().Next(0, 360)), 255, 255 / 2); // Random

            label = new Label();
            label.Text = name;
            label.Location = new Point((int)pos.x,(int)pos.y);

            InitializeConnectors();
            CalculateInOutCollisions();

            Compute();
        }

        void InitializeConnectors()
        {
            inConnectors = new Connector[numberOfInputs];
            outConnectors = new Connector[numberOfOutputs];

            for (int i = 0; i < inConnectors.Length; i++)
                inConnectors[i] = new Connector(true);

            for (int i = 0; i < outConnectors.Length; i++)
                outConnectors[i] = new Connector(false);
        }

        public void CalculateInOutCollisions()
        {
            const int connectorSize = 32;
            float connectorSpacing = height / Math.Max(numberOfInputs, numberOfOutputs);
            Vector2 rectPos = pos + (-Vector2.right * (WIDTH / 2f) + -Vector2.up * (height / 2f));
            float ellipseSpacing = height / numberOfInputs;

            for (int i = 0; i < numberOfInputs; i++)
            {
                float offsetY = (numberOfInputs - 1) * 0.5f * ellipseSpacing + (HEIGHT / 2);
                float connectorPosY = rectPos.y + (height/2) - offsetY + (connectorSpacing * i);
                float connectorPosX = pos.x - (WIDTH / 2) - (connectorSize / 2);

                inConnectors[i].pos = new Vector2(connectorPosX, connectorPosY);
            }

            for (int i = 0; i < numberOfOutputs; i++)
            {
                float offsetY = (numberOfOutputs - 1) * 0.5f * ellipseSpacing + (HEIGHT / 2);
                float connectorPosY = rectPos.y + (height / 2) - offsetY + (connectorSpacing * i);
                float connectorPosX = pos.x + (WIDTH / 2) - (connectorSize / 2);

                outConnectors[i].pos = new Vector2(connectorPosX, connectorPosY);
            }
        }

        public bool isOnComponentPosition(Vector2 c)
        {
            float minX = Math.Min(componentBoundA.x, componentBoundB.x);
            float maxX = Math.Max(componentBoundA.x, componentBoundB.x);
            float minY = Math.Min(componentBoundA.y, componentBoundB.y);
            float maxY = Math.Max(componentBoundA.y, componentBoundB.y);

            return c.x >= minX && c.x <= maxX && c.y >= minY && c.y <= maxY;
        }

        public bool IsClickOnConnector(Vector2 clickPos)
        {
            foreach (Connector connector in inConnectors.Concat(outConnectors))
            {
                float squareSize = Connector.radius * 2;

                if (clickPos.x >= connector.pos.x && clickPos.x <= connector.pos.x + squareSize &&
                    clickPos.y >= connector.pos.y && clickPos.y <= connector.pos.y + squareSize)
                {
                    return true;
                }
            }

            return false;
        }

        public Connector GetConnectorOnPosition(Vector2 pos)
        {
            if (IsClickOnConnector(pos) == false) { return null; }

            foreach (Connector connector in inConnectors.Concat(outConnectors))
            {
                float squareSize = Connector.radius * 2;

                if (pos.x >= connector.pos.x && pos.x <= connector.pos.x + squareSize &&
                    pos.y >= connector.pos.y && pos.y <= connector.pos.y + squareSize)
                {
                    return connector;
                }
            }

            return null;
        }

        public void SwitchConnector(Connector connector)
        {
            connector.isActive = !connector.isActive;

            Compute();
        }

        public abstract void Compute();
        protected abstract void GenerateTruthTable();
    }

}
