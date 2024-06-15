namespace SimplificaDelivery
{
    partial class EditarIngrediente
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
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 6);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 5;
            label1.Text = "Nome do ingrediente";
            // 
            // atualizarBtn
            // 
            atualizarBtn.Location = new Point(194, 53);
            atualizarBtn.Name = "atualizarBtn";
            atualizarBtn.Size = new Size(75, 23);
            atualizarBtn.TabIndex = 4;
            atualizarBtn.Text = "Atualizar";
            atualizarBtn.UseVisualStyleBackColor = true;
            atualizarBtn.Click += this.atualizarBtn_Click;
            // 
            // nomeTxt
            // 
            nomeTxt.Location = new Point(25, 24);
            nomeTxt.Name = "nomeTxt";
            nomeTxt.Size = new Size(244, 23);
            nomeTxt.TabIndex = 3;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EditarIngrediente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 82);
            Controls.Add(label1);
            Controls.Add(atualizarBtn);
            Controls.Add(nomeTxt);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EditarIngrediente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Ingrediente";
            Load += EditarIngrediente_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button atualizarBtn;
        private TextBox nomeTxt;
        private ErrorProvider errorProvider;
    }
}