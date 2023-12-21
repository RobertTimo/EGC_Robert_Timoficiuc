using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Drawing;

namespace OpenTK_immediate_mode
{
    class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private readonly Axes ax;
        private readonly Cube cube;

        // DEFAULTS
        private readonly Color DEFAULT_BKG_COLOR = Color.FromArgb(49, 50, 51);
        private Vector3 eye = new Vector3(200, 200, 200);
        private Vector3 target = new Vector3(0, 0, 0);
        private Vector3 up_vector = new Vector3(0, 1, 0);
        private Random random = new Random();

        public Window3D() : base(800, 800, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            Title = "Timoficiuc Robert-Mihai. grupa 3133A";

            // inits
            ax = new Axes();
            cube = new Cube();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // set background
            GL.ClearColor(DEFAULT_BKG_COLOR);

            // set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 512);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // set the eye
            Matrix4 camera = Matrix4.LookAt(eye, target, up_vector);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // LOGIC CODE
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.W])
            {
                cube.MoveUp();
            }

            if (currentKeyboard[Key.S])
            {
                cube.MoveDown();
            }

            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                ChangeBgColor(random);
            }

            if (currentKeyboard[Key.C] && !previousKeyboard[Key.C])
            {
                cube.ChangeComposition();
            }

            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                cube.ToggleVisibility();
            }

            if (currentKeyboard[Key.Z] && !previousKeyboard[Key.Z])
            {
                cube.ToggleVisibility1();
            }

            if (currentKeyboard[Key.X] && !previousKeyboard[Key.X])
            {
                cube.ToggleVisibility2();
            }

            if (currentKeyboard[Key.N] && !previousKeyboard[Key.N])
            {
                cube.ToggleVisibility3();
            }

            if (currentKeyboard[Key.M] && !previousKeyboard[Key.M])
            {
                cube.ToggleVisibility4();
            }

            previousKeyboard = currentKeyboard;
            previousMouse = currentMouse;
            // END logic code
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // RENDER AXES
            ax.Draw();

            // RENDER CUBE
            cube.Draw();


            // END render code

            SwapBuffers();
        }

        private void ChangeBgColor(Random random)
        {
            GL.ClearColor(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 225)));
        }
    }
}