﻿namespace NecrodancerGenerator
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
            this.buttonLoadRooms = new System.Windows.Forms.Button();
            this.lbRooms = new System.Windows.Forms.ListBox();
            this.buttonSaveDungeon = new System.Windows.Forms.Button();
            this.bLoadGraph = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLoadRooms
            // 
            this.buttonLoadRooms.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadRooms.Name = "buttonLoadRooms";
            this.buttonLoadRooms.Size = new System.Drawing.Size(98, 23);
            this.buttonLoadRooms.TabIndex = 0;
            this.buttonLoadRooms.Text = "Load rooms";
            this.buttonLoadRooms.UseVisualStyleBackColor = true;
            this.buttonLoadRooms.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbRooms
            // 
            this.lbRooms.FormattingEnabled = true;
            this.lbRooms.Location = new System.Drawing.Point(164, 12);
            this.lbRooms.Name = "lbRooms";
            this.lbRooms.Size = new System.Drawing.Size(120, 95);
            this.lbRooms.TabIndex = 1;
            // 
            // buttonSaveDungeon
            // 
            this.buttonSaveDungeon.Location = new System.Drawing.Point(12, 41);
            this.buttonSaveDungeon.Name = "buttonSaveDungeon";
            this.buttonSaveDungeon.Size = new System.Drawing.Size(98, 23);
            this.buttonSaveDungeon.TabIndex = 2;
            this.buttonSaveDungeon.Text = "Save dungeon";
            this.buttonSaveDungeon.UseVisualStyleBackColor = true;
            this.buttonSaveDungeon.Click += new System.EventHandler(this.buttonSaveDungeon_Click);
            // 
            // bLoadGraph
            // 
            this.bLoadGraph.Location = new System.Drawing.Point(13, 71);
            this.bLoadGraph.Name = "bLoadGraph";
            this.bLoadGraph.Size = new System.Drawing.Size(97, 23);
            this.bLoadGraph.TabIndex = 3;
            this.bLoadGraph.Text = "Load graph";
            this.bLoadGraph.UseVisualStyleBackColor = true;
            this.bLoadGraph.Click += new System.EventHandler(this.bLoadGraph_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 324);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bLoadGraph);
            this.Controls.Add(this.buttonSaveDungeon);
            this.Controls.Add(this.lbRooms);
            this.Controls.Add(this.buttonLoadRooms);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadRooms;
        private System.Windows.Forms.ListBox lbRooms;
        private System.Windows.Forms.Button buttonSaveDungeon;
        private System.Windows.Forms.Button bLoadGraph;
        private System.Windows.Forms.Button button1;
    }
}

