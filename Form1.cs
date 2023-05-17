using System.Windows.Forms;

namespace k22_3_buble_sorting
{
    public partial class Form1 : Form
    {
        int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (numCount.Value == 0)
            {
                MessageBox.Show("Не задана кількість елементів масиву!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            count = (int)numCount.Value;
            dataGridView1.ColumnCount = count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = 75;
                column.HeaderText = (i + 1).ToString();
                if (column.GetType() == typeof(DataGridViewTextBoxColumn))
                    ((DataGridViewTextBoxColumn)column).MaxInputLength = 1;
            }

            dataGridView1.Rows.Add();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            txtSorted.Text = "";
            char[] symbs = new char[count];

            for (int i = 0; i < count; i++)
                symbs[i] = Convert.ToChar(dataGridView1.Rows[0].Cells[i].Value);

            for (int i = 1; i < count; i++)
                for (int j = 0; j < count - i; j++)
                    if (symbs[j] > symbs[j + 1])
                    {
                        char s = symbs[j + 1];
                        symbs[j + 1] = symbs[j];
                        symbs[j] = s;
                    }

            for (int i = 0; i < count; i++)
            {
                txtSorted.Text += Convert.ToString(symbs[i]) + " ";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}