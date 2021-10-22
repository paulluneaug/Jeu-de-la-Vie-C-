using System;
using System.Windows.Forms;
using System.Drawing;

namespace Jeu_de_la_Vie_Graphique
{
    partial class Form1
    {
        public int cellSize;
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent(int n)
        {
            int parametersXOffset = 10;

            this.CanvasBox = new System.Windows.Forms.PictureBox();
            this.PlayBox = new System.Windows.Forms.CheckBox();
            this.ParametersBox = new System.Windows.Forms.GroupBox();
            this.ProbaAlive = new System.Windows.Forms.NumericUpDown();
            this.ProbaAliveLab = new System.Windows.Forms.Label();
            this.RandCellButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasBox)).BeginInit();
            this.ParametersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CanvasBox
            // 
            this.CanvasBox.Location = new System.Drawing.Point(0, 0);
            this.CanvasBox.Name = "CanvasBox";
            this.CanvasBox.Size = new System.Drawing.Size(5 * n, 5 * n);
            this.CanvasBox.TabIndex = 0;
            this.CanvasBox.TabStop = false;
            this.CanvasBox.BackColor = Color.Black;
            this.CanvasBox.MouseClick += new MouseEventHandler(CanvasBox_Click);
            this.CanvasBox.MouseMove += new MouseEventHandler(CanvasBox_Move);
            this.CanvasBox.Paint += new PaintEventHandler(CanvasBox_Paint);
            // 
            // PlayBox
            // 
            this.PlayBox.AutoSize = true;
            this.PlayBox.Location = new System.Drawing.Point(parametersXOffset, 20);
            this.PlayBox.Name = "Play";
            this.PlayBox.Size = new System.Drawing.Size(80, 20);
            this.PlayBox.TabIndex = 1;
            this.PlayBox.Text = "Play";
            this.PlayBox.UseVisualStyleBackColor = true;
            this.PlayBox.CheckedChanged += new System.EventHandler(this.PlayBox_CheckedChanged);
            // 
            // ProbaAlive
            // 
            this.ProbaAlive.Location = new System.Drawing.Point(parametersXOffset, 60);
            this.ProbaAlive.Name = "ProbaAlive";
            this.ProbaAlive.Size = new System.Drawing.Size(50, 22);
            this.ProbaAlive.TabIndex = 10;
            // 
            // ProbaAliveLab
            // 
            this.ProbaAliveLab.AutoSize = true;
            this.ProbaAliveLab.Location = new System.Drawing.Point(parametersXOffset + 50, 63);
            this.ProbaAliveLab.Name = "ProbaAliveLab";
            this.ProbaAliveLab.Size = new System.Drawing.Size(35, 13);
            this.ProbaAliveLab.TabIndex = 11;
            this.ProbaAliveLab.Text = "% Probability for a cell to be alive";
            // 
            // RandCellButton
            // 
            this.RandCellButton.Location = new System.Drawing.Point(parametersXOffset, 90);
            this.RandCellButton.Name = "RandCellButton";
            this.RandCellButton.Size = new System.Drawing.Size(200, 20);
            this.RandCellButton.TabIndex = 6;
            this.RandCellButton.Text = "Place random cells";
            this.RandCellButton.UseVisualStyleBackColor = true;
            this.RandCellButton.Click += new System.EventHandler(this.RandCellButton_Click);
            // 
            // ParametersBox
            // 
            this.ParametersBox.Controls.Add(this.PlayBox);
            this.ParametersBox.Controls.Add(this.ProbaAlive);
            this.ParametersBox.Controls.Add(this.ProbaAliveLab);
            this.ParametersBox.Controls.Add(this.RandCellButton);
            this.ParametersBox.Location = new System.Drawing.Point(5 * n + 5, 0);
            this.ParametersBox.Name = "ParametersBox";
            this.ParametersBox.Size = new System.Drawing.Size(250, 5 * n);
            this.ParametersBox.TabIndex = 2;
            this.ParametersBox.TabStop = false;
            this.ParametersBox.Text = "Parameters";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(5 * n + 255, 5 * n);
            this.Controls.Add(this.ParametersBox);
            this.Controls.Add(this.CanvasBox);
            this.Name = "Form1";
            this.Text = "Jeu de la Vie";
            ((System.ComponentModel.ISupportInitialize)(this.CanvasBox)).EndInit();
            this.ParametersBox.ResumeLayout(false);
            this.ParametersBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox PlayBox;
        private GroupBox ParametersBox;
        private PictureBox CanvasBox;
        private Button RandCellButton;
        private System.Windows.Forms.NumericUpDown ProbaAlive;
        private System.Windows.Forms.Label ProbaAliveLab;
    }
}

