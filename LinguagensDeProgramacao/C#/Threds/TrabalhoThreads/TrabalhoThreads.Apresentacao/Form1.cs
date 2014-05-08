﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrabalhoThreads.Recursos;

namespace TrabalhoThreads.Apresentacao
{
    public partial class Form1 : Form
    {
        private ConcurrentQueue<Relatorio> filaDeRelatoriosImpressos;
        private ConcurrentQueue<Relatorio> filaDeRelatoriosGerados;
        private Produtor produtor;
        private Consumidor consumidor;

        public Form1()
        {
            produtor = new Produtor(filaDeRelatoriosGerados, 10);
            consumidor = new Consumidor(filaDeRelatoriosGerados, filaDeRelatoriosImpressos);
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            produtor.CriarNovoProdutor();
            consumidor.CriarNovoConsumidor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            produtor.PararProdutores();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var picBox = new PictureBox();
            picBox.ImageLocation = @"img\caminhao.png";
            picBox.Location = new Point(10, 10);
            this.Controls.Add(picBox);
        }
    }
}
