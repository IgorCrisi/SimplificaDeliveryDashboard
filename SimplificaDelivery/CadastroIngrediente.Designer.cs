namespace SimplificaDelivery
{
    partial class CadastroIngrediente
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
            nomeTxt = new TextBox();
            cadastrarBtn = new Button();
            label1 = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // nomeTxt
            // 
            nomeTxt.Location = new Point(26, 24);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(244, 23);
            nomeTxt.TabIndex = 0;
            // 
            // cadastrarBtn
            // 
            cadastrarBtn.Location = new Point(195, 53);
            cadastrarBtn.Name = "cadastrarBtn";
            cadastrarBtn.Size = new Size(75, 23);
            cadastrarBtn.TabIndex = 1;
            cadastrarBtn.Text = "Cadastrar";
            cadastrarBtn.UseVisualStyleBackColor = true;
            cadastrarBtn.Click += cadastrarBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 6);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome do ingrediente";
            label1.Click += label1_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // CadastroIngrediente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 82);
            Controls.Add(label1);
            Controls.Add(cadastrarBtn);
            Controls.Add(nomeTxt);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CadastroIngrediente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de ingrediente";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nomeTxt;
        private Button cadastrarBtn;
        private Label label1;
        private ErrorProvider errorProvider;
    }
}