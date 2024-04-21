using System.Collections.Generic;

namespace DigitalLogicSimulator.Components
{
    class NOT : Component
    {
        public NOT(Vector2 position) : base(position)
        {
            base.numberOfInputs = 1;
            base.numberOfOutputs = 1;
            base.name = "NOT";
            this.color = System.Drawing.Color.Red;

            base.InitializeComponent();
        }

        protected override void GenerateTruthTable()
        {
            base.truthTable = new List<bool>();
        }

        public override void Compute()
        {
            outConnectors[0].isActive = !inConnectors[0].isActive;
        }
    }
}
