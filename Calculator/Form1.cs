using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace Calculator
{
    public partial class MyCalculator : Form
    {
        private static string _expression = string.Empty;
        private readonly Logic _logic = new Logic();


        public string Expression { get => _expression; set => _expression = value; }

        public MyCalculator()
        {
            InitializeComponent();
        }

        private void n1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 9)
            {
                return;
            }

            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = ((Button)sender).Text;
            }
            else
            {
                textBox1.Text += ((Button)sender).Text;
            }
        }

        public void Operation_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                return;
            }

            string output = textBox1.Text;

            if (textBox1.Text.Length > 9 || SymbolIsOperation(output[output.Length - 1]))
            {
                return;
            }

            textBox1.Text += ((Button)sender).Text;

            _expression += textBox1.Text;

            textBox1.Text = string.Empty;
        }

        public void bequal_Click(object sender, EventArgs e)
        {
            _expression += textBox1.Text;

            textBox1.Text = _logic.GetResult(_expression);

            _expression = string.Empty;
        }

        public void bClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.Clear();
            textBox1.Text = string.Empty;
            _expression = string.Empty;
        }

        public void NegateButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox1.Text == "EXCEEDED" || textBox1.Text == "NOT / 0")
            {
                return;
            }
            
            textBox1.Text = _logic.NegateNumber(textBox1.Text);
        }


        private bool SymbolIsOperation(char key)
        {
            char[] operations = new[] { '+', '-', '/', '*', '=', 'x' };

            return operations.Contains(key);
        }

        private void MyCalculator_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((!SymbolIsOperation(e.KeyChar) && !char.IsDigit(e.KeyChar)))
            {
                return;
            }

            switch (e.KeyChar)
            {
                case '+':
                    bad.PerformClick();
                    break;
                case '-':
                    bsub.PerformClick();
                    break;
                case '*':
                    bmult.PerformClick();
                    break;
                case '/':
                    bdiv.PerformClick();
                    break;
                case '=':
                    bequal.PerformClick();
                    break;
                default:
                    Button[] buttons = new[] { n0, n1, n2, n3, n4, n5, n6, n7, n8, n9 };
                    buttons[int.Parse(e.KeyChar.ToString())].PerformClick();
                    break;
            }
        }

        private void MyCalculator_Load(object sender, EventArgs e)
        {

        }

        private void MinimizeButton_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void CloseButton_Click(object sender, EventArgs e) => Close();

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

