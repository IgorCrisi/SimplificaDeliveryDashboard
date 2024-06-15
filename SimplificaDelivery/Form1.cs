using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.DataFormats;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing.Printing;
using System.Media;
using System.Reflection;


namespace SimplificaDelivery
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.timerReloadPedidos.Interval = 30000;
            this.timerReloadPedidos.Tick += new EventHandler(this.Timer_Tick);
            this.timerReloadPedidos.Start();
            this.Load += new EventHandler(loadData);
            InitializeListView();
            tabControl.SelectedIndexChanged += new EventHandler(TabControl_SelectedIndexChanged);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            reloadPedidoData();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == ingredientes)
            {
                page = 1;
                loadIngredientes();
            }
            else if (tabControl.SelectedTab == bebidas)
            {
                page = 1;
                loadBebidas();
            }
            else if (tabControl.SelectedTab == cardapio)
            {
                page = 1;
                loadCardapios();
            }
            else if (tabControl.SelectedTab == tamanhos)
            {
                page = 1;
                loadTamanhos();
            }
        }

        private async void loadData(object sender, EventArgs e)
        {
            string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
            data_lbl.Text = todayDate;
        }

        //Ingrediente
        int page = 1;
        private async void loadIngredientes()
        {
            ingredienteList.Clear();
            ingredienteList.View = View.Details;
            ingredienteList.Columns.Add("Nome", 200);

            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + page + "&limit=15";
            List<IngredienteData> data = await Getingredientes(apiUrl);
            setIngredientesList(data);
        }

        private async Task<List<IngredienteData>> Getingredientes(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = pesquisaTxt.Text ?? "",
                    };

                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);
                    JToken dataToken = jsonResponse["data"];
                    if (dataToken != null)
                    {
                        List<IngredienteData> ingredientes = dataToken.ToObject<List<IngredienteData>>();
                        return ingredientes;
                    }
                    else
                    {
                        MessageBox.Show("O campo 'data' não foi encontrado na resposta JSON ou é nulo.");
                        return new List<IngredienteData>();
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return new List<IngredienteData>();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (page != 1)
            {
                page = page - 1;
                string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + page + "&limit=15";
                List<IngredienteData> data = await Getingredientes(apiUrl);
                setIngredientesList(data);
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            page = page + 1;
            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + page + "&limit=15";
            List<IngredienteData> data = await Getingredientes(apiUrl);
            setIngredientesList(data);
        }

        private async void buscarBtn_Click(object sender, EventArgs e)
        {
            page = 1;
            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + page + "&limit=15";
            List<IngredienteData> data = await Getingredientes(apiUrl);
            setIngredientesList(data);
        }


        private async void limpar_Click(object sender, EventArgs e)
        {
            pesquisaTxt.Text = "";
            page = 1;
            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + page + "&limit=15";
            List<IngredienteData> data = await Getingredientes(apiUrl);
            setIngredientesList(data);
        }

        private async void reloadIngredienteData()
        {
            ingredienteList.Items.Clear();
            page = 1;
            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + page + "&limit=15";
            List<IngredienteData> data = await Getingredientes(apiUrl);
            setIngredientesList(data);
        }

        private void setIngredientesList(List<IngredienteData> data)
        {
            ingredienteList.Items.Clear();
            foreach (var item in data)
            {
                var listViewItem = new ListViewItem(item.nome);
                listViewItem.SubItems.Add(item.id);
                ingredienteList.Items.Add(listViewItem);
            }
        }

        private async void recarregar_ingredientes_Click(object sender, EventArgs e)
        {
            reloadIngredienteData();
        }

        private void editarBtn_Click(object sender, EventArgs e)
        {
            if (ingredienteList.SelectedItems.Count > 0)
            {
                string selectedId = ingredienteList.SelectedItems[0].SubItems[1].Text;
                EditarIngrediente editarIngrediente = new EditarIngrediente(selectedId);
                editarIngrediente.FormClosed += EditarIngrediente_FormClosed;
                editarIngrediente.Show();
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async void EditarIngrediente_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadIngredienteData();
        }

        private async void cadastrar_Click(object sender, EventArgs e)
        {
            CadastroIngrediente cadastroIngrediente = new CadastroIngrediente();
            cadastroIngrediente.FormClosed += CadastroIngrediente_FormClosed;
            cadastroIngrediente.Show();
        }

        private async void CadastroIngrediente_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadIngredienteData();
        }

        private async void deletar_Click(object sender, EventArgs e)
        {
            if (ingredienteList.SelectedItems.Count > 0)
            {
                string selectedId = ingredienteList.SelectedItems[0].SubItems[1].Text;
                string apiUrl = "http://localhost:3333/ingredientes/delete/" + selectedId;
                await deleteIngrediente(apiUrl);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async Task deleteIngrediente(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Item deletado com sucesso!");
                    reloadIngredienteData();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao deletar o item: {e.Message}");
                }
            }
        }

        private void ingredienteList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Bebidas
        private async void loadBebidas()
        {
            bebidaList.Clear();
            bebidaList.View = View.Details;
            bebidaList.Columns.Add("Nome", 200);
            bebidaList.Columns.Add("Valor", 200);

            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + page + "&limit=15";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidasList(data);
        }

        private async Task<List<bebidaData>> GetBebidas(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = pesquisaTxtBebida.Text ?? "",
                    };

                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);
                    JToken dataToken = jsonResponse["data"];
                    if (dataToken != null)
                    {
                        List<bebidaData> bebidas = dataToken.ToObject<List<bebidaData>>();
                        return bebidas;
                    }
                    else
                    {
                        MessageBox.Show("O campo 'data' não foi encontrado na resposta JSON ou é nulo.");
                        return new List<bebidaData>();
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return new List<bebidaData>();
                }
            }
        }

        private async void paginaAnteriorBebida_Click_1(object sender, EventArgs e)
        {
            if (page != 1)
            {
                page = page - 1;
                string apiUrl = "http://localhost:3333/bebidas/busca?page=" + page + "&limit=15";
                List<bebidaData> data = await GetBebidas(apiUrl);
                setBebidasList(data);
            }
        }

        private async void proximaPaginaBebida_Click(object sender, EventArgs e)
        {
            page = page + 1;
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + page + "&limit=15";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidasList(data);
        }

        private async void buscarBebida_Click(object sender, EventArgs e)
        {
            page = 1;
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + page + "&limit=15";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidasList(data);
        }

        private async void limparBebida_Click(object sender, EventArgs e)
        {
            pesquisaTxtBebida.Text = "";
            page = 1;
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + page + "&limit=15";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidasList(data);
        }

        private async void reloadbebidaData()
        {
            bebidaList.Items.Clear();
            page = 1;
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + page + "&limit=15";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidasList(data);
        }

        private void setBebidasList(List<bebidaData> data)
        {
            bebidaList.Items.Clear();
            foreach (var item in data)
            {
                var bebidaItem = new ListViewItem(item.nome);
                bebidaItem.SubItems.Add(item.valor.ToString());
                bebidaItem.SubItems.Add(item.id);
                bebidaList.Items.Add(bebidaItem);
            }
        }

        private async void recarregar_bebidas_Click_1(object sender, EventArgs e)
        {
            reloadbebidaData();
        }

        private void editarBebidaBtn_Click_1(object sender, EventArgs e)
        {
            if (bebidaList.SelectedItems.Count > 0)
            {
                string selectedId = bebidaList.SelectedItems[0].SubItems[2].Text;
                EditarBebida editarBebida = new EditarBebida(selectedId);
                editarBebida.FormClosed += EditarBebida_FormClosed;
                editarBebida.Show();
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async void EditarBebida_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadbebidaData();
        }

        private async void cadastrarBebidaBtn_Click(object sender, EventArgs e)
        {
            CadastroBebida cadastroBebida = new CadastroBebida();
            cadastroBebida.FormClosed += CadastroBebida_FormClosed;
            cadastroBebida.Show();
        }

        private async void CadastroBebida_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadbebidaData();
        }

        private async void deletarBebida_Click_1(object sender, EventArgs e)
        {
            if (bebidaList.SelectedItems.Count > 0)
            {
                string selectedId = bebidaList.SelectedItems[0].SubItems[2].Text;
                string apiUrl = "http://localhost:3333/bebidas/delete/" + selectedId;
                await deleteBebida(apiUrl);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async Task deleteBebida(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Item deletado com sucesso!");
                    reloadbebidaData();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao deletar o item: {e.Message}");
                }
            }
        }

        private void bebidaList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Tamanhos de marmita
        private async void loadTamanhos()
        {
            tamanhoList.Clear();
            tamanhoList.View = View.Details;
            tamanhoList.Columns.Add("Nome", 200);
            tamanhoList.Columns.Add("Valor", 200);

            string apiUrl = "http://localhost:3333/tamanhos/busca?page=" + page + "&limit=15";
            List<tamanhoData> data = await GetTamanhos(apiUrl);
            setTamanhoList(data);
        }

        private async Task<List<tamanhoData>> GetTamanhos(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = pesquisaTxtTamanho.Text ?? "",
                    };

                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);
                    JToken dataToken = jsonResponse["data"];
                    if (dataToken != null)
                    {
                        List<tamanhoData> tamanhos = dataToken.ToObject<List<tamanhoData>>();
                        return tamanhos;
                    }
                    else
                    {
                        MessageBox.Show("O campo 'data' não foi encontrado na resposta JSON ou é nulo.");
                        return new List<tamanhoData>();
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return new List<tamanhoData>();
                }
            }
        }

        private void setTamanhoList(List<tamanhoData> data)
        {
            tamanhoList.Items.Clear();
            foreach (var item in data)
            {
                var tamanhoItem = new ListViewItem(item.nome);
                tamanhoItem.SubItems.Add(item.valor.ToString());
                tamanhoItem.SubItems.Add(item.id);
                tamanhoList.Items.Add(tamanhoItem);
            }
        }

        private async void paginaAnteriorTamanho_Click(object sender, EventArgs e)
        {
            if (page != 1)
            {
                page = page - 1;
                string apiUrl = "http://localhost:3333/tamanhos/busca?page=" + page + "&limit=15";
                List<tamanhoData> data = await GetTamanhos(apiUrl);
                setTamanhoList(data);
            }
        }

        private async void proximaPaginaTamanho_Click_1(object sender, EventArgs e)
        {
            page = page + 1;
            string apiUrl = "http://localhost:3333/tamanhos/busca?page=" + page + "&limit=15";
            List<tamanhoData> data = await GetTamanhos(apiUrl);
            setTamanhoList(data);
        }

        private async void buscarTamanho_Click(object sender, EventArgs e)
        {
            page = 1;
            string apiUrl = "http://localhost:3333/tamanhos/busca?page=" + page + "&limit=15";
            List<tamanhoData> data = await GetTamanhos(apiUrl);
            setTamanhoList(data);
        }

        private async void limparTamanho_Click(object sender, EventArgs e)
        {
            reloadTamanhoData();
        }

        private async void recarregarTamanho_Click(object sender, EventArgs e)
        {
            reloadTamanhoData();
        }

        private async void reloadTamanhoData()
        {
            tamanhoList.Items.Clear();
            pesquisaTxtTamanho.Clear();
            page = 1;
            string apiUrl = "http://localhost:3333/tamanhos/busca?page=" + page + "&limit=15";
            List<tamanhoData> data = await GetTamanhos(apiUrl);
            setTamanhoList(data);
        }

        private void editarTamanho_Click(object sender, EventArgs e)
        {
            if (tamanhoList.SelectedItems.Count > 0)
            {
                string selectedId = tamanhoList.SelectedItems[0].SubItems[2].Text;
                EditarTamanho editarTamanho = new EditarTamanho(selectedId);
                editarTamanho.FormClosed += EditarTamanho_FormClosed;
                editarTamanho.Show();
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async void EditarTamanho_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadTamanhoData();
        }

        private void cadastrarTamanho_Click(object sender, EventArgs e)
        {
            CadastroTamanho cadastroTamanho = new CadastroTamanho();
            cadastroTamanho.FormClosed += CadastroTamanho_FormClosed;
            cadastroTamanho.Show();
        }

        private async void CadastroTamanho_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadTamanhoData();
        }

        private async void deletarTamanho_Click(object sender, EventArgs e)
        {
            if (tamanhoList.SelectedItems.Count > 0)
            {
                string selectedId = tamanhoList.SelectedItems[0].SubItems[2].Text;
                string apiUrl = "http://localhost:3333/tamanhos/delete/" + selectedId;
                await deleteTamanho(apiUrl);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async Task deleteTamanho(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Item deletado com sucesso!");
                    reloadTamanhoData();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao deletar o item: {e.Message}");
                }
            }
        }

        //Cardapio
        private async void loadCardapios()
        {
            cardapioList.Clear();
            cardapioList.View = View.Details;
            cardapioList.Columns.Add("Dia da semana", 200);

            string apiUrl = "http://localhost:3333/cardapios/busca?page=" + page + "&limit=15";
            List<cardapioData> data = await GetCardapios(apiUrl);
            setCardapioList(data);
        }

        private async Task<List<cardapioData>> GetCardapios(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        dia = pesquisaCardapioTxt.Text ?? "",
                    };

                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);
                    JToken dataToken = jsonResponse["data"];
                    if (dataToken != null)
                    {
                        List<cardapioData> cardapios = dataToken.ToObject<List<cardapioData>>();

                        foreach (var cardapio in cardapios)
                        {
                            cardapio.ingredientes = cardapio.ingredientes
                                .Select(json => JsonConvert.DeserializeObject<IngredienteData>(json).nome)
                                .ToList();

                            cardapio.bebidas = cardapio.bebidas
                                .Select(json => JsonConvert.DeserializeObject<bebidaData>(json))
                                .Select(b => $"{b.nome}: {b.valor:F2}")
                                .ToList();
                        }

                        return cardapios;
                    }
                    else
                    {
                        MessageBox.Show("O campo 'data' não foi encontrado na resposta JSON ou é nulo.");
                        return new List<cardapioData>();
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return new List<cardapioData>();
                }
                catch (JsonSerializationException e)
                {
                    MessageBox.Show($"Erro ao desserializar a resposta JSON: {e.Message}");
                    return new List<cardapioData>();
                }
            }
        }



        private void setCardapioList(List<cardapioData> data)
        {
            cardapioList.Items.Clear();
            foreach (var item in data)
            {
                var cardapioItem = new ListViewItem(item.dia);
                cardapioItem.SubItems.Add(item.id);
                cardapioList.Items.Add(cardapioItem);
            }
        }



        private async void paginaAnteriorCardapio_Click(object sender, EventArgs e)
        {
            if (page != 1)
            {
                page = page - 1;
                string apiUrl = "http://localhost:3333/cardapios/busca?page=" + page + "&limit=15";
                List<cardapioData> data = await GetCardapios(apiUrl);
                setCardapioList(data);
            }
        }

        private async void proximaPaginaCardapio_Click(object sender, EventArgs e)
        {
            page = page + 1;
            string apiUrl = "http://localhost:3333/cardapios/busca?page=" + page + "&limit=15";
            List<cardapioData> data = await GetCardapios(apiUrl);
            setCardapioList(data);
        }

        private async void buscaCardapioTxt_Click(object sender, EventArgs e)
        {
            page = 1;
            string apiUrl = "http://localhost:3333/cardapios/busca?page=" + page + "&limit=15";
            List<cardapioData> data = await GetCardapios(apiUrl);
            setCardapioList(data);
        }

        private async void reloadcardapioData()
        {
            cardapioList.Items.Clear();
            pesquisaCardapioTxt.Clear();
            page = 1;
            string apiUrl = "http://localhost:3333/cardapios/busca?page=" + page + "&limit=15";
            List<cardapioData> data = await GetCardapios(apiUrl);
            setCardapioList(data);
        }

        private void limparCardapioBtn_Click(object sender, EventArgs e)
        {
            pesquisaCardapioTxt.Clear();
            reloadcardapioData();
        }

        private void recarregarCardapioBtn_Click(object sender, EventArgs e)
        {
            pesquisaCardapioTxt.Clear();
            reloadcardapioData();
        }

        private void editarCardapioBtn_Click(object sender, EventArgs e)
        {
            if (cardapioList.SelectedItems.Count > 0)
            {
                string selectedId = cardapioList.SelectedItems[0].SubItems[1].Text;
                EditarCardapio editarCardapio = new EditarCardapio(selectedId);
                editarCardapio.FormClosed += EditarCardapio_FormClosed;
                editarCardapio.Show();
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async void EditarCardapio_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadcardapioData();
        }

        private void cadastroCardapioBtn_Click(object sender, EventArgs e)
        {
            CadastroCardapio cadastroCardapio = new CadastroCardapio();
            cadastroCardapio.FormClosed += CadastroCardapio_FormClosed;
            cadastroCardapio.Show();
        }

        private async void CadastroCardapio_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadcardapioData();
        }

        private async void deletarCardapioBtn_Click(object sender, EventArgs e)
        {
            if (cardapioList.SelectedItems.Count > 0)
            {
                string selectedId = cardapioList.SelectedItems[0].SubItems[1].Text;
                string apiUrl = "http://localhost:3333/cardapios/delete/" + selectedId;
                await deleteCardapio(apiUrl);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async Task deleteCardapio(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Item deletado com sucesso!");
                    reloadcardapioData();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao deletar o item: {e.Message}");
                }
            }
        }

        private void pedidos_lbl_Click(object sender, EventArgs e)
        {

        }

        //Pedidos
        private int lastItemCount = 0;
        bool finalizado = false;
        private async void InitializeListView()
        {
            pedidosList.View = View.Details;
            pedidosList.Columns.Add("Número", 50);
            pedidosList.Columns.Add("Nome", 200);
            pedidosList.Columns.Add("Telefone", 200);
            pedidosList.Columns.Add("Status", 200);
            pedidosList.Columns.Add("Feito em", 200);

            page = 1;
            string apiUrl = "http://localhost:3333/pedidos/busca?page=" + page + "&limit=9999";
            if (dataTxt.Text != "  /  /")
            {
                List<PedidoData> data = await GetPedidos(apiUrl, false, dataTxt.Text);
                setPedidosList(data);
            }
            else
            {
                string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
                List<PedidoData> data = await GetPedidos(apiUrl, false, todayDate);
                setPedidosList(data);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            page = 1;
            string apiUrl = "http://localhost:3333/pedidos/busca?page=" + page + "&limit=9999";
            if (dataTxt.Text != "  /  /")
            {
                List<PedidoData> data = await GetPedidos(apiUrl, false, dataTxt.Text);
                setPedidosList(data);
            }
            else
            {
                string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
                List<PedidoData> data = await GetPedidos(apiUrl, false, todayDate);
                setPedidosList(data);
            }
        }
        private async Task<List<PedidoData>> GetPedidos(string url, bool finalizado, string dataBusca)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = "",
                        numero = "",
                        finalizado = finalizado,
                        data = dataBusca
                    };

                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseBody);
                    JToken dataToken = jsonResponse["data"];
                    if (dataToken != null)
                    {
                        List<PedidoData> pedidos = dataToken.ToObject<List<PedidoData>>();
                        return pedidos;
                    }
                    else
                    {
                        MessageBox.Show("O campo 'data' não foi encontrado na resposta JSON ou é nulo.");
                        return new List<PedidoData>();
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return new List<PedidoData>();
                }
            }
        }

        private void setPedidosList(List<PedidoData> data)
        {
            pedidosList.Items.Clear();
            foreach (var item in data)
            {
                var pedidoItem = new ListViewItem(item.numero.ToString());
                pedidoItem.SubItems.Add(item.nome);
                pedidoItem.SubItems.Add(item.telefone);
                pedidoItem.SubItems.Add(item.finalizado ? "Finalizado" : "Aguardando");
                string format = "MM/dd/yyyy HH:mm:ss";
                DateTime parsedDate = DateTime.ParseExact(item.created_at, format, CultureInfo.InvariantCulture);
                string dataCriado = parsedDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                pedidoItem.SubItems.Add(dataCriado);
                pedidoItem.SubItems.Add(item.id);
                pedidosList.Items.Add(pedidoItem);
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pedidosPage_Click(object sender, EventArgs e)
        {

        }

        private void visualizarBtn_Click(object sender, EventArgs e)
        {
            if (pedidosList.SelectedItems.Count > 0)
            {
                string selectedId = pedidosList.SelectedItems[0].SubItems[5].Text;
                VisualizarPedido visualizarPedido = new VisualizarPedido(selectedId);
                visualizarPedido.FormClosed += VisualizarPedido_FormClosed;
                visualizarPedido.Show();
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async void reloadPedidoData()
        {
            int previousItemCount = this.pedidosList.Items.Count;
            pedidosList.Items.Clear();
            page = 1;
            string apiUrl = "http://localhost:3333/pedidos/busca?page=" + page + "&limit=9999";
            if (dataTxt.Text != "  /  /")
            {
                List<PedidoData> data = await GetPedidos(apiUrl, finalizado, dataTxt.Text);
                setPedidosList(data);
            }
            else
            {
                string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
                List<PedidoData> data = await GetPedidos(apiUrl, finalizado, todayDate);
                setPedidosList(data);
            }
            int currentItemCount = this.pedidosList.Items.Count;
            if (currentItemCount > previousItemCount)
            {
                PlaySound();
            }
        }

        private void PlaySound()
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Ring01.wav");
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tocar o som: " + ex.Message);
            }
        }

        private async void VisualizarPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            reloadPedidoData();
        }

        private async void concluir_Click(object sender, EventArgs e)
        {
            if (pedidosList.SelectedItems.Count > 0)
            {
                string selectedId = pedidosList.SelectedItems[0].SubItems[5].Text;
                string apiUrl = "http://localhost:3333/pedidos/setFinalizado/" + selectedId;

                bool success = await ConcluirPedido(apiUrl, pedidosList.SelectedItems[0].Index);
                if (success)
                {
                    MessageBox.Show("Pedido concluido com sucesso!");
                    reloadPedidoData();
                }
                else
                {
                    MessageBox.Show("Erro ao concluir o pedido.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async Task<bool> ConcluirPedido(string url, int index)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        finalizado = true,
                    };

                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
                    {
                        Content = content
                    };

                    HttpResponseMessage response = await client.SendAsync(request);
                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return false;
                }
            }
        }

        private async void pedidosFinalizadosbtn_Click(object sender, EventArgs e)
        {
            if (finalizado)
            {
                finalizado = false;
                pedidosFinalizadosbtn.Text = "Pedidos Finalizados";
                concluir.Enabled = true;
                recarregar.Enabled = true;
            }
            else
            {
                finalizado = true;
                pedidosFinalizadosbtn.Text = "Pedidos Aguardando";
                concluir.Enabled = false;
                recarregar.Enabled = false;
            }
            pedidosList.Items.Clear();
            page = 1;
            string apiUrl = "http://localhost:3333/pedidos/busca?page=" + page + "&limit=9999";
            if (dataTxt.Text != "  /  /")
            {
                List<PedidoData> data = await GetPedidos(apiUrl, finalizado, dataTxt.Text);
                setPedidosList(data);
            }
            else
            {
                string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
                List<PedidoData> data = await GetPedidos(apiUrl, finalizado, todayDate);
                setPedidosList(data);
            }
        }

        public static void GeneratePdf(string filePath)
        {
            iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(58 * 2.83465f, 100 * 2.83465f);

            Document document = new Document(pageSize);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            document.Open();

            document.Add(new Paragraph("Aqui será gerado o pdf"));

            document.Close();
            writer.Close();
        }

        public static void PrintPdf(string filePath)
        {
            using (var document = PdfiumViewer.PdfDocument.Load(filePath))
            {
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.PrinterSettings.PrinterName = "Nome da Impressora";
                    printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", 58, 100);

                    printDocument.Print();
                }
            }
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            /*
            string filePath = Path.Combine(Path.GetTempPath(), "temp.pdf");

            // Gerar PDF
            GeneratePdf(filePath);

            // Imprimir PDF
            PrintPdf(filePath);

            MessageBox.Show("PDF gerado e enviado para impressão.");
            */
        }

        private void alterarDatabtn_Click(object sender, EventArgs e)
        {
            if (dataPanel.Visible == false)
            {
                dataPanel.Visible = true;
            }
            else
            {
                dataPanel.Visible = false;
            }

        }

        private async void confirmarbtn_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/pedidos/busca?page=" + page + "&limit=9999";
            if (dataTxt.Text != "  /  /")
            {
                data_lbl.Text = dataTxt.Text;
                List<PedidoData> data = await GetPedidos(apiUrl, finalizado, dataTxt.Text);
                setPedidosList(data);
            }
            else
            {
                string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
                data_lbl.Text = todayDate;
                List<PedidoData> data = await GetPedidos(apiUrl, finalizado, todayDate);
                setPedidosList(data);
            }
        }

        private async void limparDatabtn_Click(object sender, EventArgs e)
        {
            dataTxt.Text = "  /  /";
            string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
            data_lbl.Text = todayDate;
            string apiUrl = "http://localhost:3333/pedidos/busca?page=" + page + "&limit=9999";
            List<PedidoData> data = await GetPedidos(apiUrl, finalizado, todayDate);
            setPedidosList(data);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            dataPanel.Visible = false;
        }
    }
    public class PedidoData
    {
        public string id { get; set; }
        public int numero { get; set; }
        public string tamanho { get; set; }
        public List<string> ingredientes { get; set; }
        public List<string> bebidas { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public bool credito { get; set; }
        public bool debito { get; set; }
        public bool dinheiro { get; set; }
        public bool pix { get; set; }
        public string troco { get; set; }
        public bool finalizado { get; set; }
        public double total { get; set; }
        public string created_at { get; set; }
    }

    public class IngredienteData
    {
        public string id { get; set; }
        public string nome { get; set; }
    }

    public class bebidaData
    {
        public string id { get; set; }
        public string nome { get; set; }

        public double valor { get; set; }
    }

    public class tamanhoData
    {
        public string id { get; set; }
        public string nome { get; set; }

        public double valor { get; set; }
    }

    public class cardapioData
    {
        public string id { get; set; }
        public string dia { get; set; }
        public List<string> ingredientes { get; set; }
        public List<string> bebidas { get; set; }
    }
}
