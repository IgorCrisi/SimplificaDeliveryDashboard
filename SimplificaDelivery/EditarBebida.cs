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
    public partial class EditarBebida : Form
    {

        public string ID { get; private set; }
        public EditarBebida(string id)
        {
            InitializeComponent();
            this.Load += new EventHandler(loadData);
            ID = id;
            this.KeyPreview = true;
            this.KeyDown += submitEnter;
        }

        private async void submitEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(nomeTxt.Text))
                {
                    errorProvider.SetError(nomeTxt, "O campo de nome deve ser preenchido");
                }
                else
                {
                    string apiUrl = "http://localhost:3333/bebidas/update/" + ID;
                    string novoNome = nomeTxt.Text;

                    bool success = await PatchBebida(apiUrl, novoNome, valortxt.Text);
                    if (success)
                    {
                        this.Close();
                        MessageBox.Show("Bebida atualizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar o Bebida.");
                    }
                }
            }
        }
        private async void loadData(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/bebidas/" + ID;
            bebidaData data = await GetBebida(apiUrl);
            setBebida(data);
        }

        private async Task<bebidaData> GetBebida(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<bebidaData>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return null;
                }
            }
        }

        private void setBebida(bebidaData data)
        {
            if (data != null)
            {
                nomeTxt.Text = data.nome;
                valortxt.Text = data.valor.ToString();
            }
            else
            {
                MessageBox.Show("Dados do Bebida não encontrados.");
            }
        }

        private async void atualizarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomeTxt.Text))
            {
                errorProvider.SetError(nomeTxt, "O campo de nome deve ser preenchido");
            }
            else if (string.IsNullOrWhiteSpace(valortxt.Text))
            {
                errorProviderValor.SetError(valortxt, "O campo de valor deve ser preenchido");
            }
            else
            {
                string apiUrl = "http://localhost:3333/bebidas/update/" + ID;
                string novoNome = nomeTxt.Text;

                bool success = await PatchBebida(apiUrl, novoNome, valortxt.Text);
                if (success)
                {
                    this.Close();
                    MessageBox.Show("Bebida atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o Bebida.");
                }
            }
        }

        private async Task<bool> PatchBebida(string url, string nome, string valor)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = nome,
                        valor = double.Parse(valor)
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

        private void EditarBebida_Load(object sender, EventArgs e)
        {

        }
    }
}
