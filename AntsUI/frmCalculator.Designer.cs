namespace Example
{
    partial class frmCalculator
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
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.tvwFunction = new System.Windows.Forms.TreeView();
            this.Panels = new System.Windows.Forms.SplitContainer();
            this.Panels2 = new System.Windows.Forms.SplitContainer();
            this.txtEditor = new ICSharpCode.TextEditor.TextEditorControl();
            ((System.ComponentModel.ISupportInitialize)(this.Panels)).BeginInit();
            this.Panels.Panel1.SuspendLayout();
            this.Panels.Panel2.SuspendLayout();
            this.Panels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panels2)).BeginInit();
            this.Panels2.Panel1.SuspendLayout();
            this.Panels2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(818, 121);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(82, 30);
            this.btnEvaluate.TabIndex = 2;
            this.btnEvaluate.Text = "计算";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            // 
            // tvwFunction
            // 
            this.tvwFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwFunction.Location = new System.Drawing.Point(5, 5);
            this.tvwFunction.Name = "tvwFunction";
            this.tvwFunction.Size = new System.Drawing.Size(289, 499);
            this.tvwFunction.TabIndex = 0;
            // 
            // Panels
            // 
            this.Panels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panels.Location = new System.Drawing.Point(0, 0);
            this.Panels.Name = "Panels";
            // 
            // Panels.Panel1
            // 
            this.Panels.Panel1.Controls.Add(this.tvwFunction);
            this.Panels.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // Panels.Panel2
            // 
            this.Panels.Panel2.Controls.Add(this.Panels2);
            this.Panels.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.Panels.Size = new System.Drawing.Size(898, 509);
            this.Panels.SplitterDistance = 299;
            this.Panels.TabIndex = 5;
            // 
            // Panels2
            // 
            this.Panels2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panels2.Location = new System.Drawing.Point(5, 5);
            this.Panels2.Name = "Panels2";
            this.Panels2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Panels2.Panel1
            // 
            this.Panels2.Panel1.Controls.Add(this.txtEditor);
            this.Panels2.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // Panels2.Panel2
            // 
            this.Panels2.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.Panels2.Size = new System.Drawing.Size(585, 499);
            this.Panels2.SplitterDistance = 361;
            this.Panels2.TabIndex = 0;
            // 
            // txtEditor
            // 
            this.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditor.IsReadOnly = false;
            this.txtEditor.Location = new System.Drawing.Point(5, 5);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(575, 351);
            this.txtEditor.TabIndex = 0;
            // 
            // frmCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 509);
            this.Controls.Add(this.Panels);
            this.Controls.Add(this.btnEvaluate);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCalculator";
            this.Text = "公式调试器";
            this.Load += new System.EventHandler(this.frmCalculator_Load);
            this.Panels.Panel1.ResumeLayout(false);
            this.Panels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Panels)).EndInit();
            this.Panels.ResumeLayout(false);
            this.Panels2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Panels2)).EndInit();
            this.Panels2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.TreeView tvwFunction;
        private System.Windows.Forms.SplitContainer Panels;
        private System.Windows.Forms.SplitContainer Panels2;
        private ICSharpCode.TextEditor.TextEditorControl txtEditor;
    }
}