using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireflyAlgorithm;

namespace MainForm
{
    public partial class MyPictureBox : UserControl
    {
        public MyPictureBox()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

        }
        public List<int> optimal_indexes;
        public List<City> Solution;
        public List<PointF> Cities;

        Color dotcolor = Color.Gray;
        Color linecolor = Color.Red;
        Color opt_color = Color.Blue;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(Cities!=null && Cities.Count > 0)
            {
                for (int i = 0; i < Cities.Count; i++)
                {
                    e.Graphics.DrawEllipse(new Pen(dotcolor, 3.0f), Cities[i].X, Cities[i].Y, 5, 5);
                }
            }
            if(optimal_indexes != null && optimal_indexes.Count > 0)
            {
                Pen mypen = new Pen(opt_color, 2);

                for (int i = 0; i < optimal_indexes.Count - 1; i++)
                {
                    e.Graphics.DrawLine(mypen, Cities[optimal_indexes[i] - 1].X+2.5f, Cities[optimal_indexes[i] - 1].Y + 2.5f,
                        Cities[optimal_indexes[i + 1] - 1].X+2.5f, Cities[optimal_indexes[i + 1] - 1].Y + 2.5f);
                }
            }
            if(Solution!=null && Solution.Count > 0)
            {
                Pen mypen = new Pen(linecolor, 3);

                for (int i = 0; i < Solution.Count - 1; i++)
                {
                    e.Graphics.DrawLine(mypen, Cities[Solution[i].index - 1].X+2.5f, Cities[Solution[i].index - 1].Y + 2.5f, 
                        Cities[Solution[i + 1].index - 1].X+2.5f, Cities[Solution[i + 1].index - 1].Y+2.5f);
                }
            }
            
        }

    }
}
