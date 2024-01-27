using DataStructures;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;

namespace UnionMazeVisualizer
{
    public partial class Form1 : Form
    {
        WeightedDirectedGraph<Rectangle> graph = new WeightedDirectedGraph<Rectangle>();
        WDVertex<Rectangle>[,] vertices = new WDVertex<Rectangle>[20, 10];

        Bitmap image;
        Graphics gfx;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            int temp = 0;
            for (int i = 0; i < vertices.GetLength(0); i++)
            {
                for (int j = 0; j < vertices.GetLength(1); j++)
                {
                    int x = 0;
                    int y = 0;
                    if (i != 0)
                    {
                        x = i * ((pictureBox1.Width) / vertices.GetLength(0));
                    }
                    if (j != 0)
                    {
                        y = j * ((pictureBox1.Height) / vertices.GetLength(1));
                    }
                    graph.AddVertex(vertices[i, j] = new(new Rectangle(x, y, pictureBox1.Width / vertices.GetLength(0), pictureBox1.Height / vertices.GetLength(1))));
                }
                temp++;
            }

            int col = 0;
            int row = 0;
            while (col + 1 < vertices.GetLength(1))
            {
                for (int i = 0; i < vertices.GetLength(0); i++)
                {
                    graph.AddEdge(vertices[i, col], vertices[i, col + 1], 1);
                }
                col++;
            }
            while (row + 1 < vertices.GetLength(0))
            {
                for (int i = 0; i < vertices.GetLength(1); i++)
                {
                    graph.AddEdge(vertices[row, i], vertices[row + 1, i], 1);
                }
                row++;
            }

            image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(image);

            foreach (var vertex in vertices)
            {
                gfx.DrawRectangle(Pens.Black, vertex.Value);
            }

            pictureBox1.Image = image;

            //Label edge = Controls.OfType<Label>().Where(edge => edge.Tag == "00-10").First();//code to find label between 2 edges
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            Maze<Rectangle> maze = new Maze<Rectangle>();
            WDVertex<Rectangle> start = vertices[0, 0];
            WDVertex<Rectangle> end = vertices[vertices.GetLength(0) - 1, vertices.GetLength(1) - 1];

            var edges = maze.MazeGenerator(graph, start, end);
            foreach (var edge in edges)
            {
                var vertex = edge.StartPoint.Value;
                if (edge.EndPoint.Value.X > vertex.X)
                {
                    //gfx.DrawRectangle(new Pen(Color.Red, 100), 50, 50, 100, 100);
                    gfx.DrawLine(new Pen(BackColor), vertex.Right, vertex.Y, vertex.Right, vertex.Y + vertex.Height);
                }
                else
                {
                    //gfx.DrawRectangle(Pens.Red, 50, 50, 100, 100);
                    gfx.DrawLine(new Pen(BackColor), vertex.X, vertex.Bottom, vertex.X + vertex.Width, vertex.Bottom);
                }
                //pictureBox1.Image = image;
                //await Task.Delay(100);
            }

            graph.Edges.Clear();
            foreach (var edge in edges)
            {
                graph.AddEdge(edge.StartPoint, edge.EndPoint, edge.Distance);
            }
            (List<WDVertex<Rectangle>> path, List<WDVertex<Rectangle>> journey) visual = graph.AStar(start, end);

            foreach(var rect in visual.path)
            {
                gfx.FillRectangle(Brushes.LightGreen, rect.Value);
            }
            pictureBox1.Image = image;
        }

    }
}