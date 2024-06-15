namespace SimplificaDelivery
{
    partial class EditarCardapio
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
            components = new System.ComponentModel.Container();
            limparIngredienteBtn = new Button();
            buscarIngredienteBtn = new Button();
            buscaIngredienteTxt = new TextBox();
            limparBebidaBtn = new Button();
            button9 = new Button();
            buscaBebidaTxt = new TextBox();
            cadastrarbtn = new Button();
            removerBebidaBtn = new Button();
            label4 = new Label();
            bebidasAdicionadas = new ListView();
            adicionarBebidaBtn = new Button();
            label5 = new Label();
            bebidasList = new ListView();
            button2 = new Button();
            label3 = new Label();
            ingredientesAdicionadosList = new ListView();
            adicionarIngredienteBtn = new Button();
            label2 = new Label();
            ingredientesList = new ListView();
            label1 = new Label();
            dia = new ComboBox();
            errorProviderDia = new ErrorProvider(components);
            errorProviderIngredientes = new ErrorProvider(components);
            errorProviderBebidas = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderDia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderIngredientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderBebidas).BeginInit();
            SuspendLayout();
            // 
            // limparIngredienteBtn
            // 
            limparIngredienteBtn.Location = new Point(225, 69);
            limparIngredienteBtn.Name = "limparIngredienteBtn";
            limparIngredienteBtn.RightToLeft = RightToLeft.Yes;
            limparIngredienteBtn.Size = new Size(56, 23);
            limparIngredienteBtn.TabIndex = 50;
            limparIngredienteBtn.Text = "Limpar";
            limparIngredienteBtn.UseVisualStyleBackColor = true;
            limparIngredienteBtn.Click += limparIngredienteBtn_Click;
            // 
            // buscarIngredienteBtn
            // 
            buscarIngredienteBtn.Location = new Point(163, 69);
            buscarIngredienteBtn.Name = "buscarIngredienteBtn";
            buscarIngredienteBtn.RightToLeft = RightToLeft.Yes;
            buscarIngredienteBtn.Size = new Size(56, 23);
            buscarIngredienteBtn.TabIndex = 49;
            buscarIngredienteBtn.Text = "Buscar";
            buscarIngredienteBtn.UseVisualStyleBackColor = true;
            buscarIngredienteBtn.Click += buscarIngredienteBtn_Click;
            // 
            // buscaIngredienteTxt
            // 
            buscaIngredienteTxt.Location = new Point(14, 69);
            buscaIngredienteTxt.Name = "buscaIngredienteTxt";
            buscaIngredienteTxt.Size = new Size(143, 23);
            buscaIngredienteTxt.TabIndex = 48;
            // 
            // limparBebidaBtn
            // 
            limparBebidaBtn.Location = new Point(225, 288);
            limparBebidaBtn.Name = "limparBebidaBtn";
            limparBebidaBtn.RightToLeft = RightToLeft.Yes;
            limparBebidaBtn.Size = new Size(56, 23);
            limparBebidaBtn.TabIndex = 47;
            limparBebidaBtn.Text = "Limpar";
            limparBebidaBtn.UseVisualStyleBackColor = true;
            limparBebidaBtn.Click += limparBebidaBtn_Click;
            // 
            // button9
            // 
            button9.Location = new Point(163, 288);
            button9.Name = "button9";
            button9.RightToLeft = RightToLeft.Yes;
            button9.Size = new Size(56, 23);
            button9.TabIndex = 46;
            button9.Text = "Buscar";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // buscaBebidaTxt
            // 
            buscaBebidaTxt.Location = new Point(14, 288);
            buscaBebidaTxt.Name = "buscaBebidaTxt";
            buscaBebidaTxt.Size = new Size(143, 23);
            buscaBebidaTxt.TabIndex = 45;
            // 
            // cadastrarbtn
            // 
            cadastrarbtn.Location = new Point(498, 489);
            cadastrarbtn.Name = "cadastrarbtn";
            cadastrarbtn.Size = new Size(75, 23);
            cadastrarbtn.TabIndex = 44;
            cadastrarbtn.Text = "Atualizar";
            cadastrarbtn.UseVisualStyleBackColor = true;
            cadastrarbtn.Click += cadastrarbtn_Click;
            // 
            // removerBebidaBtn
            // 
            removerBebidaBtn.Location = new Point(297, 460);
            removerBebidaBtn.Name = "removerBebidaBtn";
            removerBebidaBtn.RightToLeft = RightToLeft.Yes;
            removerBebidaBtn.Size = new Size(75, 23);
            removerBebidaBtn.TabIndex = 43;
            removerBebidaBtn.Text = "Remover";
            removerBebidaBtn.UseVisualStyleBackColor = true;
            removerBebidaBtn.Click += removerBebidaBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(294, 296);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 42;
            label4.Text = "Bebidas adicionadas";
            // 
            // bebidasAdicionadas
            // 
            bebidasAdicionadas.Location = new Point(297, 314);
            bebidasAdicionadas.MultiSelect = false;
            bebidasAdicionadas.Name = "bebidasAdicionadas";
            bebidasAdicionadas.Size = new Size(267, 140);
            bebidasAdicionadas.TabIndex = 41;
            bebidasAdicionadas.UseCompatibleStateImageBehavior = false;
            // 
            // adicionarBebidaBtn
            // 
            adicionarBebidaBtn.Location = new Point(14, 460);
            adicionarBebidaBtn.Name = "adicionarBebidaBtn";
            adicionarBebidaBtn.RightToLeft = RightToLeft.Yes;
            adicionarBebidaBtn.Size = new Size(75, 23);
            adicionarBebidaBtn.TabIndex = 40;
            adicionarBebidaBtn.Text = "Adicionar";
            adicionarBebidaBtn.UseVisualStyleBackColor = true;
            adicionarBebidaBtn.Click += adicionarBebidaBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 273);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 39;
            label5.Text = "Bebidas";
            // 
            // bebidasList
            // 
            bebidasList.Location = new Point(14, 314);
            bebidasList.MultiSelect = false;
            bebidasList.Name = "bebidasList";
            bebidasList.Size = new Size(267, 140);
            bebidasList.TabIndex = 38;
            bebidasList.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            button2.Location = new Point(297, 241);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.Yes;
            button2.Size = new Size(75, 23);
            button2.TabIndex = 37;
            button2.Text = "Remover";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(295, 77);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 36;
            label3.Text = "Ingredientes adicionados";
            // 
            // ingredientesAdicionadosList
            // 
            ingredientesAdicionadosList.Location = new Point(297, 95);
            ingredientesAdicionadosList.MultiSelect = false;
            ingredientesAdicionadosList.Name = "ingredientesAdicionadosList";
            ingredientesAdicionadosList.Size = new Size(267, 140);
            ingredientesAdicionadosList.TabIndex = 35;
            ingredientesAdicionadosList.UseCompatibleStateImageBehavior = false;
            // 
            // adicionarIngredienteBtn
            // 
            adicionarIngredienteBtn.Location = new Point(14, 241);
            adicionarIngredienteBtn.Name = "adicionarIngredienteBtn";
            adicionarIngredienteBtn.RightToLeft = RightToLeft.Yes;
            adicionarIngredienteBtn.Size = new Size(75, 23);
            adicionarIngredienteBtn.TabIndex = 34;
            adicionarIngredienteBtn.Text = "Adicionar";
            adicionarIngredienteBtn.UseVisualStyleBackColor = true;
            adicionarIngredienteBtn.Click += adicionarIngredienteBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 33;
            label2.Text = "Ingredientes";
            // 
            // ingredientesList
            // 
            ingredientesList.Location = new Point(14, 95);
            ingredientesList.MultiSelect = false;
            ingredientesList.Name = "ingredientesList";
            ingredientesList.Size = new Size(267, 140);
            ingredientesList.TabIndex = 32;
            ingredientesList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 31;
            label1.Text = "Dia da semana";
            // 
            // dia
            // 
            dia.FormattingEnabled = true;
            dia.Items.AddRange(new object[] { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo" });
            dia.Location = new Point(14, 25);
            dia.Name = "dia";
            dia.Size = new Size(267, 23);
            dia.TabIndex = 30;
            dia.Text = "Selecione um dia";
            // 
            // errorProviderDia
            // 
            errorProviderDia.ContainerControl = this;
            // 
            // errorProviderIngredientes
            // 
            errorProviderIngredientes.ContainerControl = this;
            // 
            // errorProviderBebidas
            // 
            errorProviderBebidas.ContainerControl = this;
            // 
            // EditarCardapio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 521);
            Controls.Add(limparIngredienteBtn);
            Controls.Add(buscarIngredienteBtn);
            Controls.Add(buscaIngredienteTxt);
            Controls.Add(limparBebidaBtn);
            Controls.Add(button9);
            Controls.Add(buscaBebidaTxt);
            Controls.Add(cadastrarbtn);
            Controls.Add(removerBebidaBtn);
            Controls.Add(label4);
            Controls.Add(bebidasAdicionadas);
            Controls.Add(adicionarBebidaBtn);
            Controls.Add(label5);
            Controls.Add(bebidasList);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(ingredientesAdicionadosList);
            Controls.Add(adicionarIngredienteBtn);
            Controls.Add(label2);
            Controls.Add(ingredientesList);
            Controls.Add(label1);
            Controls.Add(dia);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EditarCardapio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Cardápio";
            ((System.ComponentModel.ISupportInitialize)errorProviderDia).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderIngredientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderBebidas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button limparIngredienteBtn;
        private Button buscarIngredienteBtn;
        private TextBox buscaIngredienteTxt;
        private Button limparBebidaBtn;
        private Button button9;
        private TextBox buscaBebidaTxt;
        private Button cadastrarbtn;
        private Button removerBebidaBtn;
        private Label label4;
        private ListView bebidasAdicionadas;
        private Button adicionarBebidaBtn;
        private Label label5;
        private ListView bebidasList;
        private Button button2;
        private Label label3;
        private ListView ingredientesAdicionadosList;
        private Button adicionarIngredienteBtn;
        private Label label2;
        private ListView ingredientesList;
        private Label label1;
        private ComboBox dia;
        private ErrorProvider errorProviderDia;
        private ErrorProvider errorProviderIngredientes;
        private ErrorProvider errorProviderBebidas;
    }
}