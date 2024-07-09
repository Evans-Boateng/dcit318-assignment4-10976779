using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint = Point.Empty; // Store the last point for drawing lines
        private Bitmap canvasBitmap; // Bitmap to store the drawings
        private Graphics canvasGraphics;
        public Form1()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            // Initialize the bitmap and graphics object
            canvasBitmap = new Bitmap(panelCanvas.Width, panelCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White); // Set the initial background to white
            panelCanvas.BackgroundImage = canvasBitmap; // Set the panel's background to the bitmap
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }
        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (lastPoint != Point.Empty)
                {
                    canvasGraphics.DrawLine(Pens.Black, lastPoint, e.Location);
                    lastPoint = e.Location;
                    panelCanvas.Invalidate(); // Refresh the panel to show the new drawing
                }
            }
        }
        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                lastPoint = Point.Empty;
            }
        }
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
