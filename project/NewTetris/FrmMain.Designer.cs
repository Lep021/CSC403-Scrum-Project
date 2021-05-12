namespace NewTetris {
  partial class FrmMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.lblPlayingField = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblLevel = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.grpNextBlock = new System.Windows.Forms.GroupBox();
      this.tmrCurrentPieceFall = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // lblPlayingField
      // 
      this.lblPlayingField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.lblPlayingField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblPlayingField.Location = new System.Drawing.Point(397, 89);
      this.lblPlayingField.Name = "lblPlayingField";
      this.lblPlayingField.Size = new System.Drawing.Size(450, 660);
      this.lblPlayingField.TabIndex = 7;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label2.Location = new System.Drawing.Point(48, 165);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(76, 25);
      this.label2.TabIndex = 8;
      this.label2.Text = "Score:";
      // 
      // lblLevel
      // 
      this.lblLevel.AutoSize = true;
      this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLevel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            //Alter Value Here
      this.lblLevel.Location = new System.Drawing.Point(48, 140);
      this.lblLevel.Name = "lblLevel";
      this.lblLevel.Size = new System.Drawing.Size(42, 25);
      this.lblLevel.TabIndex = 10;
      this.lblLevel.Text = "Level:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label3.Location = new System.Drawing.Point(48, 231);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(132, 25);
      this.label3.TabIndex = 11;
      this.label3.Text = "Next Block:";
      // 
      // grpNextBlock
      // 
      this.grpNextBlock.BackColor = System.Drawing.Color.DimGray;
      this.grpNextBlock.Location = new System.Drawing.Point(186, 231);
      this.grpNextBlock.Name = "grpNextBlock";
      this.grpNextBlock.Size = new System.Drawing.Size(120, 120);
      this.grpNextBlock.TabIndex = 13;
      this.grpNextBlock.TabStop = false;
      // 
      // tmrCurrentPieceFall
      // 
      this.tmrCurrentPieceFall.Enabled = true;
      this.tmrCurrentPieceFall.Interval = 500;
      this.tmrCurrentPieceFall.Tick += new System.EventHandler(this.tmrCurrentPieceFall_Tick);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(1183, 803);
      this.Controls.Add(this.grpNextBlock);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lblLevel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lblPlayingField);
      this.Name = "FrmMain";
      this.Text = "Form1";
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblPlayingField;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblLevel;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox grpNextBlock;
    private System.Windows.Forms.Timer tmrCurrentPieceFall;
    }
}
