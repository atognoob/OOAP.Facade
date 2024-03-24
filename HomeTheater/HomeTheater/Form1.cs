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
            InitializeHomeTheater();
        }
        private HomeTheaterFacade homeTheater;

        private void InitializeHomeTheater()
        {
            Amplifier amp = new Amplifier();
            Tuner tuner = new Tuner(amp);
            StreamingPlayer player = new StreamingPlayer(amp);
            CDPlayer cd = new CDPlayer(amp);
            Projector projector = new Projector(player);
            TheaterLights lights = new TheaterLights();
            Screen screen = new Screen();

            homeTheater = new HomeTheaterFacade(amp, tuner, player, cd, projector, lights, screen);
        }
        
        public class HomeTheaterFacade
        {
            Amplifier amp;
            Tuner tuner;
            StreamingPlayer player;
            CDPlayer cd;
            Projector projector;
            TheaterLights lights;
            Screen screen;
            public HomeTheaterFacade(Amplifier amp, Tuner tuner, StreamingPlayer player, CDPlayer cd, Projector projector, TheaterLights lights, Screen screen)
            {
                this.amp = amp;
                this.tuner = tuner;
                this.player = player;
                this.cd = cd;
                this.projector = projector;
                this.lights = lights;
                this.screen = screen;
            }
            public void watchMovie(String movie, int dimming, int volume)
            {
                lights.dim(dimming);
                screen.down();
                projector.on();
                projector.wideScreenMode();
                amp.on();
                amp.setStreamingPlayer(player);
                amp.setSurroundSound();
                amp.setVolume(volume);
                player.on();
                player.play();
            }
            public void endMovie()
            {
                lights.on();
                screen.up();
                projector.off();
                amp.off();
                player.stop();
                player.off();
            }
            public void listenToRadio(double frequency)
            {
                tuner.on();
                tuner.setFrequency(frequency);
                amp.on();
                amp.setVolume(5);
                amp.setTuner(tuner);
            }
            public void endRadio()
            {
                tuner.off();
                amp.off();
            }
            public void listenToCd(String cdTitle)
            {
                amp.on();
                amp.setVolume(5);
                amp.setCd(cd);
                amp.setStereoSound();
                cd.on();
                cd.play();
            }
            public void endCd()
            {
                amp.off();
                cd.pause();
                cd.off();
            }
        }

        public class Tuner
        {
            Amplifier amplifier;
            double frequency;
            public Tuner( Amplifier amplifier)
            {
                this.amplifier = amplifier;
            }
            public void on() { }
            public void off() { }
            public void setFrequency(double frequency)
            {
                this.frequency = frequency;
            }
        }
        public class StreamingPlayer
        {
            Amplifier amplifier;
            public StreamingPlayer( Amplifier amplifier)
            {
                this.amplifier = amplifier;
            }
            public void on() { }
            public void off() { }
            public void play() { }
            public void stop() { }
            public void pause() { }

        }
        public class Amplifier
        {
            Tuner tuner;
            StreamingPlayer player;
            CDPlayer cd;
            public void on() { }
            public void off() { }
            public void setStereoSound() { }
            public void setSurroundSound() { }
            public void setVolume(int level) { }
            public void setTuner(Tuner tuner)
            {
                this.tuner = tuner;
            }
            public void setStreamingPlayer(StreamingPlayer player)
            {
                this.player = player;
            }
            public void setCd(CDPlayer cd)
            {
                this.cd = cd;
            }
        }
        public class CDPlayer
        {
            Amplifier amplifier;
            public CDPlayer(Amplifier amplifier)
            {
                this.amplifier = amplifier;
            }
            public void on() { }
            public void off() { }
            public void play(){ }
            public void pause() { }
        }
        public class Projector
        {
            StreamingPlayer player;
            public Projector(StreamingPlayer player)
            {
                this.player = player;
            }
            public void on() { }
            public void off() { }
            public void wideScreenMode() { }
        }
        public class Screen
        {
            public void up() { }
            public void down() { }
        }
        public class TheaterLights
        {
            public void on() { }
            public void dim(int level) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button2.BackColor = Color.White;
            int dimming = 10;
            int volume = 5;
            string movie = "Ну, погоди!";
            homeTheater.watchMovie(movie, dimming, volume);
            listBox1.Items.Clear();
            listBox1.Items.Add("Get ready to watch movie " + movie + "...");
            listBox1.Items.Add("Theater Ceiling Lights dimming to " + dimming + " %");
            listBox1.Items.Add("Theater screen is going down");
            listBox1.Items.Add("Projector on");
            listBox1.Items.Add("Projector in widescreen mode (16x9 aspect ratio)");
            listBox1.Items.Add("Amplifier on");
            listBox1.Items.Add("Amplifier on is setting streaming player");
            listBox1.Items.Add("Amplifier surround sound on (5 speakers, 1 subwoofer)");
            listBox1.Items.Add("Amplifier is setting volume to " + volume);
            listBox1.Items.Add("Streaming player on");
            listBox1.Items.Add("Streaming player is playing movie!!!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button1.BackColor = Color.White;
            listBox1.Items.Clear();
            homeTheater.endMovie();
            listBox1.Items.Add("Shutting movie theater down...");
            listBox1.Items.Add("Theater Lights on");
            listBox1.Items.Add("Theater screen is going up");
            listBox1.Items.Add("Projector off");
            listBox1.Items.Add("Amplifier off");
            listBox1.Items.Add("Streaming player stopped movie");
            listBox1.Items.Add("Streaming player off");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Green;
            button3.BackColor = Color.White;
            button2.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button1.BackColor = Color.White;
            listBox1.Items.Clear();
            homeTheater.listenToRadio(180);
            listBox1.Items.Add("Get ready to listen to radio...");
            listBox1.Items.Add("Tuner on");
            listBox1.Items.Add("Tuner is setting frequency to 180");
            listBox1.Items.Add("Amplifier on");
            listBox1.Items.Add("Amplifier is setting volumn to 5");
            listBox1.Items.Add("Amplifier is setting tuner");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Green;
            button4.BackColor = Color.White;
            button2.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button1.BackColor = Color.White;
            listBox1.Items.Clear();
            homeTheater.endRadio();
            listBox1.Items.Add("Shutting down the tuner...");
            listBox1.Items.Add("Tuner off");
            listBox1.Items.Add("Amplifier off");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.Green;
            button4.BackColor = Color.White;
            button2.BackColor = Color.White;
            button5.BackColor = Color.White;
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            listBox1.Items.Clear();
            homeTheater.listenToCd("MCK");
            listBox1.Items.Add("Get ready to listen to CD ablum MCK...");
            listBox1.Items.Add("Amplifier on");
            listBox1.Items.Add("Amplifier is setting volumn to 5");
            listBox1.Items.Add("Amplifier is setting to CD player");
            listBox1.Items.Add("Amplifier stereo mode on");
            listBox1.Items.Add("CD player on");
            listBox1.Items.Add("CD player is playing!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.Green;
            button4.BackColor = Color.White;
            button2.BackColor = Color.White;
            button6.BackColor = Color.White;
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            listBox1.Items.Clear();
            homeTheater.endCd();
            listBox1.Items.Add("Shutting down CD Player...");
            listBox1.Items.Add("Amplifier off");
            listBox1.Items.Add("CD player stopped");
            listBox1.Items.Add("CD player off");
        }
    }   
}

