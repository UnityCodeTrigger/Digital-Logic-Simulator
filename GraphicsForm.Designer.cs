
namespace DigitalLogicSimulator
{
    partial class GraphicsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer comps = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (comps != null))
            {
                comps.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateComponentButton = new System.Windows.Forms.Button();
            this.MoveComponentButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DeleteComponentButton = new System.Windows.Forms.Button();
            this.SelectedComponentLabel = new System.Windows.Forms.Label();
            this.SelectedOptionLabel = new System.Windows.Forms.Label();
            this.Create_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.Create_flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateComponentButton
            // 
            this.CreateComponentButton.Location = new System.Drawing.Point(522, 7);
            this.CreateComponentButton.Name = "CreateComponentButton";
            this.CreateComponentButton.Size = new System.Drawing.Size(193, 85);
            this.CreateComponentButton.TabIndex = 1;
            this.CreateComponentButton.Text = "Create";
            this.CreateComponentButton.UseVisualStyleBackColor = true;
            this.CreateComponentButton.Click += new System.EventHandler(this.OnCreateComponentButtonClick);
            // 
            // MoveComponentButton
            // 
            this.MoveComponentButton.Location = new System.Drawing.Point(323, 7);
            this.MoveComponentButton.Name = "MoveComponentButton";
            this.MoveComponentButton.Size = new System.Drawing.Size(193, 85);
            this.MoveComponentButton.TabIndex = 0;
            this.MoveComponentButton.Text = "Move";
            this.MoveComponentButton.UseVisualStyleBackColor = true;
            this.MoveComponentButton.Click += new System.EventHandler(this.OnMoveComponentButtonClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.MoveComponentButton);
            this.flowLayoutPanel1.Controls.Add(this.CreateComponentButton);
            this.flowLayoutPanel1.Controls.Add(this.DeleteComponentButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 880);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(320, 4, 320, 4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1262, 97);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // DeleteComponentButton
            // 
            this.DeleteComponentButton.Location = new System.Drawing.Point(721, 7);
            this.DeleteComponentButton.Name = "DeleteComponentButton";
            this.DeleteComponentButton.Size = new System.Drawing.Size(193, 85);
            this.DeleteComponentButton.TabIndex = 2;
            this.DeleteComponentButton.Text = "Delete";
            this.DeleteComponentButton.UseVisualStyleBackColor = true;
            this.DeleteComponentButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
            // 
            // SelectedComponentLabel
            // 
            this.SelectedComponentLabel.AutoSize = true;
            this.SelectedComponentLabel.BackColor = System.Drawing.Color.White;
            this.SelectedComponentLabel.Location = new System.Drawing.Point(12, 38);
            this.SelectedComponentLabel.Name = "SelectedComponentLabel";
            this.SelectedComponentLabel.Size = new System.Drawing.Size(147, 17);
            this.SelectedComponentLabel.TabIndex = 1;
            this.SelectedComponentLabel.Text = "Selected Component: ";
            // 
            // SelectedOptionLabel
            // 
            this.SelectedOptionLabel.AutoSize = true;
            this.SelectedOptionLabel.BackColor = System.Drawing.Color.White;
            this.SelectedOptionLabel.Location = new System.Drawing.Point(12, 12);
            this.SelectedOptionLabel.Name = "SelectedOptionLabel";
            this.SelectedOptionLabel.Size = new System.Drawing.Size(114, 17);
            this.SelectedOptionLabel.TabIndex = 2;
            this.SelectedOptionLabel.Text = "Selected option: ";
            // 
            // Create_flowLayoutPanel
            // 
            this.Create_flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.Create_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Create_flowLayoutPanel.Controls.Add(this.button1);
            this.Create_flowLayoutPanel.Controls.Add(this.button2);
            this.Create_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Create_flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Create_flowLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Create_flowLayoutPanel.Location = new System.Drawing.Point(1062, 0);
            this.Create_flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Create_flowLayoutPanel.Name = "Create_flowLayoutPanel";
            this.Create_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
            this.Create_flowLayoutPanel.Size = new System.Drawing.Size(200, 880);
            this.Create_flowLayoutPanel.TabIndex = 3;
            this.Create_flowLayoutPanel.Visible = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(25, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "AND";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(25, 68);
            this.button2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "NOT";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // GraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1262, 977);
            this.Controls.Add(this.Create_flowLayoutPanel);
            this.Controls.Add(this.SelectedOptionLabel);
            this.Controls.Add(this.SelectedComponentLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "GraphicsForm";
            this.Text = "GraphicsForm";
            this.Shown += new System.EventHandler(this.GraphicsForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphicsForm_MouseDown);
            this.MouseHover += new System.EventHandler(this.GraphicsForm_MouseHover);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphicsForm_MouseUp);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Create_flowLayoutPanel.ResumeLayout(false);
            this.Create_flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CreateComponentButton;
        private System.Windows.Forms.Button MoveComponentButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button DeleteComponentButton;
        private System.Windows.Forms.Label SelectedComponentLabel;
        private System.Windows.Forms.Label SelectedOptionLabel;
        private System.Windows.Forms.FlowLayoutPanel Create_flowLayoutPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}