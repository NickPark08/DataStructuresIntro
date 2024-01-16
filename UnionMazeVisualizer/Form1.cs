using DataStructures;
using System.Linq;

namespace UnionMazeVisualizer
{
    public partial class Form1 : Form
    {
        TextBox[,] grid = new TextBox[5, 5];
        WeightedDirectedGraph<TextBox> graph = new WeightedDirectedGraph<TextBox>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control val in Controls)
            {
                if (val.Tag != null && val.Tag.ToString().Length == 2)
                {
                    string temp = val.Tag.ToString();
                    grid[int.Parse(temp[0].ToString()), int.Parse(temp[1].ToString())] = (TextBox)val;
                }
            }
            foreach (TextBox box in grid)
            {
                graph.AddVertex(new WDVertex<TextBox>(box));
            }

            Label edge = Controls.OfType<Label>().Where(edge => edge.Tag == "00-10").First();//code to find label between 2 edges
        }

    }
}