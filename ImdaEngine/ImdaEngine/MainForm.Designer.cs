/*
By InnieSharp(ix4/i#)
*/
namespace ImdaEngine
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.PictureBox player;
		public System.Windows.Forms.Timer move;
		public System.Windows.Forms.Timer pos;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.player = new System.Windows.Forms.PictureBox();
			this.move = new System.Windows.Forms.Timer(this.components);
			this.pos = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
			this.SuspendLayout();
			// 
			// player
			// 
			this.player.Location = new System.Drawing.Point(188, 151);
			this.player.Name = "player";
			this.player.Size = new System.Drawing.Size(100, 50);
			this.player.TabIndex = 0;
			this.player.TabStop = false;
			// 
			// pos
			// 
			this.pos.Enabled = true;
			this.pos.Tick += new System.EventHandler(this.PosTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 342);
			this.Controls.Add(this.player);
			this.Name = "MainForm";
			this.Text = "ImdaEngine";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
