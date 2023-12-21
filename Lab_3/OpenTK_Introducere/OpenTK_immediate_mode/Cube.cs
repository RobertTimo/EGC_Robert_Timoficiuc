
using OpenTK;
using OpenTK.Graphics.OpenGL;

using System.Collections.Generic;
using System.Drawing;
using System.Drawing;

namespace OpenTK_immediate_mode
{
    public class Cube
    {
        private bool myVisibility;

        private bool hideFace1;
        private bool hideFace2;
        private bool hideFace3;
        private bool hideFace4;

        private readonly int changeY = 1;

        private PolygonMode myPolygonMode;

        private Color colorBaseCube = Color.Azure;
        private Color colorFaceCube1 = Color.BurlyWood;
        private Color colorFaceCube2 = Color.Salmon;
        private Color colorFaceCube3 = Color.Maroon;
        private Color colorFaceCube4 = Color.Plum;

        private List<Vector3> baseList = new List<Vector3>
        {
            new Vector3(30,0,-30),
            new Vector3(30,0,30),
            new Vector3(-30,0,30),
            new Vector3(-30,0,-30),

            new Vector3(30,60,-30),
            new Vector3(30,60,30),
            new Vector3(-30,60,30),
            new Vector3(-30,60,-30)

        };

        public Cube()
        {
            myVisibility = true;

            hideFace1 = true;
            hideFace2 = true;
            hideFace3 = true;
            hideFace4 = true;

            myPolygonMode = PolygonMode.Fill;
        }

        public void Draw()
        {
            if (myVisibility)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, myPolygonMode);

                GL.Begin(PrimitiveType.Quads);

                GL.Color3(colorBaseCube);

                foreach (Vector3 vector in baseList)
                {
                    GL.Vertex3(vector);
                }

                if (hideFace1)
                {
                    GL.Color3(colorFaceCube1);

                    GL.Vertex3(baseList[2]);
                    GL.Vertex3(baseList[3]);
                    GL.Vertex3(baseList[7]);
                    GL.Vertex3(baseList[6]);
                }

                if (hideFace2)
                {
                    GL.Color3(colorFaceCube2);

                    GL.Vertex3(baseList[3]);
                    GL.Vertex3(baseList[0]);
                    GL.Vertex3(baseList[4]);
                    GL.Vertex3(baseList[7]);
                }

                if (hideFace3)
                {
                    GL.Color3(colorFaceCube3);

                    GL.Vertex3(baseList[0]);
                    GL.Vertex3(baseList[1]);
                    GL.Vertex3(baseList[5]);
                    GL.Vertex3(baseList[4]);
                }

                if (hideFace4)
                {
                    GL.Color3(colorFaceCube4);

                    GL.Vertex3(baseList[1]);
                    GL.Vertex3(baseList[2]);
                    GL.Vertex3(baseList[6]);
                    GL.Vertex3(baseList[5]);
                }

                GL.End();
            }
        }

        public void MoveUp()
        {
            for (int i = 0; i < baseList.Count; i++)
            {
                baseList[i] = new Vector3(baseList[i].X, baseList[i].Y + changeY, baseList[i].Z);
            }
        }

        public void MoveDown()
        {
            for (int i = 0; i < baseList.Count; i++)
            {
                baseList[i] = new Vector3(baseList[i].X, baseList[i].Y - changeY, baseList[i].Z);
            }
        }

        public void ChangeComposition()
        {
            if (myPolygonMode == PolygonMode.Fill)
            {
                myPolygonMode = PolygonMode.Line;
            }
            else if (myPolygonMode == PolygonMode.Line)
            {
                myPolygonMode = PolygonMode.Point;
            }
            else
            {
                myPolygonMode = PolygonMode.Fill;
            }
        }

        public void Show()
        {
            myVisibility = true;
        }

        /// <summary>
        /// Sets visibility of the object OFF.
        /// </summary>
        public void Hide()
        {
            myVisibility = false;
        }

        /// <summary>
        /// Toggles the myVisibility of the object. Once triggered, the attribute is applied automatically on drawing.
        /// </summary>
        public void ToggleVisibility()
        {
            myVisibility = !myVisibility;
        }
        public void ToggleVisibility1()
        {
            hideFace1 = !hideFace1;
        }

        public void ToggleVisibility2()
        {
            hideFace2 = !hideFace2;
        }

        public void ToggleVisibility3()
        {
            hideFace3 = !hideFace3;
        }

        public void ToggleVisibility4()
        {
            hideFace4 = !hideFace4;
        }
    }
}
