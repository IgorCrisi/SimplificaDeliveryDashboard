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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimplificaDelivery
{
    public partial class CadastroCardapio : Form
    {
        public CadastroCardapio()
        {
            InitializeComponent();
            loadIngredientes();
            loadBebidas();
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
                bebidaItem.SubItems.Add(item.id);
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

        private async void button5_Click(object sender, EventArgs e)
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
                string apiUrl = "http://localhost:3333/cardapios/create";

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

                await CreateCardapio(apiUrl, data);
                this.Close();
            }
        }

        private async Task CreateCardapio(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                }
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

        private void limparIngredienteBtn_Click(object sender, EventArgs e)
        {
            buscaIngredienteTxt.Clear();
            reloadIngredienteData();
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

        private async void reloadbebidaData()
        {
            bebidasList.Items.Clear();
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + 1 + "&limit=9999";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidaList(data);
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/bebidas/busca?page=" + 1 + "&limit=9999";
            List<bebidaData> data = await GetBebidas(apiUrl);
            setBebidaList(data);
        }

        private void limparBebidaBtn_Click(object sender, EventArgs e)
        {
            buscaBebidaTxt.Clear();
            reloadbebidaData();
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
