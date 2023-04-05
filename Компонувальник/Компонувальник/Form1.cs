using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Компонувальник
{
    public partial class Form1 : Form
    {

        private LayoutDesigner.BicycleBuilder builder;

        private LayoutDesigner.BicycleComponent component;
        public Form1()
        {
            InitializeComponent();

            builder = new LayoutDesigner.BicycleBuilder();
            LayoutDesigner.BicycleComponent component = new LayoutDesigner.BicycleComponent("MyComponent", 10.0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Збір компонентів велосипеду
            double framePrice = Convert.ToDouble(textBox1.Text);
            builder.BuildFrame(textBox1.Text, framePrice);

            double wheelPrice = Convert.ToDouble(textBox2.Text);
            builder.BuildWheel(textBox2.Text, wheelPrice);

            double seatPrice = Convert.ToDouble(textBox3.Text);
            builder.BuildSeat(textBox3.Text, seatPrice);

            double handlebarPrice = Convert.ToDouble(textBox4.Text);
            builder.BuildHandlebar(textBox4.Text, handlebarPrice);

            // Додавання декораторів

            if (checkBox1.Checked)
            {
                double wheelDecoratorPrice = Convert.ToDouble(textBox5.Text);
                builder.AddWheelDecorator(textBox5.Text, wheelDecoratorPrice);
            }

            if (checkBox2.Checked)
            {
                double seatDecoratorPrice = Convert.ToDouble(textBox6.Text);
                builder.AddSeatDecorator(textBox6.Text, seatDecoratorPrice);
            }

            if (checkBox3.Checked)
            {
                double handlebarDecoratorPrice = Convert.ToDouble(textBox7.Text);
                builder.AddHandlebarDecorator(textBox7.Text, handlebarDecoratorPrice);
            }

             label1.Text = textBox8.Text;
            
           
        
           double sum = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text)  + Convert.ToDouble(textBox3.Text) + Convert.ToDouble (textBox4.Text);
            if (checkBox1.Checked)
            {
             sum = sum + Convert.ToDouble(textBox5.Text);
            }
            if (checkBox2.Checked)
            {
                sum = sum + Convert.ToDouble(textBox6.Text);
            }
            if (checkBox3.Checked)
            {
                sum = sum + Convert.ToDouble(textBox7.Text);
            }
            label2.Text = sum.ToString(); 
        }
    }
}

