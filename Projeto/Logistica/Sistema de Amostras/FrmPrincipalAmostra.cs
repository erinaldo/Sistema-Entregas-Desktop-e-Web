﻿using DALLogistica.Entities;
using DALLogistica.Repository;
using Logistica.Sistema_de_Logistica;
using Projeto.Logistica.Sistema_de_Amostras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistica.Sistema_de_Amostras
{
    public partial class FrmPrincipalAmostra : Form
    {
        public FrmPrincipalAmostra()
        {
            InitializeComponent();
        }

        private void FrmPrincipalAmostra_Load(object sender, EventArgs e)
        {
            CarregarGridAmostras();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            CarregarGridAmostras(true);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGridAmostras(true);
        }

        private void btnLimparPesquisa_Click(object sender, EventArgs e)
        {
            txtPesquisar.Text = Convert.ToString("Digite para pesquisar:");
            rbCliente.Checked = false;
            rbEndereco.Checked = false;
            rbAmostra.Checked = false;
            CarregarGridAmostras();
          
        }

        private void btnAmostra_Click(object sender, EventArgs e)
        {
            FrmAmostra amostra = new FrmAmostra();
            amostra.ShowDialog();
            CarregarGridAmostras();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            FrmEstoqueAmostra estoque = new FrmEstoqueAmostra();
            estoque.Show();
        }

        private void dvgAmostra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var prop = new AmostraCliente();
                prop.AmostraId = Convert.ToInt32(dvgAmostra.Rows[e.RowIndex].Cells[0].Value);
                CarregarGridAmostras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);
            }
        }

        private void dvgAmostra_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dvgAmostra.Rows.Count; i++)
            {
                var valor = Convert.ToString(dvgAmostra.Rows[i].Cells[7].Value);
                switch (valor)
                {
                    case "Pendente": dvgAmostra.Rows[i].DefaultCellStyle.BackColor = Color.Yellow; break;
                    case "Finalizado": dvgAmostra.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen; break;
                    case "Cancelado": dvgAmostra.Rows[i].DefaultCellStyle.BackColor = Color.Red; break;
                }
            }
        }

        #region Apenas Metodos
        private void CarregarGridAmostras(bool isPesquisa = false)
        {
            try
            {
                var listaAmostra = new DLAmostra().ListarAmostra();
                if (isPesquisa) //isPesquisa == true
                {
                    var pesquisa = txtPesquisar.Text.ToLower();
                    if (rbCliente.Checked)
                        listaAmostra = listaAmostra.Where(p => p.construtora.ToLower().Contains(pesquisa)).ToList();
                    else if (rbEndereco.Checked)
                        listaAmostra = listaAmostra.Where(p => p.obra.ToLower().Contains(pesquisa)).ToList();
                    else if (rbAmostra.Checked)
                        listaAmostra = listaAmostra.Where(p => p.material.ToLower().Contains(pesquisa)).ToList();
                }
                dvgAmostra.DataSource = listaAmostra.OrderByDescending(p => p.dataentrega).ToList();
                MontarGridAmostra(dvgAmostra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        private void MontarGridAmostra(DataGridView dvgAmostra)
        {
            dvgAmostra.DefaultCellStyle.Font = new Font("Calibri", 16F, GraphicsUnit.Pixel);
            var objBlControleGrid = new ControleGrid(dvgAmostra);
            //Define quais colunas serão visíveis
            objBlControleGrid.DefinirVisibilidade(new List<string>() { "construtora", "dataentrega", "obra", });
            //Define quais os cabeçalhos respectivos das colunas 
            objBlControleGrid.DefinirCabecalhos(new List<string>() { "Cliente / Arqt", "Data da Entrega", "Endereço", });
            //Define quais as larguras respectivas das colunas 
            objBlControleGrid.DefinirLarguras(new List<int>() { 25, 15, 55, }, dvgAmostra.Width - 15); //O total tem que ficar em 100% 
            //Define quais os alinhamentos respectivos do componentes das colunas 
            objBlControleGrid.DefinirAlinhamento(new List<string>() { "esquerda", "esquerda", "esquerda", "esquerda", "esquerda", });
            //Define a altura das linhas respectivas da Grid 
            objBlControleGrid.DefinirAlturaLinha(30);
        }
        #endregion
    }
}
