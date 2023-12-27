namespace Databaseproject
{
	partial class Default_List
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Default_List));
			this.SidePanel = new Guna.UI.WinForms.GunaGradient2Panel();
			this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
			this.HomeBtn = new Guna.UI.WinForms.GunaGradientButton();
			this.MessBtn = new Guna.UI.WinForms.GunaGradientButton();
			this.SidePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// SidePanel
			// 
			this.SidePanel.BackColor = System.Drawing.Color.Transparent;
			this.SidePanel.Controls.Add(this.gunaLabel4);
			this.SidePanel.Controls.Add(this.HomeBtn);
			this.SidePanel.Controls.Add(this.MessBtn);
			this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.SidePanel.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(156)))));
			this.SidePanel.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
			this.SidePanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.SidePanel.Location = new System.Drawing.Point(0, 0);
			this.SidePanel.Name = "SidePanel";
			this.SidePanel.Size = new System.Drawing.Size(2276, 979);
			this.SidePanel.TabIndex = 40;
			// 
			// gunaLabel4
			// 
			this.gunaLabel4.AutoSize = true;
			this.gunaLabel4.BackColor = System.Drawing.Color.Transparent;
			this.gunaLabel4.Font = new System.Drawing.Font("Ubuntu", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gunaLabel4.ForeColor = System.Drawing.Color.White;
			this.gunaLabel4.Location = new System.Drawing.Point(745, 89);
			this.gunaLabel4.Name = "gunaLabel4";
			this.gunaLabel4.Size = new System.Drawing.Size(205, 41);
			this.gunaLabel4.TabIndex = 45;
			this.gunaLabel4.Text = "Default List";
			// 
			// HomeBtn
			// 
			this.HomeBtn.AnimationHoverSpeed = 0.07F;
			this.HomeBtn.AnimationSpeed = 0.03F;
			this.HomeBtn.BackColor = System.Drawing.Color.Transparent;
			this.HomeBtn.BaseColor1 = System.Drawing.Color.MintCream;
			this.HomeBtn.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
			this.HomeBtn.BorderColor = System.Drawing.Color.Black;
			this.HomeBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.HomeBtn.FocusedColor = System.Drawing.Color.Empty;
			this.HomeBtn.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HomeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
			this.HomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("HomeBtn.Image")));
			this.HomeBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.HomeBtn.ImageSize = new System.Drawing.Size(35, 35);
			this.HomeBtn.Location = new System.Drawing.Point(1144, 784);
			this.HomeBtn.Name = "HomeBtn";
			this.HomeBtn.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
			this.HomeBtn.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
			this.HomeBtn.OnHoverBorderColor = System.Drawing.Color.Black;
			this.HomeBtn.OnHoverForeColor = System.Drawing.Color.White;
			this.HomeBtn.OnHoverImage = null;
			this.HomeBtn.OnPressedColor = System.Drawing.Color.Black;
			this.HomeBtn.Radius = 20;
			this.HomeBtn.Size = new System.Drawing.Size(198, 50);
			this.HomeBtn.TabIndex = 44;
			this.HomeBtn.Text = "Home";
			this.HomeBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
			// 
			// MessBtn
			// 
			this.MessBtn.AnimationHoverSpeed = 0.07F;
			this.MessBtn.AnimationSpeed = 0.03F;
			this.MessBtn.BackColor = System.Drawing.Color.Transparent;
			this.MessBtn.BaseColor1 = System.Drawing.Color.MintCream;
			this.MessBtn.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
			this.MessBtn.BorderColor = System.Drawing.Color.Black;
			this.MessBtn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.MessBtn.FocusedColor = System.Drawing.Color.Empty;
			this.MessBtn.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MessBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
			this.MessBtn.Image = ((System.Drawing.Image)(resources.GetObject("MessBtn.Image")));
			this.MessBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.MessBtn.ImageSize = new System.Drawing.Size(35, 35);
			this.MessBtn.Location = new System.Drawing.Point(465, 784);
			this.MessBtn.Name = "MessBtn";
			this.MessBtn.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
			this.MessBtn.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
			this.MessBtn.OnHoverBorderColor = System.Drawing.Color.Black;
			this.MessBtn.OnHoverForeColor = System.Drawing.Color.White;
			this.MessBtn.OnHoverImage = null;
			this.MessBtn.OnPressedColor = System.Drawing.Color.Black;
			this.MessBtn.Radius = 20;
			this.MessBtn.Size = new System.Drawing.Size(198, 50);
			this.MessBtn.TabIndex = 37;
			this.MessBtn.Text = "Mess Page";
			this.MessBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.MessBtn.Click += new System.EventHandler(this.MessBtn_Click);
			// 
			// Default_List
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 979);
			this.Controls.Add(this.SidePanel);
			this.Name = "Default_List";
			this.Text = "Default_List";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.SidePanel.ResumeLayout(false);
			this.SidePanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI.WinForms.GunaGradient2Panel SidePanel;
		private Guna.UI.WinForms.GunaLabel gunaLabel4;
		private Guna.UI.WinForms.GunaGradientButton HomeBtn;
		private Guna.UI.WinForms.GunaGradientButton MessBtn;
	}
}