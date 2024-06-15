using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplificaDelivery
{
    public partial class EditarCardapio : Form
    {
        public string ID { get; private set; }
        public EditarCardapio(string id)
        {
            InitializeComponent();
            this.Load += new EventHandler(loadData);
            ID = id;
            this.KeyPreview = true;
            //this.KeyDown += submitEnter;
            loadIngredientes();
            loadBebidas();
        }

        private async void loadData(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/cardapios/" + ID;
            cardapioData data = await GetCardapio(apiUrl);
            setCardapio(data);
        }

        private async Task<cardapioData> GetCardapio(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Desserializar a resposta inicial
                    cardapioData cardapio = JsonConvert.DeserializeObject<cardapioData>(responseBody);

                    // Desserializar os ingredientes e bebidas novamente
                    cardapio.ingredientes = cardapio.ingredientes
                        .Select(json => JsonConvert.DeserializeObject<IngredienteData>(json))
                        .Select(a => $"{a.nome}")
                        .ToList();

                    cardapio.bebidas = cardapio.bebidas
                        .Select(json => JsonConvert.DeserializeObject<bebidaData>(json))
                        .Select(b => $"{b.nome}: {b.valor:F2}")
                        .ToList();

                    return cardapio;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return null;
                }
                catch (JsonSerializationException e)
                {
                    MessageBox.Show($"Erro ao desserializar a resposta JSON: {e.Message}");
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Erro geral: {e.Message}");
                    return null;
                }
            }
        }




        private void setCardapio(cardapioData data)
        {
            if (data != null)
            {
                dia.Text = data.dia;
                ingredientesAdicionadosList.Items.Clear();
                bebidasAdicionadas.Items.Clear();

                foreach (var ingredienteJson in data.ingredientes)
                {
                    try
                    {
                        var ingredienteItem = new ListViewItem(ingredienteJson);
                        ingredientesAdicionadosList.Items.Add(ingredienteJson);
                    }
                    catch (JsonSerializationException e)
                    {
                        MessageBox.Show($"Erro ao desserializar ingrediente: {e.Message}");
                    }
                }

                foreach (var bebidaJson in data.bebidas)
                {
                    try
                    {
                        var bebidaItem = new ListViewItem(bebidaJson.Split(':')[0]);
                        bebidaItem.SubItems.Add(bebidaJson.Split(':')[1].Split(',')[0]);
                        bebidasAdicionadas.Items.Add(bebidaItem);
                    }
                    catch (JsonSerializationException e)
                    {
                        MessageBox.Show($"Erro ao desserializar bebida: {e.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Dados do cardápio não encontrados.");
            }
        }




        private async void loadIngredientes()
        {
            ingredientesList.Clear();
            ingredientesList.View = View.Details;
            ingredientesList.Columns.Add("Nome", 200);

            ingredientesAdicionadosList.Clear();
            ingredientesAdicionadosList.View = View.Details;
            ingredientesAdicionadosList.Columns.Add("Nome", 200);

            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + 1 + "&limit=9999";
            List<IngredienteData> data = await GetIngredientes(apiUrl);
            setIngredienteList(data);
        }

        private async void loadBebidas()
        {
            bebidasList.Clear();
            bebidasList.View = View.Details;
            bebidasList.Columns.Add("Nome", 200);
            bebidasList.Columns.Add("Valor", 200);

            bebidasAdicionadas.Clear();
            bebidasAdicionadas.View = View.Details;
            bebidasAdicionadas.Columns.Add("Nome", 200);
            bebidasAdicionadas.Columns.Add("Valor", 200);

            string apiUrl = "http://localhost:3333/bebidas/busca?page=1&limit=9999";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidaList(data);
        }

        private async Task<List<bebidaData>> GetBebidas(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = buscaBebidaTxt.Text ?? "",
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

        private void setBebidaList(List<bebidaData> data)
        {
            bebidasList.Items.Clear();
            foreach (var item in data)
            {
                var bebidaItem = new ListViewItem(item.nome);
                bebidaItem.SubItems.Add(item.valor.ToString());
                bebidasList.Items.Add(bebidaItem);
            }
        }

        private async Task<List<IngredienteData>> GetIngredientes(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = buscaIngredienteTxt.Text ?? "",
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
                        List<IngredienteData> cardapios = dataToken.ToObject<List<IngredienteData>>();
                        return cardapios;
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

        private void setIngredienteList(List<IngredienteData> data)
        {
            ingredientesList.Items.Clear();
            foreach (var item in data)
            {
                var ingredienteItem = new ListViewItem(item.nome);
                ingredienteItem.SubItems.Add(item.id);
                ingredientesList.Items.Add(ingredienteItem);
            }
        }

        private List<string> GetListViewItems(System.Windows.Forms.ListView listView)
        {
            List<string> items = new List<string>();
            foreach (ListViewItem item in listView.Items)
            {
                items.Add(item.Text);
            }
            return items;
        }

        private async void cadastrarbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dia.Text) || dia.Text == "Selecione um dia")
            {
                errorProviderDia.SetError(dia, "O campo de dia da semana deve ser preenchido");
            }
            else if (ingredientesAdicionadosList.Items.Count <= 0)
            {
                errorProviderIngredientes.SetError(ingredientesAdicionadosList, "Deve selecionar ao menos um ingrediente");
            }
            else if (bebidasAdicionadas.Items.Count <= 0)
            {
                errorProviderBebidas.SetError(bebidasAdicionadas, "Deve selecionar ao menos uma bebida");
            }
            else
            {
                string apiUrl = "http://localhost:3333/cardapios/update/" + ID;
                bool success = await PatchCardapio(apiUrl);
                if (success)
                {
                    this.Close();
                    MessageBox.Show("Cardápio atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o cardápio.");
                }
            }
        }

        private async Task<bool> PatchCardapio(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var ingredientesList = new List<object>();
                    foreach (ListViewItem item in ingredientesAdicionadosList.Items)
                    {
                        ingredientesList.Add(new
                        {
                            nome = item.SubItems[0].Text,
                        });
                    }

                    var bebidasList = new List<object>();
                    foreach (ListViewItem item in bebidasAdicionadas.Items)
                    {
                        bebidasList.Add(new
                        {
                            nome = item.SubItems[0].Text,
                            valor = item.SubItems[1].Text
                        });
                    }

                    var data = new
                    {
                        dia = dia.Text,
                        ingredientes = ingredientesList,
                        bebidas = bebidasList
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

        private void adicionarIngredienteBtn_Click(object sender, EventArgs e)
        {
            if (ingredientesList.SelectedItems.Count > 0)
            {
                string selectedId = ingredientesList.SelectedItems[0].SubItems[0].Text;
                ingredientesAdicionadosList.Items.Add(selectedId);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async void buscarIngredienteBtn_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + 1 + "&limit=9999";
            List<IngredienteData> data = await GetIngredientes(apiUrl);
            setIngredienteList(data);
        }

        private async void reloadIngredienteData()
        {
            ingredientesList.Items.Clear();
            string apiUrl = "http://localhost:3333/ingredientes/busca?page=" + 1 + "&limit=9999";
            List<IngredienteData> data = await GetIngredientes(apiUrl);
            setIngredienteList(data);
        }

        private async void limparIngredienteBtn_Click(object sender, EventArgs e)
        {
            buscaIngredienteTxt.Clear();
            reloadIngredienteData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ingredientesAdicionadosList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = ingredientesAdicionadosList.SelectedItems[0];
                ingredientesAdicionadosList.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + 1 + "&limit=9999";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidaList(data);
        }

        private async void reloadbebidaData()
        {
            bebidasList.Items.Clear();
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + 1 + "&limit=9999";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidaList(data);
        }

        private void limparBebidaBtn_Click(object sender, EventArgs e)
        {
            buscaBebidaTxt.Clear();
            reloadbebidaData();
        }

        private void adicionarBebidaBtn_Click(object sender, EventArgs e)
        {
            if (bebidasList.SelectedItems.Count > 0)
            {
                string nome = bebidasList.SelectedItems[0].SubItems[0].Text;
                string valor = bebidasList.SelectedItems[0].SubItems[1].Text;
                var bebidaItem = new ListViewItem(nome);
                bebidaItem.SubItems.Add(valor);
                bebidasAdicionadas.Items.Add(bebidaItem);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }

        private void removerBebidaBtn_Click(object sender, EventArgs e)
        {
            if (bebidasAdicionadas.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = bebidasAdicionadas.SelectedItems[0];
                bebidasAdicionadas.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Selecione um item na lista.");
            }
        }
    }

}