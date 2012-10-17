using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpGL;

namespace SimpleDrawingSample
{
    public partial class FormSimpleDrawingSample : Form
    {
        public FormSimpleDrawingSample()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://nehe.gamedev.net");
        }

        private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Flush();

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer

            gl.Viewport(0, 0, openGLControl1.Bounds.Width, openGLControl1.Bounds.Height);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            //gl.Ortho(-1, 1, -1, 1, -30, 30);
            gl.Frustum(-1, 1, -1, 1, 1, 10);
            //gl.Ortho(0, openGLControl1.Bounds.Width, 0, openGLControl1.Bounds.Height, -100, 1);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

            

            gl.Translate(0, 0, -5f);
            //gl.Rotate(10, 0, 0, 0);

            float scaleVal = 5.0f;
            gl.Scale(scaleVal, scaleVal, scaleVal);

            gl.PushMatrix();
            gl.Rotate(0, rtri, 0);
            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(-1, -1, 0);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1, 1, 0);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1, 1, 0);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(-1, -1, 0);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1, -1, 0);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1, 1, 0);
            
            gl.End();
            gl.PopMatrix();

            rtri -= 3;
        }


        /*
        private void openGLControl1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //  Get the OpenGL object, just to clean up the code.
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Flush();

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer

            gl.Disable( OpenGL.GL_LIGHTING);
            gl.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);
            gl.Enable(OpenGL.GL_LINE_SMOOTH);
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            gl.Viewport(0, 0, openGLControl1.Bounds.Width, openGLControl1.Bounds.Height);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Ortho(0, 0, 1, 1, -1, 1);
            //gl.Ortho(0, openGLControl1.Bounds.Width, 0, openGLControl1.Bounds.Height, -100, 1);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

            

            gl.Color(1.0f, 0.0f, 1.0f);


            //gl.Translate(0, 0, -0.1f);
            //
            //gl.PixelZoom(1.0f, 1.0f);
            
            float divider = 1.0f;// 2000.0f;
            
            //gl.Rotate(0, 0.1f, 0);
            

            Rectangle controlBounds = this.openGLControl1.Bounds;
            //Rectangle controlBounds = new Rectangle(0, 0, 1, 1);

            
            gl.Rotate(0.0f, rrect, 0.0f);
            gl.Translate(0, 0, -0f);
            //float scale = 0.0002f;
            //gl.Scale(scale, scale, scale);
            //gl.Translate(controlBounds.Width / 2, controlBounds.Height / 2, 0);
            gl.Rect(-controlBounds.Width / divider, -controlBounds.Height/divider, controlBounds.Width / divider, controlBounds.Height / divider);
            rrect -= 1.0f;

            
                 
            
            rtri += 3.0f;// 0.2f;						// Increase The Rotation Variable For The Triangle 
            rquad -= 3.0f;// 0.15f;						// Decrease The Rotation Variable For The Quad 

           
        }
        */

        float rtri = 0;
        float rquad = 0;
        float rrect = 0;
    }
}