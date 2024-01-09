using DataStructures;

namespace UnionFindVisualizer
{
    public partial class Form1 : Form
    {
        TextBox[,] grid = new TextBox[5, 5];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control val in Controls)
            {
                if (val.Tag != null)
                {
                    string temp = val.Tag.ToString();
                    grid[int.Parse(temp[0].ToString()), int.Parse(temp[1].ToString())] = (TextBox)val;
                }
            }
            int temp2 = 65;
            foreach (TextBox box in grid)
            {
                string letter = ((char)(temp2)).ToString();
                box.Text = letter;
                temp2++;
            }
        }

        TextBox firstBox;
        TextBox secondBox;

        private void textBox1_Click(object sender, EventArgs e)
        {
            if(firstBox == null)
            {
                firstBox = (TextBox)sender;
            }
            else
            {
                secondBox = (TextBox)sender;
            }

            if(firstBox != null && secondBox != null)
            {
                
            }

        }
    }
}