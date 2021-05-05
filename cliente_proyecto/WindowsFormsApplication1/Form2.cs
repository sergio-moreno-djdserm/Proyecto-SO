using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        int segundos = 0;
        int player_pos;
        int bomb_pos;

        public Form2(int id)
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos = segundos + 1;
        }

        //Permitir al jugador pulsar o no a un botón y cada vez que el jugador cambie de boton, se le enviará al servidor su nueva posición
        public void button12_Click(object sender, EventArgs e)
        {
            player_pos = 12;
            //Cambiar si habilitamos o no
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = true;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button12.BackgroundImage = Properties.Resources.persona;
            button13.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button13_Click(object sender, EventArgs e)
        {
            player_pos = 13;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = true;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button13.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button14_Click(object sender, EventArgs e)
        {
            player_pos = 14;
            button12.Enabled = false;
            button13.Enabled = true;
            button14.Enabled = true;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = true;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button14.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button16_Click(object sender, EventArgs e)
        {
            player_pos = 16;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = true;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button16.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button18_Click(object sender, EventArgs e)
        {
            player_pos = 18;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = true;
            button19.Enabled = true;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = true;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button18.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button19_Click(object sender, EventArgs e)
        {
            player_pos = 19;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = true;
            button19.Enabled = true;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button19.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button22_Click(object sender, EventArgs e)
        {
            player_pos = 22;
            button12.Enabled = true;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = true;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button22.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button13.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button23_Click(object sender, EventArgs e)
        {
            player_pos = 23;
            button12.Enabled = false;
            button13.Enabled = true;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button23.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button24_Click(object sender, EventArgs e)
        {
            player_pos = 24;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = true;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = true;
            button24.Enabled = true;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = true;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button24.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button26_Click(object sender, EventArgs e)
        {
            player_pos = 26;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = true;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = true;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button26.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button27_Click(object sender, EventArgs e)
        {
            player_pos = 27;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = true;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button27.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button28_Click(object sender, EventArgs e)
        {
            player_pos = 28;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = true;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = true;
            button28.Enabled = true;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = true;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button28.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button32_Click(object sender, EventArgs e)
        {
            player_pos = 32;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = true;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = true;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = true;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button32.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button13.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button34_Click(object sender, EventArgs e)
        {
            player_pos = 34;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = true;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = true;
            button35.Enabled = true;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button34.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button35_Click(object sender, EventArgs e)
        {
            player_pos = 35;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = true;
            button35.Enabled = true;
            button36.Enabled = true;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = true;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button35.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button36_Click(object sender, EventArgs e)
        {
            player_pos = 36;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = true;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = true;
            button36.Enabled = true;
            button37.Enabled = true;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = true;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button36.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button37_Click(object sender, EventArgs e)
        {
            player_pos = 37;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = true;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = true;
            button37.Enabled = true;
            button38.Enabled = true;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button37.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button38_Click(object sender, EventArgs e)
        {
            player_pos = 38;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = true;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = true;
            button38.Enabled = true;
            button39.Enabled = true;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button38.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button39_Click(object sender, EventArgs e)
        {
            player_pos = 39;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = true;
            button39.Enabled = true;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = true;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button39.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button42_Click(object sender, EventArgs e)
        {
            player_pos = 42;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = true;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = true;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = true;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button42.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button13.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button45_Click(object sender, EventArgs e)
        {
            player_pos = 45;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = true;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = true;
            button46.Enabled = true;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = true;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button45.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button46_Click(object sender, EventArgs e)
        {
            player_pos = 46;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = true;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = true;
            button46.Enabled = true;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = true;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button46.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button49_Click(object sender, EventArgs e)
        {
            player_pos = 49;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = true;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = true;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = true;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button49.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button52_Click(object sender, EventArgs e)
        {
            player_pos = 52;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = true;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = true;
            button53.Enabled = true;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = true;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button52.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button13.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button53_Click(object sender, EventArgs e)
        {
            player_pos = 53;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = true;
            button53.Enabled = true;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = true;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button53.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button55_Click(object sender, EventArgs e)
        {
            player_pos = 55;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = true;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = true;
            button56.Enabled = true;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button55.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button56_Click(object sender, EventArgs e)
        {
            player_pos = 56;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = true;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = true;
            button56.Enabled = true;
            button57.Enabled = true;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = true;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button56.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button57_Click(object sender, EventArgs e)
        {
            player_pos = 57;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = true;
            button57.Enabled = true;
            button58.Enabled = true;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button57.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button58_Click(object sender, EventArgs e)
        {
            player_pos = 58;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = true;
            button58.Enabled = true;
            button59.Enabled = true;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = true;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button58.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button59_Click(object sender, EventArgs e)
        {
            player_pos = 59;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = true;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = true;
            button59.Enabled = true;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button59.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button62_Click(object sender, EventArgs e)
        {
            player_pos = 62;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = true;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = true;
            button63.Enabled = true;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = true;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button62.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button13.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button63_Click(object sender, EventArgs e)
        {
            player_pos = 63;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = true;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = true;
            button63.Enabled = true;
            button64.Enabled = true;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button63.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button64_Click(object sender, EventArgs e)
        {
            player_pos = 64;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = true;
            button64.Enabled = true;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = true;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button64.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button66_Click(object sender, EventArgs e)
        {
            player_pos = 66;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = true;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = true;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = true;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button66.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button68_Click(object sender, EventArgs e)
        {
            player_pos = 68;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = true;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = true;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = true;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button68.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button72_Click(object sender, EventArgs e)
        {
            player_pos = 72;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = true;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = true;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = true;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button72.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button13.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button74_Click(object sender, EventArgs e)
        {
            player_pos = 74;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = true;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = true;
            button75.Enabled = true;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button74.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button75_Click(object sender, EventArgs e)
        {
            player_pos = 75;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = true;
            button75.Enabled = true;
            button76.Enabled = true;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = true;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button75.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button76_Click(object sender, EventArgs e)
        {
            player_pos = 76;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = true;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = true;
            button76.Enabled = true;
            button77.Enabled = true;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = true;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button76.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button77_Click(object sender, EventArgs e)
        {
            player_pos = 77;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = true;
            button77.Enabled = true;
            button78.Enabled = true;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button77.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button78_Click(object sender, EventArgs e)
        {
            player_pos = 78;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = true;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = true;
            button78.Enabled = true;
            button79.Enabled = true;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = true;
            button89.Enabled = false;

            //Cambiar background
            button78.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button79_Click(object sender, EventArgs e)
        {
            player_pos = 79;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = true;
            button79.Enabled = true;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = true;

            //Cambiar background
            button79.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button82_Click(object sender, EventArgs e)
        {
            player_pos = 82;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = true;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = true;
            button83.Enabled = true;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button82.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button13.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button83_Click(object sender, EventArgs e)
        {
            player_pos = 83;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = true;
            button83.Enabled = true;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button83.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button85_Click(object sender, EventArgs e)
        {
            player_pos = 85;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = true;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = true;
            button86.Enabled = true;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button85.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button86_Click(object sender, EventArgs e)
        {
            player_pos = 86;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = true;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = true;
            button86.Enabled = true;
            button88.Enabled = false;
            button89.Enabled = false;

            //Cambiar background
            button86.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button88_Click(object sender, EventArgs e)
        {
            player_pos = 88;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = true;
            button79.Enabled = false;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = true;
            button89.Enabled = true;

            //Cambiar background
            button88.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
            button89.BackgroundImage = Properties.Resources.suelo;
        }

        public void button89_Click(object sender, EventArgs e)
        {
            player_pos = 89;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button16.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;

            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;

            button32.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;

            button42.Enabled = false;
            button45.Enabled = false;
            button46.Enabled = false;
            button49.Enabled = false;

            button52.Enabled = false;
            button53.Enabled = false;
            button55.Enabled = false;
            button56.Enabled = false;
            button57.Enabled = false;
            button58.Enabled = false;
            button59.Enabled = false;

            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button66.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;

            button72.Enabled = false;
            button74.Enabled = false;
            button75.Enabled = false;
            button76.Enabled = false;
            button77.Enabled = false;
            button78.Enabled = false;
            button79.Enabled = true;

            button82.Enabled = false;
            button83.Enabled = false;
            button85.Enabled = false;
            button86.Enabled = false;
            button88.Enabled = true;
            button89.Enabled = true;

            //Cambiar background
            button89.BackgroundImage = Properties.Resources.persona;
            button12.BackgroundImage = Properties.Resources.suelo;
            button14.BackgroundImage = Properties.Resources.suelo;
            button16.BackgroundImage = Properties.Resources.suelo;
            button18.BackgroundImage = Properties.Resources.suelo;
            button19.BackgroundImage = Properties.Resources.suelo;

            button22.BackgroundImage = Properties.Resources.suelo;
            button23.BackgroundImage = Properties.Resources.suelo;
            button24.BackgroundImage = Properties.Resources.suelo;
            button26.BackgroundImage = Properties.Resources.suelo;
            button27.BackgroundImage = Properties.Resources.suelo;
            button28.BackgroundImage = Properties.Resources.suelo;

            button32.BackgroundImage = Properties.Resources.suelo;
            button34.BackgroundImage = Properties.Resources.suelo;
            button35.BackgroundImage = Properties.Resources.suelo;
            button36.BackgroundImage = Properties.Resources.suelo;
            button37.BackgroundImage = Properties.Resources.suelo;
            button38.BackgroundImage = Properties.Resources.suelo;
            button39.BackgroundImage = Properties.Resources.suelo;

            button42.BackgroundImage = Properties.Resources.suelo;
            button45.BackgroundImage = Properties.Resources.suelo;
            button46.BackgroundImage = Properties.Resources.suelo;
            button49.BackgroundImage = Properties.Resources.suelo;

            button52.BackgroundImage = Properties.Resources.suelo;
            button53.BackgroundImage = Properties.Resources.suelo;
            button55.BackgroundImage = Properties.Resources.suelo;
            button56.BackgroundImage = Properties.Resources.suelo;
            button57.BackgroundImage = Properties.Resources.suelo;
            button58.BackgroundImage = Properties.Resources.suelo;
            button59.BackgroundImage = Properties.Resources.suelo;

            button62.BackgroundImage = Properties.Resources.suelo;
            button63.BackgroundImage = Properties.Resources.suelo;
            button64.BackgroundImage = Properties.Resources.suelo;
            button66.BackgroundImage = Properties.Resources.suelo;
            button68.BackgroundImage = Properties.Resources.suelo;

            button72.BackgroundImage = Properties.Resources.suelo;
            button74.BackgroundImage = Properties.Resources.suelo;
            button75.BackgroundImage = Properties.Resources.suelo;
            button76.BackgroundImage = Properties.Resources.suelo;
            button77.BackgroundImage = Properties.Resources.suelo;
            button78.BackgroundImage = Properties.Resources.suelo;
            button79.BackgroundImage = Properties.Resources.suelo;

            button82.BackgroundImage = Properties.Resources.suelo;
            button83.BackgroundImage = Properties.Resources.suelo;
            button85.BackgroundImage = Properties.Resources.suelo;
            button86.BackgroundImage = Properties.Resources.suelo;
            button88.BackgroundImage = Properties.Resources.suelo;
            button13.BackgroundImage = Properties.Resources.suelo;
        }



        //Función que indica en que posición se suelta la bomba
        public void soltar_bomba_Click(object sender, EventArgs e)
        {
            bomb_pos = player_pos;
        }

        //Función que explotará la bomba, y es cuando se enviará al servidor el mensaje de explotar
        public void button101_Click(object sender, EventArgs e)
        {
            if (bomb_pos != 0)
            {
                MessageBox.Show(Convert.ToString(bomb_pos));
                //Comandos para enviar donde tiene que explotar la bomba
            }
            //Una vez que la soltamos, la reiniciamos a 0
            bomb_pos = 0;
        }



        //Cambiar el background de los botones cuando pasas el cursor por encima
        private void button12_MouseEnter(object sender, EventArgs e)
        {
            //button12.BackgroundImage = Properties.Resources.persona;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            //button12.BackgroundImage = Properties.Resources.suelo;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            //button13.BackgroundImage = Properties.Resources.persona;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            //button13.BackgroundImage = Properties.Resources.suelo;
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            //button14.BackgroundImage = Properties.Resources.persona;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            //button14.BackgroundImage = Properties.Resources.suelo;
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            //button16.BackgroundImage = Properties.Resources.persona;
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            //button16.BackgroundImage = Properties.Resources.suelo;
        }

        private void button18_MouseEnter(object sender, EventArgs e)
        {
            //button18.BackgroundImage = Properties.Resources.persona;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            //button18.BackgroundImage = Properties.Resources.suelo;
        }

        private void button19_MouseEnter(object sender, EventArgs e)
        {
            //button19.BackgroundImage = Properties.Resources.persona;
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            //button19.BackgroundImage = Properties.Resources.suelo;
        }

        private void button22_MouseEnter(object sender, EventArgs e)
        {
            //button22.BackgroundImage = Properties.Resources.persona;
        }

        private void button22_MouseLeave(object sender, EventArgs e)
        {
            //button22.BackgroundImage = Properties.Resources.suelo;
        }

        private void button23_MouseEnter(object sender, EventArgs e)
        {
            //button23.BackgroundImage = Properties.Resources.persona;
        }

        private void button23_MouseLeave(object sender, EventArgs e)
        {
            //button23.BackgroundImage = Properties.Resources.suelo;
        }

        private void button24_MouseEnter(object sender, EventArgs e)
        {
            //button24.BackgroundImage = Properties.Resources.persona;
        }

        private void button24_MouseLeave(object sender, EventArgs e)
        {
            //button24.BackgroundImage = Properties.Resources.suelo;
        }

        private void button26_MouseEnter(object sender, EventArgs e)
        {
            //button26.BackgroundImage = Properties.Resources.persona;
        }

        private void button26_MouseLeave(object sender, EventArgs e)
        {
            //button26.BackgroundImage = Properties.Resources.suelo;
        }

        private void button27_MouseEnter(object sender, EventArgs e)
        {
            //button27.BackgroundImage = Properties.Resources.persona;
        }

        private void button27_MouseLeave(object sender, EventArgs e)
        {
            //button27.BackgroundImage = Properties.Resources.suelo;
        }

        private void button28_MouseEnter(object sender, EventArgs e)
        {
            //button28.BackgroundImage = Properties.Resources.persona;
        }

        private void button28_MouseLeave(object sender, EventArgs e)
        {
            //button28.BackgroundImage = Properties.Resources.suelo;
        }

        private void button32_MouseEnter(object sender, EventArgs e)
        {
            //button32.BackgroundImage = Properties.Resources.persona;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {
            //button32.BackgroundImage = Properties.Resources.suelo;
        }
    }
}
