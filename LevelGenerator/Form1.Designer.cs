using Microsoft.Msagl.GraphViewerGdi;

namespace LevelGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelLeftGraph = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.gViewerLeft = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.panelRightGraph = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.gViewerRight = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.tBNewNode = new System.Windows.Forms.TextBox();
            this.buttonAddNode = new System.Windows.Forms.Button();
            this.buttonDeleteNode = new System.Windows.Forms.Button();
            this.buttonNewRule = new System.Windows.Forms.Button();
            this.tBNewRule = new System.Windows.Forms.TextBox();
            this.lBRules = new System.Windows.Forms.ListBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tBNodeNumber = new System.Windows.Forms.TextBox();
            this.buttonApplyRule = new System.Windows.Forms.Button();
            this.bSaveRules = new System.Windows.Forms.Button();
            this.bLoadRules = new System.Windows.Forms.Button();
            this.gViewerMission = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panelLeftGraph.SuspendLayout();
            this.panelRightGraph.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftGraph
            // 
            this.panelLeftGraph.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeftGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftGraph.Controls.Add(this.label8);
            this.panelLeftGraph.Controls.Add(this.gViewerLeft);
            this.panelLeftGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.panelLeftGraph.Location = new System.Drawing.Point(12, 13);
            this.panelLeftGraph.Name = "panelLeftGraph";
            this.panelLeftGraph.Size = new System.Drawing.Size(356, 236);
            this.panelLeftGraph.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label8.Location = new System.Drawing.Point(116, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 24);
            this.label8.TabIndex = 19;
            this.label8.Text = "LEFT SIDE:";
            // 
            // gViewerLeft
            // 
            this.gViewerLeft.ArrowheadLength = 10D;
            this.gViewerLeft.AsyncLayout = false;
            this.gViewerLeft.AutoScroll = true;
            this.gViewerLeft.BackwardEnabled = false;
            this.gViewerLeft.BuildHitTree = true;
            this.gViewerLeft.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewerLeft.EdgeInsertButtonVisible = true;
            this.gViewerLeft.FileName = "";
            this.gViewerLeft.ForwardEnabled = false;
            this.gViewerLeft.Graph = null;
            this.gViewerLeft.InsertingEdge = false;
            this.gViewerLeft.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewerLeft.LayoutEditingEnabled = true;
            this.gViewerLeft.Location = new System.Drawing.Point(-1, 31);
            this.gViewerLeft.LooseOffsetForRouting = 0.25D;
            this.gViewerLeft.MouseHitDistance = 0.05D;
            this.gViewerLeft.Name = "gViewerLeft";
            this.gViewerLeft.NavigationVisible = true;
            this.gViewerLeft.NeedToCalculateLayout = true;
            this.gViewerLeft.OffsetForRelaxingInRouting = 0.6D;
            this.gViewerLeft.PaddingForEdgeRouting = 8D;
            this.gViewerLeft.PanButtonPressed = false;
            this.gViewerLeft.SaveAsImageEnabled = true;
            this.gViewerLeft.SaveAsMsaglEnabled = true;
            this.gViewerLeft.SaveButtonVisible = true;
            this.gViewerLeft.SaveGraphButtonVisible = true;
            this.gViewerLeft.SaveInVectorFormatEnabled = true;
            this.gViewerLeft.Size = new System.Drawing.Size(356, 205);
            this.gViewerLeft.TabIndex = 0;
            this.gViewerLeft.TightOffsetForRouting = 0.125D;
            this.gViewerLeft.ToolBarIsVisible = true;
            this.gViewerLeft.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewerLeft.Transform")));
            this.gViewerLeft.UndoRedoButtonsVisible = true;
            this.gViewerLeft.WindowZoomButtonPressed = false;
            this.gViewerLeft.ZoomF = 1D;
            this.gViewerLeft.ZoomWindowThreshold = 0.05D;
            this.gViewerLeft.Click += new System.EventHandler(this.gViewerLeft_Click);
            // 
            // panelRightGraph
            // 
            this.panelRightGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightGraph.Controls.Add(this.label9);
            this.panelRightGraph.Controls.Add(this.gViewerRight);
            this.panelRightGraph.Location = new System.Drawing.Point(12, 255);
            this.panelRightGraph.Name = "panelRightGraph";
            this.panelRightGraph.Size = new System.Drawing.Size(356, 236);
            this.panelRightGraph.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label9.Location = new System.Drawing.Point(116, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 24);
            this.label9.TabIndex = 20;
            this.label9.Text = "RIGHT SIDE:";
            // 
            // gViewerRight
            // 
            this.gViewerRight.ArrowheadLength = 10D;
            this.gViewerRight.AsyncLayout = false;
            this.gViewerRight.AutoScroll = true;
            this.gViewerRight.BackwardEnabled = false;
            this.gViewerRight.BuildHitTree = true;
            this.gViewerRight.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewerRight.EdgeInsertButtonVisible = true;
            this.gViewerRight.FileName = "";
            this.gViewerRight.ForwardEnabled = false;
            this.gViewerRight.Graph = null;
            this.gViewerRight.InsertingEdge = false;
            this.gViewerRight.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewerRight.LayoutEditingEnabled = true;
            this.gViewerRight.Location = new System.Drawing.Point(-2, 30);
            this.gViewerRight.LooseOffsetForRouting = 0.25D;
            this.gViewerRight.MouseHitDistance = 0.05D;
            this.gViewerRight.Name = "gViewerRight";
            this.gViewerRight.NavigationVisible = true;
            this.gViewerRight.NeedToCalculateLayout = true;
            this.gViewerRight.OffsetForRelaxingInRouting = 0.6D;
            this.gViewerRight.PaddingForEdgeRouting = 8D;
            this.gViewerRight.PanButtonPressed = false;
            this.gViewerRight.SaveAsImageEnabled = true;
            this.gViewerRight.SaveAsMsaglEnabled = true;
            this.gViewerRight.SaveButtonVisible = true;
            this.gViewerRight.SaveGraphButtonVisible = true;
            this.gViewerRight.SaveInVectorFormatEnabled = true;
            this.gViewerRight.Size = new System.Drawing.Size(357, 205);
            this.gViewerRight.TabIndex = 1;
            this.gViewerRight.TightOffsetForRouting = 0.125D;
            this.gViewerRight.ToolBarIsVisible = true;
            this.gViewerRight.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewerRight.Transform")));
            this.gViewerRight.UndoRedoButtonsVisible = true;
            this.gViewerRight.WindowZoomButtonPressed = false;
            this.gViewerRight.ZoomF = 1D;
            this.gViewerRight.ZoomWindowThreshold = 0.05D;
            this.gViewerRight.Click += new System.EventHandler(this.gViewerRight_Click);
            // 
            // tBNewNode
            // 
            this.tBNewNode.Location = new System.Drawing.Point(6, 58);
            this.tBNewNode.Name = "tBNewNode";
            this.tBNewNode.Size = new System.Drawing.Size(156, 20);
            this.tBNewNode.TabIndex = 5;
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Location = new System.Drawing.Point(3, 121);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(159, 20);
            this.buttonAddNode.TabIndex = 6;
            this.buttonAddNode.Text = "Add node";
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // buttonDeleteNode
            // 
            this.buttonDeleteNode.Location = new System.Drawing.Point(3, 147);
            this.buttonDeleteNode.Name = "buttonDeleteNode";
            this.buttonDeleteNode.Size = new System.Drawing.Size(159, 23);
            this.buttonDeleteNode.TabIndex = 7;
            this.buttonDeleteNode.Text = "Delete node";
            this.buttonDeleteNode.UseVisualStyleBackColor = true;
            this.buttonDeleteNode.Click += new System.EventHandler(this.buttonDeleteNode_Click);
            // 
            // buttonNewRule
            // 
            this.buttonNewRule.Location = new System.Drawing.Point(1, 120);
            this.buttonNewRule.Name = "buttonNewRule";
            this.buttonNewRule.Size = new System.Drawing.Size(157, 23);
            this.buttonNewRule.TabIndex = 8;
            this.buttonNewRule.Text = "Save rule to list";
            this.buttonNewRule.UseVisualStyleBackColor = true;
            this.buttonNewRule.Click += new System.EventHandler(this.buttonNewRule_Click);
            // 
            // tBNewRule
            // 
            this.tBNewRule.Location = new System.Drawing.Point(3, 94);
            this.tBNewRule.Name = "tBNewRule";
            this.tBNewRule.Size = new System.Drawing.Size(155, 20);
            this.tBNewRule.TabIndex = 9;
            // 
            // lBRules
            // 
            this.lBRules.FormattingEnabled = true;
            this.lBRules.Location = new System.Drawing.Point(2, 70);
            this.lBRules.Name = "lBRules";
            this.lBRules.Size = new System.Drawing.Size(167, 108);
            this.lBRules.TabIndex = 10;
            this.lBRules.SelectedIndexChanged += new System.EventHandler(this.lBRules_SelectedIndexChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(1, 149);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(157, 23);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // tBNodeNumber
            // 
            this.tBNodeNumber.Location = new System.Drawing.Point(6, 96);
            this.tBNodeNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tBNodeNumber.Name = "tBNodeNumber";
            this.tBNodeNumber.Size = new System.Drawing.Size(156, 20);
            this.tBNodeNumber.TabIndex = 13;
            // 
            // buttonApplyRule
            // 
            this.buttonApplyRule.Location = new System.Drawing.Point(775, 438);
            this.buttonApplyRule.Name = "buttonApplyRule";
            this.buttonApplyRule.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyRule.TabIndex = 14;
            this.buttonApplyRule.Text = "Apply rule";
            this.buttonApplyRule.UseVisualStyleBackColor = true;
            this.buttonApplyRule.Click += new System.EventHandler(this.buttonApplyRule_Click);
            // 
            // bSaveRules
            // 
            this.bSaveRules.Location = new System.Drawing.Point(3, 183);
            this.bSaveRules.Margin = new System.Windows.Forms.Padding(2);
            this.bSaveRules.Name = "bSaveRules";
            this.bSaveRules.Size = new System.Drawing.Size(167, 19);
            this.bSaveRules.TabIndex = 15;
            this.bSaveRules.Text = "Save as XML";
            this.bSaveRules.UseVisualStyleBackColor = true;
            this.bSaveRules.Click += new System.EventHandler(this.bSaveRules_Click);
            // 
            // bLoadRules
            // 
            this.bLoadRules.Location = new System.Drawing.Point(3, 206);
            this.bLoadRules.Margin = new System.Windows.Forms.Padding(2);
            this.bLoadRules.Name = "bLoadRules";
            this.bLoadRules.Size = new System.Drawing.Size(167, 19);
            this.bLoadRules.TabIndex = 16;
            this.bLoadRules.Text = "Load XML";
            this.bLoadRules.UseVisualStyleBackColor = true;
            this.bLoadRules.Click += new System.EventHandler(this.bLoadRules_Click);
            // 
            // gViewerMission
            // 
            this.gViewerMission.ArrowheadLength = 10D;
            this.gViewerMission.AsyncLayout = false;
            this.gViewerMission.AutoScroll = true;
            this.gViewerMission.BackwardEnabled = false;
            this.gViewerMission.BuildHitTree = true;
            this.gViewerMission.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewerMission.EdgeInsertButtonVisible = true;
            this.gViewerMission.FileName = "";
            this.gViewerMission.ForwardEnabled = false;
            this.gViewerMission.Graph = null;
            this.gViewerMission.InsertingEdge = false;
            this.gViewerMission.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewerMission.LayoutEditingEnabled = true;
            this.gViewerMission.Location = new System.Drawing.Point(-1, 29);
            this.gViewerMission.LooseOffsetForRouting = 0.25D;
            this.gViewerMission.MouseHitDistance = 0.05D;
            this.gViewerMission.Name = "gViewerMission";
            this.gViewerMission.NavigationVisible = true;
            this.gViewerMission.NeedToCalculateLayout = true;
            this.gViewerMission.OffsetForRelaxingInRouting = 0.6D;
            this.gViewerMission.PaddingForEdgeRouting = 8D;
            this.gViewerMission.PanButtonPressed = false;
            this.gViewerMission.SaveAsImageEnabled = true;
            this.gViewerMission.SaveAsMsaglEnabled = true;
            this.gViewerMission.SaveButtonVisible = true;
            this.gViewerMission.SaveGraphButtonVisible = true;
            this.gViewerMission.SaveInVectorFormatEnabled = true;
            this.gViewerMission.Size = new System.Drawing.Size(326, 390);
            this.gViewerMission.TabIndex = 12;
            this.gViewerMission.TightOffsetForRouting = 0.125D;
            this.gViewerMission.ToolBarIsVisible = true;
            this.gViewerMission.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewerMission.Transform")));
            this.gViewerMission.UndoRedoButtonsVisible = true;
            this.gViewerMission.WindowZoomButtonPressed = false;
            this.gViewerMission.ZoomF = 1D;
            this.gViewerMission.ZoomWindowThreshold = 0.05D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Node symbol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Node rule number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Rule name:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tBNewRule);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonNewRule);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Location = new System.Drawing.Point(12, 497);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 176);
            this.panel1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(55, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "RULE:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.buttonAddNode);
            this.panel2.Controls.Add(this.buttonDeleteNode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tBNewNode);
            this.panel2.Controls.Add(this.tBNodeNumber);
            this.panel2.Location = new System.Drawing.Point(201, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 175);
            this.panel2.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(54, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "NODE:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lBRules);
            this.panel3.Controls.Add(this.bSaveRules);
            this.panel3.Controls.Add(this.bLoadRules);
            this.panel3.Location = new System.Drawing.Point(385, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(174, 237);
            this.panel3.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Rules list:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(47, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "RULES:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.gViewerMission);
            this.panel4.Location = new System.Drawing.Point(775, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(325, 420);
            this.panel4.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.Location = new System.Drawing.Point(94, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "PRODUCTION:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 693);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonApplyRule);
            this.Controls.Add(this.panelRightGraph);
            this.Controls.Add(this.panelLeftGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLeftGraph.ResumeLayout(false);
            this.panelLeftGraph.PerformLayout();
            this.panelRightGraph.ResumeLayout(false);
            this.panelRightGraph.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GViewer gViewerLeft;
        private GViewer gViewerRight;
        private System.Windows.Forms.Panel panelLeftGraph;
        private System.Windows.Forms.Panel panelRightGraph;
        private System.Windows.Forms.TextBox tBNewNode;
        private System.Windows.Forms.Button buttonAddNode;
        private System.Windows.Forms.Button buttonDeleteNode;
        private System.Windows.Forms.Button buttonNewRule;
        private System.Windows.Forms.TextBox tBNewRule;
        private System.Windows.Forms.ListBox lBRules;
        private System.Windows.Forms.Button buttonClear;
        private GViewer gViewerMission;
        private System.Windows.Forms.TextBox tBNodeNumber;
        private System.Windows.Forms.Button buttonApplyRule;
        private System.Windows.Forms.Button bSaveRules;
        private System.Windows.Forms.Button bLoadRules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
    }
}

