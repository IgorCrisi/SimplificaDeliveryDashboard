namespace SimplificaDelivery
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl = new TabControl();
            pedidosPage = new TabPage();
            dataPanel = new Panel();
            label7 = new Label();
            dataTxt = new MaskedTextBox();
            limparDatabtn = new Button();
            confirmarbtn = new Button();
            label6 = new Label();
            alterarDatabtn = new Button();
            pedidosFinalizadosbtn = new Button();
            visualizarBtn = new Button();
            recarregar = new Button();
            concluir = new Button();
            imprimir = new Button();
            pedidosList = new ListView();
            data_lbl = new Label();
            label1 = new Label();
            pedidos_lbl = new Label();
            ingredientes = new TabPage();
            limpar = new Button();
            buscarBtn = new Button();
            pesquisaTxt = new TextBox();
            label2 = new Label();
            paginaAnterior = new Button();
            button1 = new Button();
            recarregar_ingredientes = new Button();
            deletar = new Button();
            editarBtn = new Button();
            cadastrar = new Button();
            ingredienteList = new ListView();
            bebidas = new TabPage();
            limparBebida = new Button();
            buscarBebida = new Button();
            pesquisaTxtBebida = new TextBox();
            label3 = new Label();
            paginaAnteriorBebida = new Button();
            proximaPaginaBebida = new Button();
            recarregar_bebidas = new Button();
            deletarBebida = new Button();
            editarBebidaBtn = new Button();
            cadastrarBebidaBtn = new Button();
            bebidaList = new ListView();
            cardapio = new TabPage();
            limparCardapioBtn = new Button();
            buscaCardapioTxt = new Button();
            pesquisaCardapioTxt = new TextBox();
            label4 = new Label();
            paginaAnteriorCardapio = new Button();
            proximaPaginaCardapio = new Button();
            recarregarCardapioBtn = new Button();
            deletarCardapioBtn = new Button();
            editarCardapioBtn = new Button();
            cadastroCardapioBtn = new Button();
            cardapioList = new ListView();
            tamanhos = new TabPage();
            limparTamanho = new Button();
            buscarTamanho = new Button();
            pesquisaTxtTamanho = new TextBox();
            label5 = new Label();
            paginaAnteriorTamanho = new Button();
            proximaPaginaTamanho = new Button();
            recarregarTamanho = new Button();
            deletarTamanho = new Button();
            editarTamanho = new Button();
            cadastrarTamanho = new Button();
            tamanhoList = new ListView();
            timerReloadPedidos = new System.Windows.Forms.Timer(components);
            tabControl.SuspendLayout();
            pedidosPage.SuspendLayout();
            dataPanel.SuspendLayout();
            ingredientes.SuspendLayout();
            bebidas.SuspendLayout();
            cardapio.SuspendLayout();
            tamanhos.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(pedidosPage);
            tabControl.Controls.Add(ingredientes);
            tabControl.Controls.Add(bebidas);
            tabControl.Controls.Add(cardapio);
            tabControl.Controls.Add(tamanhos);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(802, 452);
            tabControl.SizeMode = TabSizeMode.FillToRight;
            tabControl.TabIndex = 6;
            // 
            // pedidosPage
            // 
            pedidosPage.Controls.Add(dataPanel);
            pedidosPage.Controls.Add(alterarDatabtn);
            pedidosPage.Controls.Add(pedidosFinalizadosbtn);
            pedidosPage.Controls.Add(visualizarBtn);
            pedidosPage.Controls.Add(recarregar);
            pedidosPage.Controls.Add(concluir);
            pedidosPage.Controls.Add(imprimir);
            pedidosPage.Controls.Add(pedidosList);
            pedidosPage.Controls.Add(data_lbl);
            pedidosPage.Controls.Add(label1);
            pedidosPage.Controls.Add(pedidos_lbl);
            pedidosPage.Location = new Point(4, 24);
            pedidosPage.Name = "pedidosPage";
            pedidosPage.Padding = new Padding(3);
            pedidosPage.Size = new Size(794, 424);
            pedidosPage.TabIndex = 0;
            pedidosPage.Text = "Pedidos";
            pedidosPage.UseVisualStyleBackColor = true;
            pedidosPage.Click += pedidosPage_Click;
            // 
            // dataPanel
            // 
            dataPanel.BackColor = Color.Gainsboro;
            dataPanel.BorderStyle = BorderStyle.FixedSingle;
            dataPanel.Controls.Add(label7);
            dataPanel.Controls.Add(dataTxt);
            dataPanel.Controls.Add(limparDatabtn);
            dataPanel.Controls.Add(confirmarbtn);
            dataPanel.Controls.Add(label6);
            dataPanel.Location = new Point(561, 29);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(139, 100);
            dataPanel.TabIndex = 16;
            dataPanel.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(120, 4);
            label7.Name = "label7";
            label7.Size = new Size(14, 13);
            label7.TabIndex = 5;
            label7.Text = "X";
            label7.Click += label7_Click;
            // 
            // dataTxt
            // 
            dataTxt.Location = new Point(5, 22);
            dataTxt.Mask = "00/00/0000";
            dataTxt.Name = "dataTxt";
            dataTxt.Size = new Size(130, 23);
            dataTxt.TabIndex = 4;
            dataTxt.ValidatingType = typeof(DateTime);
            // 
            // limparDatabtn
            // 
            limparDatabtn.Location = new Point(6, 71);
            limparDatabtn.Name = "limparDatabtn";
            limparDatabtn.Size = new Size(75, 23);
            limparDatabtn.TabIndex = 3;
            limparDatabtn.Text = "Limpar";
            limparDatabtn.UseVisualStyleBackColor = true;
            limparDatabtn.Click += limparDatabtn_Click;
            // 
            // confirmarbtn
            // 
            confirmarbtn.Location = new Point(6, 47);
            confirmarbtn.Name = "confirmarbtn";
            confirmarbtn.RightToLeft = RightToLeft.No;
            confirmarbtn.Size = new Size(75, 23);
            confirmarbtn.TabIndex = 2;
            confirmarbtn.Text = "Confirmar";
            confirmarbtn.UseVisualStyleBackColor = true;
            confirmarbtn.Click += confirmarbtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 4);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 0;
            label6.Text = "Nova data";
            // 
            // alterarDatabtn
            // 
            alterarDatabtn.Location = new Point(561, 5);
            alterarDatabtn.Name = "alterarDatabtn";
            alterarDatabtn.Size = new Size(87, 23);
            alterarDatabtn.TabIndex = 15;
            alterarDatabtn.Text = "Alterar data";
            alterarDatabtn.UseVisualStyleBackColor = true;
            alterarDatabtn.Click += alterarDatabtn_Click;
            // 
            // pedidosFinalizadosbtn
            // 
            pedidosFinalizadosbtn.Location = new Point(348, 5);
            pedidosFinalizadosbtn.Name = "pedidosFinalizadosbtn";
            pedidosFinalizadosbtn.Size = new Size(127, 23);
            pedidosFinalizadosbtn.TabIndex = 14;
            pedidosFinalizadosbtn.Text = "Pedidos Finalizados";
            pedidosFinalizadosbtn.UseVisualStyleBackColor = true;
            pedidosFinalizadosbtn.Click += pedidosFinalizadosbtn_Click;
            // 
            // visualizarBtn
            // 
            visualizarBtn.Location = new Point(625, 392);
            visualizarBtn.Name = "visualizarBtn";
            visualizarBtn.Size = new Size(75, 23);
            visualizarBtn.TabIndex = 13;
            visualizarBtn.Text = "Visualizar";
            visualizarBtn.UseVisualStyleBackColor = true;
            visualizarBtn.Click += visualizarBtn_Click;
            // 
            // recarregar
            // 
            recarregar.Location = new Point(481, 5);
            recarregar.Name = "recarregar";
            recarregar.Size = new Size(75, 23);
            recarregar.TabIndex = 12;
            recarregar.Text = "Recarregar";
            recarregar.UseVisualStyleBackColor = true;
            recarregar.Click += button1_Click;
            // 
            // concluir
            // 
            concluir.Location = new Point(499, 392);
            concluir.Name = "concluir";
            concluir.Size = new Size(120, 23);
            concluir.TabIndex = 11;
            concluir.Text = "Concluir pedido";
            concluir.UseVisualStyleBackColor = true;
            concluir.Click += concluir_Click;
            // 
            // imprimir
            // 
            imprimir.Location = new Point(706, 392);
            imprimir.Name = "imprimir";
            imprimir.Size = new Size(75, 23);
            imprimir.TabIndex = 10;
            imprimir.Text = "Imprimir";
            imprimir.UseVisualStyleBackColor = true;
            imprimir.Click += imprimir_Click;
            // 
            // pedidosList
            // 
            pedidosList.FullRowSelect = true;
            pedidosList.Location = new Point(8, 33);
            pedidosList.Name = "pedidosList";
            pedidosList.Size = new Size(773, 353);
            pedidosList.TabIndex = 9;
            pedidosList.UseCompatibleStateImageBehavior = false;
            pedidosList.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // data_lbl
            // 
            data_lbl.AutoSize = true;
            data_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            data_lbl.Location = new Point(694, 7);
            data_lbl.Name = "data_lbl";
            data_lbl.Size = new Size(80, 21);
            data_lbl.TabIndex = 8;
            data_lbl.Text = "Data atual";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(647, 7);
            label1.Name = "label1";
            label1.Size = new Size(50, 21);
            label1.TabIndex = 7;
            label1.Text = "Data:";
            // 
            // pedidos_lbl
            // 
            pedidos_lbl.AutoSize = true;
            pedidos_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pedidos_lbl.Location = new Point(5, 8);
            pedidos_lbl.Name = "pedidos_lbl";
            pedidos_lbl.Size = new Size(71, 21);
            pedidos_lbl.TabIndex = 6;
            pedidos_lbl.Text = "Pedidos";
            pedidos_lbl.Click += pedidos_lbl_Click;
            // 
            // ingredientes
            // 
            ingredientes.Controls.Add(limpar);
            ingredientes.Controls.Add(buscarBtn);
            ingredientes.Controls.Add(pesquisaTxt);
            ingredientes.Controls.Add(label2);
            ingredientes.Controls.Add(paginaAnterior);
            ingredientes.Controls.Add(button1);
            ingredientes.Controls.Add(recarregar_ingredientes);
            ingredientes.Controls.Add(deletar);
            ingredientes.Controls.Add(editarBtn);
            ingredientes.Controls.Add(cadastrar);
            ingredientes.Controls.Add(ingredienteList);
            ingredientes.Location = new Point(4, 24);
            ingredientes.Name = "ingredientes";
            ingredientes.Size = new Size(794, 424);
            ingredientes.TabIndex = 2;
            ingredientes.Text = "Ingredientes";
            ingredientes.UseVisualStyleBackColor = true;
            // 
            // limpar
            // 
            limpar.Location = new Point(294, 8);
            limpar.Name = "limpar";
            limpar.Size = new Size(75, 23);
            limpar.TabIndex = 10;
            limpar.Text = "Limpar";
            limpar.UseVisualStyleBackColor = true;
            limpar.Click += limpar_Click;
            // 
            // buscarBtn
            // 
            buscarBtn.Location = new Point(213, 8);
            buscarBtn.Name = "buscarBtn";
            buscarBtn.Size = new Size(75, 23);
            buscarBtn.TabIndex = 9;
            buscarBtn.Text = "Buscar";
            buscarBtn.UseVisualStyleBackColor = true;
            buscarBtn.Click += buscarBtn_Click;
            // 
            // pesquisaTxt
            // 
            pesquisaTxt.Location = new Point(66, 8);
            pesquisaTxt.Name = "pesquisaTxt";
            pesquisaTxt.Size = new Size(141, 23);
            pesquisaTxt.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 12);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "Pesquisa:";
            // 
            // paginaAnterior
            // 
            paginaAnterior.Location = new Point(8, 391);
            paginaAnterior.Name = "paginaAnterior";
            paginaAnterior.Size = new Size(118, 23);
            paginaAnterior.TabIndex = 6;
            paginaAnterior.Text = "Página Anterior";
            paginaAnterior.UseVisualStyleBackColor = true;
            paginaAnterior.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(666, 391);
            button1.Name = "button1";
            button1.Size = new Size(118, 23);
            button1.TabIndex = 5;
            button1.Text = "Próxima Página";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // recarregar_ingredientes
            // 
            recarregar_ingredientes.Location = new Point(709, 7);
            recarregar_ingredientes.Name = "recarregar_ingredientes";
            recarregar_ingredientes.Size = new Size(75, 23);
            recarregar_ingredientes.TabIndex = 4;
            recarregar_ingredientes.Text = "Recarregar";
            recarregar_ingredientes.UseVisualStyleBackColor = true;
            recarregar_ingredientes.Click += recarregar_ingredientes_Click;
            // 
            // deletar
            // 
            deletar.Location = new Point(285, 391);
            deletar.Name = "deletar";
            deletar.Size = new Size(75, 23);
            deletar.TabIndex = 3;
            deletar.Text = "Deletar";
            deletar.UseVisualStyleBackColor = true;
            deletar.Click += deletar_Click;
            // 
            // editarBtn
            // 
            editarBtn.Location = new Point(366, 391);
            editarBtn.Name = "editarBtn";
            editarBtn.Size = new Size(75, 23);
            editarBtn.TabIndex = 2;
            editarBtn.Text = "Editar";
            editarBtn.UseVisualStyleBackColor = true;
            editarBtn.Click += editarBtn_Click;
            // 
            // cadastrar
            // 
            cadastrar.Location = new Point(447, 391);
            cadastrar.Name = "cadastrar";
            cadastrar.Size = new Size(75, 23);
            cadastrar.TabIndex = 1;
            cadastrar.Text = "Cadastrar";
            cadastrar.UseVisualStyleBackColor = true;
            cadastrar.Click += cadastrar_Click;
            // 
            // ingredienteList
            // 
            ingredienteList.FullRowSelect = true;
            ingredienteList.Location = new Point(8, 38);
            ingredienteList.MultiSelect = false;
            ingredienteList.Name = "ingredienteList";
            ingredienteList.RightToLeftLayout = true;
            ingredienteList.Size = new Size(776, 346);
            ingredienteList.TabIndex = 0;
            ingredienteList.UseCompatibleStateImageBehavior = false;
            ingredienteList.SelectedIndexChanged += ingredienteList_SelectedIndexChanged;
            // 
            // bebidas
            // 
            bebidas.Controls.Add(limparBebida);
            bebidas.Controls.Add(buscarBebida);
            bebidas.Controls.Add(pesquisaTxtBebida);
            bebidas.Controls.Add(label3);
            bebidas.Controls.Add(paginaAnteriorBebida);
            bebidas.Controls.Add(proximaPaginaBebida);
            bebidas.Controls.Add(recarregar_bebidas);
            bebidas.Controls.Add(deletarBebida);
            bebidas.Controls.Add(editarBebidaBtn);
            bebidas.Controls.Add(cadastrarBebidaBtn);
            bebidas.Controls.Add(bebidaList);
            bebidas.Location = new Point(4, 24);
            bebidas.Name = "bebidas";
            bebidas.Size = new Size(794, 424);
            bebidas.TabIndex = 3;
            bebidas.Text = "Bebidas";
            bebidas.UseVisualStyleBackColor = true;
            // 
            // limparBebida
            // 
            limparBebida.Location = new Point(294, 8);
            limparBebida.Name = "limparBebida";
            limparBebida.Size = new Size(75, 23);
            limparBebida.TabIndex = 21;
            limparBebida.Text = "Limpar";
            limparBebida.UseVisualStyleBackColor = true;
            limparBebida.Click += limparBebida_Click;
            // 
            // buscarBebida
            // 
            buscarBebida.Location = new Point(213, 8);
            buscarBebida.Name = "buscarBebida";
            buscarBebida.Size = new Size(75, 23);
            buscarBebida.TabIndex = 20;
            buscarBebida.Text = "Buscar";
            buscarBebida.UseVisualStyleBackColor = true;
            buscarBebida.Click += buscarBebida_Click;
            // 
            // pesquisaTxtBebida
            // 
            pesquisaTxtBebida.Location = new Point(66, 8);
            pesquisaTxtBebida.Name = "pesquisaTxtBebida";
            pesquisaTxtBebida.Size = new Size(141, 23);
            pesquisaTxtBebida.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 12);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 18;
            label3.Text = "Pesquisa:";
            // 
            // paginaAnteriorBebida
            // 
            paginaAnteriorBebida.Location = new Point(8, 391);
            paginaAnteriorBebida.Name = "paginaAnteriorBebida";
            paginaAnteriorBebida.Size = new Size(118, 23);
            paginaAnteriorBebida.TabIndex = 17;
            paginaAnteriorBebida.Text = "Página Anterior";
            paginaAnteriorBebida.UseVisualStyleBackColor = true;
            paginaAnteriorBebida.Click += paginaAnteriorBebida_Click_1;
            // 
            // proximaPaginaBebida
            // 
            proximaPaginaBebida.Location = new Point(666, 391);
            proximaPaginaBebida.Name = "proximaPaginaBebida";
            proximaPaginaBebida.Size = new Size(118, 23);
            proximaPaginaBebida.TabIndex = 16;
            proximaPaginaBebida.Text = "Próxima Página";
            proximaPaginaBebida.UseVisualStyleBackColor = true;
            proximaPaginaBebida.Click += proximaPaginaBebida_Click;
            // 
            // recarregar_bebidas
            // 
            recarregar_bebidas.Location = new Point(709, 7);
            recarregar_bebidas.Name = "recarregar_bebidas";
            recarregar_bebidas.Size = new Size(75, 23);
            recarregar_bebidas.TabIndex = 15;
            recarregar_bebidas.Text = "Recarregar";
            recarregar_bebidas.UseVisualStyleBackColor = true;
            recarregar_bebidas.Click += recarregar_bebidas_Click_1;
            // 
            // deletarBebida
            // 
            deletarBebida.Location = new Point(285, 391);
            deletarBebida.Name = "deletarBebida";
            deletarBebida.Size = new Size(75, 23);
            deletarBebida.TabIndex = 14;
            deletarBebida.Text = "Deletar";
            deletarBebida.UseVisualStyleBackColor = true;
            deletarBebida.Click += deletarBebida_Click_1;
            // 
            // editarBebidaBtn
            // 
            editarBebidaBtn.Location = new Point(366, 391);
            editarBebidaBtn.Name = "editarBebidaBtn";
            editarBebidaBtn.Size = new Size(75, 23);
            editarBebidaBtn.TabIndex = 13;
            editarBebidaBtn.Text = "Editar";
            editarBebidaBtn.UseVisualStyleBackColor = true;
            editarBebidaBtn.Click += editarBebidaBtn_Click_1;
            // 
            // cadastrarBebidaBtn
            // 
            cadastrarBebidaBtn.Location = new Point(447, 391);
            cadastrarBebidaBtn.Name = "cadastrarBebidaBtn";
            cadastrarBebidaBtn.Size = new Size(75, 23);
            cadastrarBebidaBtn.TabIndex = 12;
            cadastrarBebidaBtn.Text = "Cadastrar";
            cadastrarBebidaBtn.UseVisualStyleBackColor = true;
            cadastrarBebidaBtn.Click += cadastrarBebidaBtn_Click;
            // 
            // bebidaList
            // 
            bebidaList.FullRowSelect = true;
            bebidaList.Location = new Point(8, 38);
            bebidaList.MultiSelect = false;
            bebidaList.Name = "bebidaList";
            bebidaList.RightToLeftLayout = true;
            bebidaList.Size = new Size(776, 346);
            bebidaList.TabIndex = 11;
            bebidaList.UseCompatibleStateImageBehavior = false;
            // 
            // cardapio
            // 
            cardapio.Controls.Add(limparCardapioBtn);
            cardapio.Controls.Add(buscaCardapioTxt);
            cardapio.Controls.Add(pesquisaCardapioTxt);
            cardapio.Controls.Add(label4);
            cardapio.Controls.Add(paginaAnteriorCardapio);
            cardapio.Controls.Add(proximaPaginaCardapio);
            cardapio.Controls.Add(recarregarCardapioBtn);
            cardapio.Controls.Add(deletarCardapioBtn);
            cardapio.Controls.Add(editarCardapioBtn);
            cardapio.Controls.Add(cadastroCardapioBtn);
            cardapio.Controls.Add(cardapioList);
            cardapio.Location = new Point(4, 24);
            cardapio.Name = "cardapio";
            cardapio.RightToLeft = RightToLeft.No;
            cardapio.Size = new Size(794, 424);
            cardapio.TabIndex = 5;
            cardapio.Text = "Cardápios";
            cardapio.UseVisualStyleBackColor = true;
            // 
            // limparCardapioBtn
            // 
            limparCardapioBtn.Location = new Point(294, 8);
            limparCardapioBtn.Name = "limparCardapioBtn";
            limparCardapioBtn.Size = new Size(75, 23);
            limparCardapioBtn.TabIndex = 21;
            limparCardapioBtn.Text = "Limpar";
            limparCardapioBtn.UseVisualStyleBackColor = true;
            limparCardapioBtn.Click += limparCardapioBtn_Click;
            // 
            // buscaCardapioTxt
            // 
            buscaCardapioTxt.Location = new Point(213, 8);
            buscaCardapioTxt.Name = "buscaCardapioTxt";
            buscaCardapioTxt.Size = new Size(75, 23);
            buscaCardapioTxt.TabIndex = 20;
            buscaCardapioTxt.Text = "Buscar";
            buscaCardapioTxt.UseVisualStyleBackColor = true;
            buscaCardapioTxt.Click += buscaCardapioTxt_Click;
            // 
            // pesquisaCardapioTxt
            // 
            pesquisaCardapioTxt.Location = new Point(66, 8);
            pesquisaCardapioTxt.Name = "pesquisaCardapioTxt";
            pesquisaCardapioTxt.Size = new Size(141, 23);
            pesquisaCardapioTxt.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 12);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 18;
            label4.Text = "Pesquisa:";
            // 
            // paginaAnteriorCardapio
            // 
            paginaAnteriorCardapio.Location = new Point(8, 391);
            paginaAnteriorCardapio.Name = "paginaAnteriorCardapio";
            paginaAnteriorCardapio.Size = new Size(118, 23);
            paginaAnteriorCardapio.TabIndex = 17;
            paginaAnteriorCardapio.Text = "Página Anterior";
            paginaAnteriorCardapio.UseVisualStyleBackColor = true;
            paginaAnteriorCardapio.Click += paginaAnteriorCardapio_Click;
            // 
            // proximaPaginaCardapio
            // 
            proximaPaginaCardapio.Location = new Point(666, 391);
            proximaPaginaCardapio.Name = "proximaPaginaCardapio";
            proximaPaginaCardapio.Size = new Size(118, 23);
            proximaPaginaCardapio.TabIndex = 16;
            proximaPaginaCardapio.Text = "Próxima Página";
            proximaPaginaCardapio.UseVisualStyleBackColor = true;
            proximaPaginaCardapio.Click += proximaPaginaCardapio_Click;
            // 
            // recarregarCardapioBtn
            // 
            recarregarCardapioBtn.Location = new Point(709, 7);
            recarregarCardapioBtn.Name = "recarregarCardapioBtn";
            recarregarCardapioBtn.Size = new Size(75, 23);
            recarregarCardapioBtn.TabIndex = 15;
            recarregarCardapioBtn.Text = "Recarregar";
            recarregarCardapioBtn.UseVisualStyleBackColor = true;
            recarregarCardapioBtn.Click += recarregarCardapioBtn_Click;
            // 
            // deletarCardapioBtn
            // 
            deletarCardapioBtn.Location = new Point(285, 391);
            deletarCardapioBtn.Name = "deletarCardapioBtn";
            deletarCardapioBtn.Size = new Size(75, 23);
            deletarCardapioBtn.TabIndex = 14;
            deletarCardapioBtn.Text = "Deletar";
            deletarCardapioBtn.UseVisualStyleBackColor = true;
            deletarCardapioBtn.Click += deletarCardapioBtn_Click;
            // 
            // editarCardapioBtn
            // 
            editarCardapioBtn.Location = new Point(366, 391);
            editarCardapioBtn.Name = "editarCardapioBtn";
            editarCardapioBtn.Size = new Size(75, 23);
            editarCardapioBtn.TabIndex = 13;
            editarCardapioBtn.Text = "Editar";
            editarCardapioBtn.UseVisualStyleBackColor = true;
            editarCardapioBtn.Click += editarCardapioBtn_Click;
            // 
            // cadastroCardapioBtn
            // 
            cadastroCardapioBtn.Location = new Point(447, 391);
            cadastroCardapioBtn.Name = "cadastroCardapioBtn";
            cadastroCardapioBtn.Size = new Size(75, 23);
            cadastroCardapioBtn.TabIndex = 12;
            cadastroCardapioBtn.Text = "Cadastrar";
            cadastroCardapioBtn.UseVisualStyleBackColor = true;
            cadastroCardapioBtn.Click += cadastroCardapioBtn_Click;
            // 
            // cardapioList
            // 
            cardapioList.FullRowSelect = true;
            cardapioList.Location = new Point(8, 38);
            cardapioList.MultiSelect = false;
            cardapioList.Name = "cardapioList";
            cardapioList.RightToLeftLayout = true;
            cardapioList.Size = new Size(776, 346);
            cardapioList.TabIndex = 11;
            cardapioList.UseCompatibleStateImageBehavior = false;
            // 
            // tamanhos
            // 
            tamanhos.Controls.Add(limparTamanho);
            tamanhos.Controls.Add(buscarTamanho);
            tamanhos.Controls.Add(pesquisaTxtTamanho);
            tamanhos.Controls.Add(label5);
            tamanhos.Controls.Add(paginaAnteriorTamanho);
            tamanhos.Controls.Add(proximaPaginaTamanho);
            tamanhos.Controls.Add(recarregarTamanho);
            tamanhos.Controls.Add(deletarTamanho);
            tamanhos.Controls.Add(editarTamanho);
            tamanhos.Controls.Add(cadastrarTamanho);
            tamanhos.Controls.Add(tamanhoList);
            tamanhos.Location = new Point(4, 24);
            tamanhos.Name = "tamanhos";
            tamanhos.Size = new Size(794, 424);
            tamanhos.TabIndex = 4;
            tamanhos.Text = "Tamanhos de marmita";
            tamanhos.UseVisualStyleBackColor = true;
            // 
            // limparTamanho
            // 
            limparTamanho.Location = new Point(294, 8);
            limparTamanho.Name = "limparTamanho";
            limparTamanho.Size = new Size(75, 23);
            limparTamanho.TabIndex = 21;
            limparTamanho.Text = "Limpar";
            limparTamanho.UseVisualStyleBackColor = true;
            limparTamanho.Click += limparTamanho_Click;
            // 
            // buscarTamanho
            // 
            buscarTamanho.Location = new Point(213, 8);
            buscarTamanho.Name = "buscarTamanho";
            buscarTamanho.Size = new Size(75, 23);
            buscarTamanho.TabIndex = 20;
            buscarTamanho.Text = "Buscar";
            buscarTamanho.UseVisualStyleBackColor = true;
            buscarTamanho.Click += buscarTamanho_Click;
            // 
            // pesquisaTxtTamanho
            // 
            pesquisaTxtTamanho.Location = new Point(66, 8);
            pesquisaTxtTamanho.Name = "pesquisaTxtTamanho";
            pesquisaTxtTamanho.Size = new Size(141, 23);
            pesquisaTxtTamanho.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 12);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 18;
            label5.Text = "Pesquisa:";
            // 
            // paginaAnteriorTamanho
            // 
            paginaAnteriorTamanho.Location = new Point(8, 391);
            paginaAnteriorTamanho.Name = "paginaAnteriorTamanho";
            paginaAnteriorTamanho.Size = new Size(118, 23);
            paginaAnteriorTamanho.TabIndex = 17;
            paginaAnteriorTamanho.Text = "Página Anterior";
            paginaAnteriorTamanho.UseVisualStyleBackColor = true;
            paginaAnteriorTamanho.Click += paginaAnteriorTamanho_Click;
            // 
            // proximaPaginaTamanho
            // 
            proximaPaginaTamanho.Location = new Point(666, 391);
            proximaPaginaTamanho.Name = "proximaPaginaTamanho";
            proximaPaginaTamanho.Size = new Size(118, 23);
            proximaPaginaTamanho.TabIndex = 16;
            proximaPaginaTamanho.Text = "Próxima Página";
            proximaPaginaTamanho.UseVisualStyleBackColor = true;
            proximaPaginaTamanho.Click += proximaPaginaTamanho_Click_1;
            // 
            // recarregarTamanho
            // 
            recarregarTamanho.Location = new Point(709, 7);
            recarregarTamanho.Name = "recarregarTamanho";
            recarregarTamanho.Size = new Size(75, 23);
            recarregarTamanho.TabIndex = 15;
            recarregarTamanho.Text = "Recarregar";
            recarregarTamanho.UseVisualStyleBackColor = true;
            recarregarTamanho.Click += recarregarTamanho_Click;
            // 
            // deletarTamanho
            // 
            deletarTamanho.Location = new Point(285, 391);
            deletarTamanho.Name = "deletarTamanho";
            deletarTamanho.Size = new Size(75, 23);
            deletarTamanho.TabIndex = 14;
            deletarTamanho.Text = "Deletar";
            deletarTamanho.UseVisualStyleBackColor = true;
            deletarTamanho.Click += deletarTamanho_Click;
            // 
            // editarTamanho
            // 
            editarTamanho.Location = new Point(366, 391);
            editarTamanho.Name = "editarTamanho";
            editarTamanho.Size = new Size(75, 23);
            editarTamanho.TabIndex = 13;
            editarTamanho.Text = "Editar";
            editarTamanho.UseVisualStyleBackColor = true;
            editarTamanho.Click += editarTamanho_Click;
            // 
            // cadastrarTamanho
            // 
            cadastrarTamanho.Location = new Point(447, 391);
            cadastrarTamanho.Name = "cadastrarTamanho";
            cadastrarTamanho.Size = new Size(75, 23);
            cadastrarTamanho.TabIndex = 12;
            cadastrarTamanho.Text = "Cadastrar";
            cadastrarTamanho.UseVisualStyleBackColor = true;
            cadastrarTamanho.Click += cadastrarTamanho_Click;
            // 
            // tamanhoList
            // 
            tamanhoList.FullRowSelect = true;
            tamanhoList.Location = new Point(8, 38);
            tamanhoList.Name = "tamanhoList";
            tamanhoList.RightToLeftLayout = true;
            tamanhoList.Size = new Size(776, 346);
            tamanhoList.TabIndex = 11;
            tamanhoList.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simplifica Delivery";
            tabControl.ResumeLayout(false);
            pedidosPage.ResumeLayout(false);
            pedidosPage.PerformLayout();
            dataPanel.ResumeLayout(false);
            dataPanel.PerformLayout();
            ingredientes.ResumeLayout(false);
            ingredientes.PerformLayout();
            bebidas.ResumeLayout(false);
            bebidas.PerformLayout();
            cardapio.ResumeLayout(false);
            cardapio.PerformLayout();
            tamanhos.ResumeLayout(false);
            tamanhos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage pedidosPage;
        private Button concluir;
        private Button imprimir;
        private ListView pedidosList;
        private Label data_lbl;
        private Label label1;
        private Label pedidos_lbl;
        private TabPage ingredientes;
        private TabPage bebidas;
        private TabPage cardapio;
        private TabPage tamanhos;
        private Button recarregar;
        private Button recarregar_ingredientes;
        private Button deletar;
        private Button editarBtn;
        private Button cadastrar;
        private ListView ingredienteList;
        private Button paginaAnterior;
        private Button button1;
        private Label label2;
        private Button buscarBtn;
        private TextBox pesquisaTxt;
        private Button limpar;
        private Button limparBebida;
        private Button buscarBebida;
        private TextBox pesquisaTxtBebida;
        private Label label3;
        private Button paginaAnteriorBebida;
        private Button proximaPaginaBebida;
        private Button recarregar_bebidas;
        private Button deletarBebida;
        private Button editarBebidaBtn;
        private Button cadastrarBebidaBtn;
        private ListView bebidaList;
        private Button limparCardapioBtn;
        private Button buscaCardapioTxt;
        private TextBox pesquisaCardapioTxt;
        private Label label4;
        private Button paginaAnteriorCardapio;
        private Button proximaPaginaCardapio;
        private Button recarregarCardapioBtn;
        private Button deletarCardapioBtn;
        private Button editarCardapioBtn;
        private Button cadastroCardapioBtn;
        private ListView cardapioList;
        private Button limparTamanho;
        private Button buscarTamanho;
        private TextBox pesquisaTxtTamanho;
        private Label label5;
        private Button paginaAnteriorTamanho;
        private Button proximaPaginaTamanho;
        private Button recarregarTamanho;
        private Button deletarTamanho;
        private Button editarTamanho;
        private Button cadastrarTamanho;
        private ListView tamanhoList;
        private Button visualizarBtn;
        private Button pedidosFinalizadosbtn;
        private Button alterarDatabtn;
        private Panel dataPanel;
        private Button limparDatabtn;
        private Button confirmarbtn;
        private Label label6;
        private MaskedTextBox dataTxt;
        private Label label7;
        private System.Windows.Forms.Timer timerReloadPedidos;
    }
}
