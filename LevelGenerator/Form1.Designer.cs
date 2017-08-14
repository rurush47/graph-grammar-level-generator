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
            this.gViewerLeft = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.gViewerRight = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.panelLeftGraph = new System.Windows.Forms.Panel();
            this.panelRightGraph = new System.Windows.Forms.Panel();
            this.tBNewNode = new System.Windows.Forms.TextBox();
            this.buttonAddNode = new System.Windows.Forms.Button();
            this.buttonDeleteNode = new System.Windows.Forms.Button();
            this.buttonNewRule = new System.Windows.Forms.Button();
            this.tBNewRule = new System.Windows.Forms.TextBox();
            this.lBRules = new System.Windows.Forms.ListBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelLeftGraph.SuspendLayout();
            this.panelRightGraph.SuspendLayout();
            this.SuspendLayout();
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
            this.gViewerLeft.Location = new System.Drawing.Point(-1, -1);
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
            this.gViewerLeft.Size = new System.Drawing.Size(354, 237);
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
            this.gViewerRight.Location = new System.Drawing.Point(-2, -1);
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
            this.gViewerRight.Size = new System.Drawing.Size(357, 236);
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
            // panelLeftGraph
            // 
            this.panelLeftGraph.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeftGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftGraph.Controls.Add(this.gViewerLeft);
            this.panelLeftGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.panelLeftGraph.Location = new System.Drawing.Point(12, 12);
            this.panelLeftGraph.Name = "panelLeftGraph";
            this.panelLeftGraph.Size = new System.Drawing.Size(354, 237);
            this.panelLeftGraph.TabIndex = 3;
            // 
            // panelRightGraph
            // 
            this.panelRightGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightGraph.Controls.Add(this.gViewerRight);
            this.panelRightGraph.Location = new System.Drawing.Point(373, 13);
            this.panelRightGraph.Name = "panelRightGraph";
            this.panelRightGraph.Size = new System.Drawing.Size(356, 236);
            this.panelRightGraph.TabIndex = 4;
            // 
            // tBNewNode
            // 
            this.tBNewNode.Location = new System.Drawing.Point(14, 368);
            this.tBNewNode.Name = "tBNewNode";
            this.tBNewNode.Size = new System.Drawing.Size(100, 20);
            this.tBNewNode.TabIndex = 5;
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Location = new System.Drawing.Point(118, 369);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(75, 20);
            this.buttonAddNode.TabIndex = 6;
            this.buttonAddNode.Text = "Add node";
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // buttonDeleteNode
            // 
            this.buttonDeleteNode.Location = new System.Drawing.Point(14, 339);
            this.buttonDeleteNode.Name = "buttonDeleteNode";
            this.buttonDeleteNode.Size = new System.Drawing.Size(180, 23);
            this.buttonDeleteNode.TabIndex = 7;
            this.buttonDeleteNode.Text = "Delete node";
            this.buttonDeleteNode.UseVisualStyleBackColor = true;
            this.buttonDeleteNode.Click += new System.EventHandler(this.buttonDeleteNode_Click);
            // 
            // buttonNewRule
            // 
            this.buttonNewRule.Location = new System.Drawing.Point(13, 255);
            this.buttonNewRule.Name = "buttonNewRule";
            this.buttonNewRule.Size = new System.Drawing.Size(181, 23);
            this.buttonNewRule.TabIndex = 8;
            this.buttonNewRule.Text = "New rule";
            this.buttonNewRule.UseVisualStyleBackColor = true;
            this.buttonNewRule.Click += new System.EventHandler(this.buttonNewRule_Click);
            // 
            // tBNewRule
            // 
            this.tBNewRule.Location = new System.Drawing.Point(14, 284);
            this.tBNewRule.Name = "tBNewRule";
            this.tBNewRule.Size = new System.Drawing.Size(179, 20);
            this.tBNewRule.TabIndex = 9;
            // 
            // lBRules
            // 
            this.lBRules.FormattingEnabled = true;
            this.lBRules.Location = new System.Drawing.Point(200, 255);
            this.lBRules.Name = "lBRules";
            this.lBRules.Size = new System.Drawing.Size(167, 108);
            this.lBRules.TabIndex = 10;
            this.lBRules.SelectedIndexChanged += new System.EventHandler(this.lBRules_SelectedIndexChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(14, 310);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(181, 23);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 646);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.lBRules);
            this.Controls.Add(this.tBNewRule);
            this.Controls.Add(this.buttonNewRule);
            this.Controls.Add(this.buttonDeleteNode);
            this.Controls.Add(this.buttonAddNode);
            this.Controls.Add(this.tBNewNode);
            this.Controls.Add(this.panelRightGraph);
            this.Controls.Add(this.panelLeftGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLeftGraph.ResumeLayout(false);
            this.panelRightGraph.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

