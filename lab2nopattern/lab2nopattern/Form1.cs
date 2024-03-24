using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2nopattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TheaterLights lights = new TheaterLights();
        Amplifier amplifier = new Amplifier();
        StreamingPlayer player = new StreamingPlayer();
        CDPlayer cd = new CDPlayer();
        Projector projector = new Projector();
        Screen screen = new Screen();
        Tuner tuner = new Tuner();

        public class TheaterLights
        {
            public void on() { }
            public void off() { }  
        }
        public class Screen
        {
            public void up() { }
            public void down() { }
        }
        public class Projector
        {
            public void on() { }
            public void off() { }
        }

        public class CDPlayer
        {
            public void on() { }
            public void off() { }
        }
        public class Amplifier
        {
            public void on() { }
            public void off() { }
            public void setStereoSound() { }
            public void setSurroundSound() { }
            public void setVolume(int level) { }
        }
        public class StreamingPlayer
        {
            public void on() { }
            public void off() { }
        }
        public class Tuner
        {
            public void on() { }
            public void off() { }
            public void setFrequency(double frequency) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lights.on();
            button1.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lights.off();
            button1.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            screen.up();
            button4.BackColor = Color.Green;
            button3.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            screen.down();
            button3.BackColor = Color.Green;
            button4.BackColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            projector.on();
            button6.BackColor = Color.Green;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            projector.off();
            button6.BackColor = Color.White;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            amplifier.on();
            button8.BackColor = Color.Green;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            amplifier.off(); 
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            amplifier.setStereoSound();
            button10.BackColor = Color.Green;
            button9.BackColor = Color.White;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            amplifier.setSurroundSound();
            button9.BackColor = Color.Green;
            button10.BackColor= Color.White;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int vol = int.Parse(textBox1.Text);
            amplifier.setVolume(vol);
            button11.BackColor = Color.Green;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            player.on();
            button13.BackColor = Color.Green;
            button14.BackColor = Color.White;
            button17.BackColor = Color.White;
            if (button13.BackColor == Color.Green && button8.BackColor==Color.Green )
            {
                MessageBox.Show("Amplifier is connected to Streaming Player");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            player.off();
            button13.BackColor = Color.White;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tuner.on();
            button14.BackColor = Color.Green;
            button13.BackColor = Color.White;
            button17.BackColor = Color.White;
            if (button14.BackColor == Color.Green && button8.BackColor == Color.Green)
            {
                MessageBox.Show("Amplifier is connected to Tuner");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tuner.off();
            button14.BackColor = Color.White;
            button18.BackColor = Color.White;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int freq = int.Parse(textBox2.Text);
            tuner.setFrequency(freq);
            button18.BackColor = Color.Green;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            cd.on();
            button17.BackColor = Color.Green;
            button14.BackColor = Color.White;
            button13.BackColor = Color.White;
            if (button17.BackColor == Color.Green && button8.BackColor == Color.Green)
            {
                MessageBox.Show("Amplifier is connected to CD Player");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cd.off();
            button17.BackColor = Color.White;
        }
    }
}
