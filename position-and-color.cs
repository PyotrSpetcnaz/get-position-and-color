using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Bot
{
	class Program
	{
		#region DLL
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hDC, int x, int y);

        #endregion

		static void Main(string[] args)
		{
			IntPtr hDC = GetDC(IntPtr.Zero);
			uint pixelColor;
			uint oldColor = GetPixel(hDC, 0, 0);
			Point oldPosition = Cursor.Position;

			while (true)
			{
				if ((oldPosition != Cursor.Position) || (oldColor != GetPixel(hDC, Cursor.Position.X, Cursor.Position.Y)))
				{
					oldPosition = Cursor.Position;	
					oldColor = GetPixel(hDC, Cursor.Position.X, Cursor.Position.Y);
					Console.Clear();
					Console.WriteLine("Position: " + Cursor.Position.X + ":" + Cursor.Position.Y);
					pixelColor = GetPixel(hDC, Cursor.Position.X, Cursor.Position.Y);
					Console.WriteLine("Color: " + pixelColor);
				}
			}

		}

	}
}