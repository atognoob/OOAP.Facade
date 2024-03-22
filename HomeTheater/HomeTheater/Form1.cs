using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTheater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    public class Tuner
    {

    }

    public class StreamingPlayer
    {

    }

    public class Amplifier
    {
        string description;
        Tuner tuner;
        StreamingPlayer player;
      

        public Amplifier(string description)
        {
            this.description = description;
        }
        public void on()
        {

        }
        public void off()
        {

        }
        public void setStereoSound()
        {

        }
        public void setSurroundSound()
        {

        }
        public void setVolume(int level)
        {

        }
        public void setTuner(Tuner tuner)
        {
            this.tuner = tuner;
        }
        public void setStreamingPlayer(StreamingPlayer player)
        {
            this.player = player;
        }
        public String toString()
        {
            return description;
        }
    }
    public class CDPlayer
    {
        string description;
        int currentTrack;
        Amplifier amplifier;
        string title;
        public CDPlayer(string description, Amplifier amplifier)
        {
            this.description= description;
            this.amplifier= amplifier;
        }
        public void on()
        {

        }
        public void off()
        {

        }
        public void eject()
        {

        }

    }

}

