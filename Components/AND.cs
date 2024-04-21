using System.Collections.Generic;

namespace DigitalLogicSimulator.Components
{
    class AND : Component
    {
        public AND(Vector2 position) : base(position)
        {
            base.numberOfInputs = 2;
            base.numberOfOutputs = 1;
            base.name = "AND";
            base.color = System.Drawing.Color.Blue;

            GenerateTruthTable();
            base.InitializeComponent();
        }

        protected override void GenerateTruthTable()
        {
            base.truthTable = new List<bool>();
        }

        public override void Compute()
        {
            outConnectors[0].isActive = (inConnectors[0].isActive && inConnectors[1].isActive);
        }
    }
}
