using DataStructures;

using System.Linq;

namespace UnionMazeVisualizer
{
    public partial class Form1 : Form
    {
        WeightedDirectedGraph<Rectangle> graph = new WeightedDirectedGraph<Rectangle>();
        WDVertex<Rectangle>[,] vertices = new WDVertex<Rectangle>[5, 5];

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //foreach (Control val in Controls)
            //{
            //    if (val.Tag != null && val.Tag.ToString().Length == 2)
            //    {
            //        string temp = val.Tag.ToString();
            //     //   grid[int.Parse(temp[0].ToString()), int.Parse(temp[1].ToString())] = (WDVertex<TextBox>)val;
            //    }
            //}
            //foreach (WDVertex<TextBox> box in grid)
            //{
            //    graph.AddVertex(box);
            //}
            int temp = 0;

            for (int i = 0; i < vertices.GetLength(0); i++)
            {
                for (int j = 0; j < vertices.GetLength(1); j++)
                {
                    int x = (pictureBox1.Width) / (i / vertices.GetLength(0));
                    int y = (pictureBox1.Height) / (j / vertices.GetLength(1));
                    graph.AddVertex(vertices[i, j] = new (new Rectangle(x, y, 100, 100)));
                }
                temp++;
            }

            int col = 0;
            int row = 0;
            while (col + 1 < vertices.GetLength(1))
            {
                for (int i = 0; i < vertices.GetLength(0); i++)
                {
                    graph.AddEdge(vertices[i, col], vertices[i, col + 1], 0);
                }
                col++;
            }
            while (row + 1 < vertices.GetLength(0))
            {
                for (int i = 0; i < vertices.GetLength(0); i++)
                {
                    graph.AddEdge(vertices[row, i], vertices[row + 1, i], 0);
                }
                row++;
            }


            //Label edge = Controls.OfType<Label>().Where(edge => edge.Tag == "00-10").First();//code to find label between 2 edges
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gfx = Graphics.FromImage(image);

            gfx.DrawRectangle(Pens.Black, new Rectangle(0, 0, 100, 100));


            pictureBox1.Image = image;
        }
    }
}