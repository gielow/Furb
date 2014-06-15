namespace MetodosQuantitativos.ProgLinear
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMontarTabela = new System.Windows.Forms.Button();
            this.tbQtdVariaveis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQtdRestricoes = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnMontarTabela
            // 
            this.btnMontarTabela.Location = new System.Drawing.Point(428, 9);
            this.btnMontarTabela.Name = "btnMontarTabela";
            this.btnMontarTabela.Size = new System.Drawing.Size(121, 23);
            this.btnMontarTabela.TabIndex = 0;
            this.btnMontarTabela.Text = "Montar Tabela";
            this.btnMontarTabela.UseVisualStyleBackColor = true;
            this.btnMontarTabela.Click += new System.EventHandler(this.btnMontarTabela_Click);
            // 
            // tbQtdVariaveis
            // 
            this.tbQtdVariaveis.Location = new System.Drawing.Point(145, 9);
            this.tbQtdVariaveis.Name = "tbQtdVariaveis";
            this.tbQtdVariaveis.Size = new System.Drawing.Size(51, 20);
            this.tbQtdVariaveis.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quantidade de Variáveis:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantidade de Restrições:";
            // 
            // tbQtdRestricoes
            // 
            this.tbQtdRestricoes.Location = new System.Drawing.Point(354, 9);
            this.tbQtdRestricoes.Name = "tbQtdRestricoes";
            this.tbQtdRestricoes.Size = new System.Drawing.Size(51, 20);
            this.tbQtdRestricoes.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(0, 10);
            this.panel1.Location = new System.Drawing.Point(12, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 532);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 592);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbQtdRestricoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbQtdVariaveis);
            this.Controls.Add(this.btnMontarTabela);
            this.Name = "Form1";
            this.Text = "Programação Linear";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMontarTabela;
        private System.Windows.Forms.TextBox tbQtdVariaveis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQtdRestricoes;
        private System.Windows.Forms.Panel panel1;
    }
}

