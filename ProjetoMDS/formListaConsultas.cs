﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMDS
{
    public partial class formListaConsultas : Form
    {
        List<Consulta> listConsulta = new List<Consulta>();
        consultaRepository consultaRepo = new consultaRepository();
        Medico medicoLogado = new Medico();
        
        public formListaConsultas(Medico medico)
        {
            InitializeComponent();
            this.medicoLogado = medico;
            labelData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            listConsulta = consultaRepo.listaConsulta(medicoLogado);
            refeshConsultasList();
        }

        private void formListaConsultas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void refeshConsultasList()
        {
            listBox1.Items.Clear();
            foreach (Consulta consulta in listConsulta)
            {
                listBox1.Items.Add(consulta);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbPesquisa.Text != "")
            {
                listConsulta = consultaRepo.listaConsultaByName(tbPesquisa.Text, medicoLogado);
                refeshConsultasList();
            }
            else
            {
                listConsulta = consultaRepo.listaConsulta(medicoLogado);
                refeshConsultasList();
            }
        }
    }
}
