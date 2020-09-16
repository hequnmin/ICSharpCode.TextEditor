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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculator));
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.toolbarContainer = new System.Windows.Forms.ToolStripContainer();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnValidate = new System.Windows.Forms.ToolStripButton();
            this.btnEvaldate = new System.Windows.Forms.ToolStripButton();
            this.Panels = new System.Windows.Forms.SplitContainer();
            this.tvwFunction = new System.Windows.Forms.TreeView();
            this.Panels2 = new System.Windows.Forms.SplitContainer();
            this.txtEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.toolbarContainer.ContentPanel.SuspendLayout();
            this.toolbarContainer.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panels)).BeginInit();
            this.Panels.Panel1.SuspendLayout();
            this.Panels.Panel2.SuspendLayout();
            this.Panels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Panels2)).BeginInit();
            this.Panels2.Panel1.SuspendLayout();
            this.Panels2.Panel2.SuspendLayout();
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
            // toolbarContainer
            // 
            // 
            // toolbarContainer.ContentPanel
            // 
            this.toolbarContainer.ContentPanel.Controls.Add(this.toolbar);
            this.toolbarContainer.ContentPanel.Size = new System.Drawing.Size(898, 40);
            this.toolbarContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarContainer.Location = new System.Drawing.Point(0, 0);
            this.toolbarContainer.Name = "toolbarContainer";
            this.toolbarContainer.Size = new System.Drawing.Size(898, 40);
            this.toolbarContainer.TabIndex = 6;
            this.toolbarContainer.Text = "toolStripContainer1";
            this.toolbarContainer.TopToolStripPanelVisible = false;
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnValidate,
            this.toolStripSeparator1,
            this.btnEvaldate,
            this.toolStripSeparator2});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(898, 40);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // btnValidate
            // 
            this.btnValidate.AutoSize = false;
            this.btnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnValidate.Image = ((System.Drawing.Image)(resources.GetObject("btnValidate.Image")));
            this.btnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(80, 37);
            this.btnValidate.Text = "验证";
            this.btnValidate.ToolTipText = "验证公式或表达式的语法合法性";
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnEvaldate
            // 
            this.btnEvaldate.AutoSize = false;
            this.btnEvaldate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEvaldate.Image = ((System.Drawing.Image)(resources.GetObject("btnEvaldate.Image")));
            this.btnEvaldate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEvaldate.Name = "btnEvaldate";
            this.btnEvaldate.Size = new System.Drawing.Size(80, 37);
            this.btnEvaldate.Text = "运算";
            this.btnEvaldate.ToolTipText = "对公式或表达式进行运算";
            this.btnEvaldate.Click += new System.EventHandler(this.btnEvaldate_Click);
            // 
            // Panels
            // 
            this.Panels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panels.Location = new System.Drawing.Point(0, 40);
            this.Panels.Margin = new System.Windows.Forms.Padding(0);
            this.Panels.Name = "Panels";
            // 
            // Panels.Panel1
            // 
            this.Panels.Panel1.Controls.Add(this.tvwFunction);
            // 
            // Panels.Panel2
            // 
            this.Panels.Panel2.Controls.Add(this.Panels2);
            this.Panels.Size = new System.Drawing.Size(898, 469);
            this.Panels.SplitterDistance = 299;
            this.Panels.TabIndex = 7;
            // 
            // tvwFunction
            // 
            this.tvwFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwFunction.Location = new System.Drawing.Point(0, 0);
            this.tvwFunction.Name = "tvwFunction";
            this.tvwFunction.Size = new System.Drawing.Size(299, 469);
            this.tvwFunction.TabIndex = 0;
            // 
            // Panels2
            // 
            this.Panels2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panels2.Location = new System.Drawing.Point(0, 0);
            this.Panels2.Name = "Panels2";
            this.Panels2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Panels2.Panel1
            // 
            this.Panels2.Panel1.Controls.Add(this.txtEditor);
            // 
            // Panels2.Panel2
            // 
            this.Panels2.Panel2.Controls.Add(this.txtResult);
            this.Panels2.Size = new System.Drawing.Size(595, 469);
            this.Panels2.SplitterDistance = 339;
            this.Panels2.TabIndex = 0;
            // 
            // txtEditor
            // 
            this.txtEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditor.IsReadOnly = false;
            this.txtEditor.Location = new System.Drawing.Point(0, 0);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(595, 339);
            this.txtEditor.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(595, 126);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // frmCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 509);
            this.Controls.Add(this.Panels);
            this.Controls.Add(this.toolbarContainer);
            this.Controls.Add(this.btnEvaluate);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCalculator";
            this.Text = "公式调试器";
            this.Load += new System.EventHandler(this.frmCalculator_Load);
            this.toolbarContainer.ContentPanel.ResumeLayout(false);
            this.toolbarContainer.ContentPanel.PerformLayout();
            this.toolbarContainer.ResumeLayout(false);
            this.toolbarContainer.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.Panels.Panel1.ResumeLayout(false);
            this.Panels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Panels)).EndInit();
            this.Panels.ResumeLayout(false);
            this.Panels2.Panel1.ResumeLayout(false);
            this.Panels2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Panels2)).EndInit();
            this.Panels2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.ToolStripContainer toolbarContainer;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnValidate;
        private System.Windows.Forms.ToolStripButton btnEvaldate;
        private System.Windows.Forms.SplitContainer Panels;
        private System.Windows.Forms.TreeView tvwFunction;
        private System.Windows.Forms.SplitContainer Panels2;
        private ICSharpCode.TextEditor.TextEditorControl txtEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.RichTextBox txtResult;
    }
}