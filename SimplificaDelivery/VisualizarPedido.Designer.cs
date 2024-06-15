namespace SimplificaDelivery
{
    partial class VisualizarPedido
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
            numerolbl = new Label();
            nomelbl = new Label();
            telefonelbl = new Label();
            enderecolbl = new Label();
            formaPagamentolbl = new Label();
            trocolbl = new Label();
            finalizadolbl = new Label();
            feitoEmlbl = new Label();
            ingredienteList = new ListView();
            label9 = new Label();
            label10 = new Label();
            bebidaList = new ListView();
            enderecotxt = new TextBox();
            tamanholbl = new Label();
            totallbl = new Label();
            imprimirBtn = new Button();
            SuspendLayout();
            // 
            // numerolbl
            // 
            numerolbl.AutoSize = true;
            numerolbl.Location = new Point(12, 9);
            numerolbl.Name = "numerolbl";
            numerolbl.Size = new Size(108, 15);
            numerolbl.TabIndex = 0;
            numerolbl.Text = "Número do pedido";
            numerolbl.Click += label1_Click;
            // 
            // nomelbl
            // 
            nomelbl.AutoSize = true;
            nomelbl.Location = new Point(12, 24);
            nomelbl.Name = "nomelbl";
            nomelbl.Size = new Size(95, 15);
            nomelbl.TabIndex = 1;
            nomelbl.Text = "Nome do cliente";
            nomelbl.Click += nomelbl_Click;
            // 
            // telefonelbl
            // 
            telefonelbl.AutoSize = true;
            telefonelbl.Location = new Point(12, 39);
            telefonelbl.Name = "telefonelbl";
            telefonelbl.Size = new Size(51, 15);
            telefonelbl.TabIndex = 2;
            telefonelbl.Text = "Telefone";
            // 
            // enderecolbl
            // 
            enderecolbl.AutoSize = true;
            enderecolbl.Location = new Point(12, 132);
            enderecolbl.Name = "enderecolbl";
            enderecolbl.Size = new Size(56, 15);
            enderecolbl.TabIndex = 3;
            enderecolbl.Text = "Endereço";
            // 
            // formaPagamentolbl
            // 
            formaPagamentolbl.AutoSize = true;
            formaPagamentolbl.Location = new Point(12, 54);
            formaPagamentolbl.Name = "formaPagamentolbl";
            formaPagamentolbl.Size = new Size(121, 15);
            formaPagamentolbl.TabIndex = 4;
            formaPagamentolbl.Text = "Forma de pagamento";
            // 
            // trocolbl
            // 
            trocolbl.AutoSize = true;
            trocolbl.Location = new Point(198, 54);
            trocolbl.Name = "trocolbl";
            trocolbl.Size = new Size(0, 15);
            trocolbl.TabIndex = 5;
            // 
            // finalizadolbl
            // 
            finalizadolbl.AutoSize = true;
            finalizadolbl.Location = new Point(12, 69);
            finalizadolbl.Name = "finalizadolbl";
            finalizadolbl.Size = new Size(60, 15);
            finalizadolbl.TabIndex = 6;
            finalizadolbl.Text = "Finalizado";
            // 
            // feitoEmlbl
            // 
            feitoEmlbl.AutoSize = true;
            feitoEmlbl.Location = new Point(12, 84);
            feitoEmlbl.Name = "feitoEmlbl";
            feitoEmlbl.Size = new Size(59, 15);
            feitoEmlbl.TabIndex = 7;
            feitoEmlbl.Text = "Feito em: ";
            // 
            // ingredienteList
            // 
            ingredienteList.Location = new Point(12, 276);
            ingredienteList.Name = "ingredienteList";
            ingredienteList.Size = new Size(381, 138);
            ingredienteList.TabIndex = 8;
            ingredienteList.UseCompatibleStateImageBehavior = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 256);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 9;
            label9.Text = "Ingredientes";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 424);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 11;
            label10.Text = "Bebidas";
            label10.Click += label10_Click;
            // 
            // bebidaList
            // 
            bebidaList.Location = new Point(12, 444);
            bebidaList.Name = "bebidaList";
            bebidaList.Size = new Size(381, 138);
            bebidaList.TabIndex = 10;
            bebidaList.UseCompatibleStateImageBehavior = false;
            // 
            // enderecotxt
            // 
            enderecotxt.Enabled = false;
            enderecotxt.Location = new Point(12, 150);
            enderecotxt.Multiline = true;
            enderecotxt.Name = "enderecotxt";
            enderecotxt.Size = new Size(381, 78);
            enderecotxt.TabIndex = 12;
            // 
            // tamanholbl
            // 
            tamanholbl.AutoSize = true;
            tamanholbl.Location = new Point(12, 236);
            tamanholbl.Name = "tamanholbl";
            tamanholbl.Size = new Size(56, 15);
            tamanholbl.TabIndex = 13;
            tamanholbl.Text = "Tamanho";
            // 
            // totallbl
            // 
            totallbl.AutoSize = true;
            totallbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totallbl.Location = new Point(12, 107);
            totallbl.Name = "totallbl";
            totallbl.Size = new Size(43, 17);
            totallbl.TabIndex = 14;
            totallbl.Text = "Total:";
            // 
            // imprimirBtn
            // 
            imprimirBtn.Location = new Point(318, 588);
            imprimirBtn.Name = "imprimirBtn";
            imprimirBtn.Size = new Size(75, 23);
            imprimirBtn.TabIndex = 15;
            imprimirBtn.Text = "Imprimir";
            imprimirBtn.UseVisualStyleBackColor = true;
            imprimirBtn.Click += imprimirBtn_Click;
            // 
            // VisualizarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 617);
            Controls.Add(imprimirBtn);
            Controls.Add(totallbl);
            Controls.Add(tamanholbl);
            Controls.Add(enderecotxt);
            Controls.Add(label10);
            Controls.Add(bebidaList);
            Controls.Add(label9);
            Controls.Add(ingredienteList);
            Controls.Add(feitoEmlbl);
            Controls.Add(finalizadolbl);
            Controls.Add(trocolbl);
            Controls.Add(formaPagamentolbl);
            Controls.Add(enderecolbl);
            Controls.Add(telefonelbl);
            Controls.Add(nomelbl);
            Controls.Add(numerolbl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "VisualizarPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualizar Pedido";
            Load += VisualizarPedido_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label numerolbl;
        private Label nomelbl;
        private Label telefonelbl;
        private Label enderecolbl;
        private Label formaPagamentolbl;
        private Label trocolbl;
        private Label finalizadolbl;
        private Label feitoEmlbl;
        private ListView ingredienteList;
        private Label label9;
        private Label label10;
        private ListView bebidaList;
        private TextBox enderecotxt;
        private Label tamanholbl;
        private Label totallbl;
        private Button imprimirBtn;
    }
}