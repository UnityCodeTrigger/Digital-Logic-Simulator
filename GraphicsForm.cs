using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalLogicSimulator.Components;

namespace DigitalLogicSimulator
{
    public enum InputAction
    {
        Nothing,
        MoveComponent,
        CreateComponent,
        DeleteComponent
    }

    public partial class GraphicsForm : Form
    {
        DrawHandler draw;
        List<Component> components;
        InputAction currentInputAction = InputAction.Nothing;

        //
        Vector2 mouseDownPosition;
        Component selectedComponent;
        bool drawCollisions = false;

        public GraphicsForm()
        {
            InitializeComponent();
            components = new List<Component>();
            draw = new DrawHandler(CreateGraphics(), this);

            DrawScreen();
            ChangeInputAction(InputAction.Nothing);
        }

        void DrawScreen()
        {
            draw.Clear();

            foreach (var component in components)
                draw.DrawComponent(component);

            if(drawCollisions)
                DrawCollisions();
        }

        void DrawCollisions()
        {
            foreach (var component in components)
            {
                draw.DrawComponent(component);

                draw.DrawLine(new Line(component.componentBoundA, component.componentBoundB), Color.Blue);

                int connectorSize = (int)Component.Connector.radius * 2;
                foreach (var connector in component.inConnectors.Concat(component.outConnectors))
                {
                    draw.DrawLine(new Line(connector.pos, connector.pos + Vector2.up * 50), Color.Green);
                    draw.DrawLine(new Line(connector.pos, connector.pos + Vector2.right * 50), Color.Red);

                    draw.DrawLine(new Line(connector.pos + (Vector2.right * connectorSize), connector.pos + (Vector2.right * connectorSize) + Vector2.up * connectorSize), Color.Green);
                    draw.DrawLine(new Line(connector.pos + (Vector2.up * connectorSize), connector.pos + (Vector2.up * connectorSize) + Vector2.right * connectorSize), Color.Red);
                }
            }
        }

        // Inputs
        void GraphicsForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPosition = new Vector2(e.X, e.Y);
            Console.WriteLine($"{DateTime.Now.Minute}m{DateTime.Now.Second}s: Click down");

            selectedComponent = GetComponentOnMousePosition();
            if (selectedComponent != null)
            {
                SelectedComponentLabel.Text = "Selected component: " + selectedComponent.name;
            }
        }

        void GraphicsForm_MouseUp(object sender, MouseEventArgs e)
        {
            Vector2 mouseUpPosition = new Vector2(e.X, e.Y);

            switch (currentInputAction)
            {
                case InputAction.Nothing:
                    HandleNothingAction(mouseUpPosition);
                    break;
                case InputAction.MoveComponent:
                    MoveSelectedComponent(mouseUpPosition);
                    break;
                case InputAction.CreateComponent:
                    CreateNewComponent(mouseUpPosition);
                    break;
                case InputAction.DeleteComponent:
                    DeleteSelectedComponent();
                    break;
            }

            DrawScreen();
            selectedComponent = null;
        }

        Component GetComponentOnMousePosition()
        {
            for (int i = 0; i < components.Count; i++)
                if (components[i].isOnComponentPosition(mouseDownPosition))
                    return components[i];

            return null;
        }

        #region HandleActions

        void ChangeInputAction(InputAction newInputAction)
        {
            if (currentInputAction == newInputAction)
                currentInputAction = InputAction.Nothing;
            else
                currentInputAction = newInputAction;

            SelectedOptionLabel.Text = "Selected option: " + currentInputAction.ToString();
        }
        void HandleNothingAction(Vector2 pos)
        {
            Component comp = GetComponentOnMousePosition();
            if (comp == null) { return; }

            Component.Connector connector = comp.GetConnectorOnPosition(pos);
            if(connector == null) { return; }

            comp.SwitchConnector(connector);
        }
        void CreateNewComponent(Vector2 pos)
        {
            components.Add(new AND(pos));
            ChangeInputAction(InputAction.Nothing);
        }
        void MoveSelectedComponent(Vector2 pos)
        {
            if (selectedComponent == null) { return; }

            selectedComponent.pos = pos;
            selectedComponent.CalculateInOutCollisions();

            selectedComponent = null;
            SelectedComponentLabel.Text = "Selected component: ";
        }
        void DeleteSelectedComponent()
        {
            components.Remove(selectedComponent);
            ChangeInputAction(InputAction.Nothing);
        }

        #endregion

        #region Buttons
        private void OnMoveComponentButtonClicked(object sender, EventArgs e)
        {
            ChangeInputAction(InputAction.MoveComponent);
        }
        private void OnCreateComponentButtonClick(object sender, EventArgs e)
        {
            //Create_flowLayoutPanel.Visible = !Create_flowLayoutPanel.Visible;
            ChangeInputAction(InputAction.CreateComponent);
        }
        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            ChangeInputAction(InputAction.DeleteComponent);
        }
        #endregion

        #region Unused
        private void GraphicsForm_Load(object sender, EventArgs e)
        {

        }
        private void GraphicsForm_Shown(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void GraphicsForm_MouseHover(object sender, EventArgs e)
        {
        }

        #endregion

    }

}
