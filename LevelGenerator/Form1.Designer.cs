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
            this.gViewerLeft.Location = new System.Drawing.Point(12, 12);
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
            this.gViewerLeft.Size = new System.Drawing.Size(340, 284);
            this.gViewerLeft.TabIndex = 0;
            this.gViewerLeft.TightOffsetForRouting = 0.125D;
            this.gViewerLeft.ToolBarIsVisible = true;
            this.gViewerLeft.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewerLeft.Transform")));
            this.gViewerLeft.UndoRedoButtonsVisible = true;
            this.gViewerLeft.WindowZoomButtonPressed = false;
            this.gViewerLeft.ZoomF = 1D;
            this.gViewerLeft.ZoomWindowThreshold = 0.05D;
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
            this.gViewerRight.Location = new System.Drawing.Point(358, 12);
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
            this.gViewerRight.Size = new System.Drawing.Size(335, 272);
            this.gViewerRight.TabIndex = 1;
            this.gViewerRight.TightOffsetForRouting = 0.125D;
            this.gViewerRight.ToolBarIsVisible = true;
            this.gViewerRight.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewerRight.Transform")));
            this.gViewerRight.UndoRedoButtonsVisible = true;
            this.gViewerRight.WindowZoomButtonPressed = false;
            this.gViewerRight.ZoomF = 1D;
            this.gViewerRight.ZoomWindowThreshold = 0.05D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 646);
            this.Controls.Add(this.gViewerRight);
            this.Controls.Add(this.gViewerLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GViewer gViewerLeft;
        private GViewer gViewerRight;
    }
}

