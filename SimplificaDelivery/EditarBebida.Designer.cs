namespace SimplificaDelivery
{
    partial class EditarBebida
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
            atualizarBtn = new Button();
            nomeTxt = new TextBox();
            errorProvider = new ErrorProvider(components);
            label2 = new Label();
            valortxt = new TextBox();
            errorProviderValor = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderValor).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 6);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 8;
            label1.Text = "Nome da bebida";
            // 
            // atualizarBtn
            // 
            atualizarBtn.Location = new Point(197, 101);
            atualizarBtn.Name = "atualizarBtn";
            atualizarBtn.Size = new Size(75, 23);
            atualizarBtn.TabIndex = 7;
            atualizarBtn.Text = "Atualizar";
            atualizarBtn.UseVisualStyleBackColor = true;
            atualizarBtn.Click += atualizarBtn_Click;
            // 
            // nomeTxt
            // 
            nomeTxt.Location = new Point(28, 24);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(244, 23);
            nomeTxt.TabIndex = 6;
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
            label2.TabIndex = 10;
            label2.Text = "Valor da bebida";
            // 
            // valortxt
            // 
            valortxt.Location = new Point(28, 72);
            valortxt.Name = "valortxt";
            valortxt.Size = new Size(244, 23);
            valortxt.TabIndex = 9;
            // 
            // errorProviderValor
            // 
            errorProviderValor.ContainerControl = this;
            // 
            // EditarBebida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 136);
            Controls.Add(label2);
            Controls.Add(valortxt);
            Controls.Add(label1);
            Controls.Add(atualizarBtn);
            Controls.Add(nomeTxt);
            Name = "EditarBebida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Bebida";
            Load += EditarBebida_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button atualizarBtn;
        private TextBox nomeTxt;
        private ErrorProvider errorProvider;
        private Label label2;
        private TextBox valortxt;
        private ErrorProvider errorProviderValor;
    }
}