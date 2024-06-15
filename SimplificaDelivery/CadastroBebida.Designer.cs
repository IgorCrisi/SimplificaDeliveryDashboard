namespace SimplificaDelivery
{
    partial class CadastroBebida
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
            label1 = new Label();
            cadastrarBtn = new Button();
            nomeTxt = new TextBox();
            errorProvider = new ErrorProvider(components);
            label2 = new Label();
            errorProvider1 = new ErrorProvider(components);
            errorProviderValor = new ErrorProvider(components);
            valortxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderValor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 6);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 5;
            label1.Text = "Nome da bebida";
            // 
            // cadastrarBtn
            // 
            cadastrarBtn.Location = new Point(197, 101);
            cadastrarBtn.Name = "cadastrarBtn";
            cadastrarBtn.Size = new Size(75, 23);
            cadastrarBtn.TabIndex = 4;
            cadastrarBtn.Text = "Cadastrar";
            cadastrarBtn.UseVisualStyleBackColor = true;
            cadastrarBtn.Click += cadastrarBtn_Click;
            // 
            // nomeTxt
            // 
            nomeTxt.Location = new Point(28, 24);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(244, 23);
            nomeTxt.TabIndex = 3;
            nomeTxt.TextChanged += nomeTxt_TextChanged;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 54);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 7;
            label2.Text = "Valor da bebida";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProviderValor
            // 
            errorProviderValor.ContainerControl = this;
            // 
            // valortxt
            // 
            valortxt.Location = new Point(28, 72);
            valortxt.Name = "valortxt";
            valortxt.Size = new Size(244, 23);
            valortxt.TabIndex = 6;
            // 
            // CadastroBebida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 136);
            Controls.Add(label2);
            Controls.Add(valortxt);
            Controls.Add(label1);
            Controls.Add(cadastrarBtn);
            Controls.Add(nomeTxt);
            Name = "CadastroBebida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Bebida";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button cadastrarBtn;
        private TextBox nomeTxt;
        private ErrorProvider errorProvider;
        private Label label2;
        private TextBox valortxt;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProviderValor;
    }
}