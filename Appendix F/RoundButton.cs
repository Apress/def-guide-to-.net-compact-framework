using System;
//using System.Data;
using System.Drawing;
using System.Windows.Forms;

#if NETCFDESIGNTIME
[assembly: System.CF.Design.RuntimeAssemblyAttribute("DansButtonControl, Version=1.0.100.0, Culture=neutral, PublicKeyToken=null")]
#endif

namespace Apress.Windows.Controls
{
	public class RoundButton : System.Windows.Forms.Control, IDisposable
	{
		bool buttonDrawnDown = false;
		Color _btnColor = Color.LightGreen;
		Color _btnDisabledColor = Color.DarkGreen;

		public RoundButton()
		{
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			Graphics g = this.CreateGraphics();
			DrawButton(g, this.ForeColor, _btnColor);
			g.Dispose();
			base.OnEnabledChanged(e);
		}

		protected override void OnResize(EventArgs ea) 
		{
			this.Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			DrawButton(e.Graphics, this.ForeColor, _btnColor);
			base.OnPaint (e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			try
			{
				if( e.Button == MouseButtons.Left )
				{
					if( (e.X < this.ClientRectangle.Top || e.X > this.ClientRectangle.Width) || (e.Y < this.ClientRectangle.Top || e.Y > this.ClientRectangle.Height) )
					{
						if( buttonDrawnDown )
						{
							Graphics g = this.CreateGraphics();
							DrawButton(g, this.ForeColor, _btnColor);
							g.Dispose();
							buttonDrawnDown = false;
						}
					}
					else
					{
						//	Moving inside the button
						if( !buttonDrawnDown )
						{
							Graphics g = this.CreateGraphics();
							DrawButton(g, Color.White /*this.ForeColor*/, Color.Black);
							g.Dispose();
							buttonDrawnDown = true;
						}
					}
				}
				base.OnMouseMove(e);
			}
			catch
			{
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			try
			{
				Graphics g = this.CreateGraphics();
				DrawButton(g, Color.White, Color.Black);
				g.Dispose();
				buttonDrawnDown = true;
				base.OnMouseDown(e);
			}
			catch
			{
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			try
			{
				Graphics g = this.CreateGraphics();
				Color sb;

				if( this.Enabled )
					sb = _btnColor;
				else
					sb = _btnDisabledColor;

				DrawButton(g, this.ForeColor, _btnColor);
				g.Dispose();
				buttonDrawnDown = false;
				this.Refresh();
				base.OnMouseUp(e);
			}
			catch
			{
			}
		}

		public void DrawButton(Graphics g, Color foreColor, Color backColor)
		{
			//	use the button height as the diameter of the round end
			int bRadius = this.ClientRectangle.Height / 2;
			Brush sb = null;

			sb = new SolidBrush(backColor);

			int aTop = this.ClientRectangle.Top;
			int aLeft = this.ClientRectangle.Left;
			int aWidth = this.ClientRectangle.Width;
			int aHeight = this.ClientRectangle.Height;

			
			g.FillEllipse(sb, aLeft, aTop, 2 * bRadius, 2 * bRadius);
			g.FillRectangle(sb, aLeft + bRadius, aTop, aWidth - (2 * bRadius), aHeight);
			g.FillEllipse(sb, aWidth - (2*bRadius), aTop, 2*bRadius, 2*bRadius);

			//	Now write the text to the button face
			Font fnt = new Font(this.Font.Name, this.Font.Size, this.Font.Style);
			SizeF siz = g.MeasureString(this.Text, fnt);
			g.DrawString(this.Text, fnt, new SolidBrush(foreColor), (aWidth - siz.Width)/2, (aHeight-siz.Height)/2);

			sb.Dispose();
		}

		#region IDisposable Members

		void System.IDisposable.Dispose()
		{
			// TODO:  Add RoundButton.System.IDisposable.Dispose implementation
		}

		#endregion

#if NETCFDESIGNTIME
	[
		System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The color for the Calendar caption font")
	]
#endif
		public Color ButtonColor
		{
			get
			{
				return _btnColor;
			}
			set
			{
				_btnColor = value;
			}
		}

#if NETCFDESIGNTIME
	[
		System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The color for the Calendar caption font")
	]
#endif
		public Color DisabledButtonColor
		{
			get
			{
				return _btnDisabledColor;
			}
			set
			{
				_btnDisabledColor = value;
			}
		}
	}
}
