using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MetodosQuantitativos.Operacoes.Fracoes;

namespace MetodosQuantitativos.ProgLinear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMontarTabela_Click(object sender, EventArgs e)
        {
            var grid = new DataGridView{AutoGenerateColumns = true};
            var qtdVariaveis = int.Parse(tbQtdVariaveis.Text);
            var qtdRestricoes = int.Parse(tbQtdRestricoes.Text);

            var tabela = new TabelaProgramacaoLinear(qtdVariaveis, qtdRestricoes);

            grid.ColumnCount = tabela.LinhaC.Linha.Count;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.MinimumWidth = 50;
            }
            grid.AutoSize = true;
            foreach (var linha in tabela.Linhas)
            {
                var gridLinha = new DataGridViewRow();
                foreach (var coluna in linha)
                {
                    gridLinha.Cells.Add(new DataGridViewTextBoxCell {Value = coluna});
                }
                grid.Rows.Add(gridLinha);
            }
            
            panel1.Controls.Add(grid);
        }
    }

    public class TabelaProgramacaoLinear
    {
        public TabelaProgramacaoLinearLinhaC LinhaC;
        public TabelaProgramacaoLinearLinhaCabecalho LinhaCabecalho;
        public List<TabelaProgramacaoLinearRestricao> LinhasRestricoes;

        public List<List<string>> Linhas
        {
            get
            {
                var linhas = new List<List<string>>();
                linhas.Add(LinhaC.Linha);
                linhas.Add(LinhaCabecalho.Linha);
                foreach (var restricoes in LinhasRestricoes)
                {
                    linhas.Add(restricoes.Linhas);
                }
                return linhas;
            }
        }

        public TabelaProgramacaoLinear(int qtdVariaveis, int qtdRestricoes)
        {
            LinhaC = new TabelaProgramacaoLinearLinhaC(qtdVariaveis);
            LinhaCabecalho = new TabelaProgramacaoLinearLinhaCabecalho(qtdVariaveis);

            LinhasRestricoes = new List<TabelaProgramacaoLinearRestricao>();
            for (int i = 0; i < qtdRestricoes; i++)
            {
                LinhasRestricoes.Add(new TabelaProgramacaoLinearRestricao(qtdVariaveis));
            }
            //linhaZ = new List<object> {"", "Z"};
            //linhaCMenosZ = new List<object> {"", "C - Z"};

            //for (int i = 0; i < qtdVariaveis; i++)
            //{
            //    linhaC.Add("");
            //    linhaCabecalho.Add("");

            //    for
            //    linhaCabecalho.Add("");
            //}
        }
    }

    public class TabelaProgramacaoLinearLinhaC
    {
        public List<FracaoInt> Valores = new List<FracaoInt>();

        public List<string> Linha
        {
            get
            {
                var linha = new List<string> {string.Empty, "C = "};
                linha.AddRange(Valores.Select(x => x != null? x.ToString() : string.Empty));
                linha.AddRange(new [] { string.Empty, string.Empty});
                return linha;
            }
        }

        public TabelaProgramacaoLinearLinhaC(int qtdVariaveis)
        {
            for (var i = 0; i < qtdVariaveis; i++)
            {
                Valores.Add(null);
            }
        }
    }

    public class TabelaProgramacaoLinearLinhaCabecalho
    {
        public List<string> Valores = new List<string>();

        public List<string> Linha
        {
            get
            {
                var linha = new List<string> {"DENTRO", "VALOR"};
                linha.AddRange(Valores.Select(x => x != null? x.ToString() : string.Empty));
                linha.AddRange(new [] { "B", "B/P"});
                return linha;
            }
        }

        public TabelaProgramacaoLinearLinhaCabecalho(int qtdVariaveis)
        {
            for (var i = 0; i < qtdVariaveis; i++)
            {
                Valores.Add(string.Empty);
            }
        }
    }

    public class TabelaProgramacaoLinearRestricao
    {
        private string VariavelDentro = null;
        private FracaoInt ValorDentro = null;

        public List<FracaoInt> Valores = new List<FracaoInt>();

        private FracaoInt ValorB = null;
        private FracaoInt ValorBDivididoP = null;

        public List<string> Linhas
        {
            get
            {
                var linha = new List<string>();
                linha.Add(VariavelDentro ?? string.Empty);
                linha.Add(ValorDentro != null ? ValorDentro.ToString():  string.Empty);
                linha.AddRange(Valores.Select(x => x != null ? x.ToString() : string.Empty));
                linha.Add(ValorB != null ? ValorB.ToString() : string.Empty);
                linha.Add(ValorBDivididoP != null ? ValorBDivididoP.ToString() : string.Empty);
                return linha;
            }
        }

        public TabelaProgramacaoLinearRestricao(int qtdVariaveis)
        {
            for (int i = 0; i < qtdVariaveis; i++)
            {
                Valores.Add(null);
            }
        }
    }
}
