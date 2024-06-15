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
    public partial class EditarTamanho : Form
    {
        public string ID { get; private set; }
        public EditarTamanho(string id)
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
                else if (string.IsNullOrWhiteSpace(valortxt.Text))
                {
                    errorProvider.SetError(valortxt, "O campo de valor deve ser preenchido");
                }
                else
                {
                    string apiUrl = "http://localhost:3333/tamanhos/update/" + ID;
                    string novoNome = nomeTxt.Text;

                    bool success = await PatchTamanho(apiUrl, novoNome, valortxt.Text);
                    if (success)
                    {
                        this.Close();
                        MessageBox.Show("Tamanho atualizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar o tamanho.");
                    }
                }
            }
        }
        private async void loadData(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/tamanhos/" + ID;
            tamanhoData data = await GetTamanho(apiUrl);
            setTamanho(data);
        }

        private async Task<tamanhoData> GetTamanho(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<tamanhoData>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return null;
                }
            }
        }

        private void setTamanho(tamanhoData data)
        {
            if (data != null)
            {
                nomeTxt.Text = data.nome;
                valortxt.Text = data.valor.ToString();
            }
            else
            {
                MessageBox.Show("Dados do ingrediente não encontrados.");
            }
        }

        private async Task<bool> PatchTamanho(string url, string nome, string valorMarmita)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = nome,
                        valor = double.Parse(valorMarmita)
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

        private async void atualizarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomeTxt.Text))
            {
                errorProvider.SetError(nomeTxt, "O campo de nome deve ser preenchido");
            }
            else if (string.IsNullOrWhiteSpace(valortxt.Text))
            {
                errorProvider.SetError(valortxt, "O campo de valor deve ser preenchido");
            }
            else
            {
                string apiUrl = "http://localhost:3333/tamanhos/update/" + ID;
                string novoNome = nomeTxt.Text;

                bool success = await PatchTamanho(apiUrl, novoNome, valortxt.Text);
                if (success)
                {
                    this.Close();
                    MessageBox.Show("Tamanho atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o tamanho.");
                }
            }
        }
    }
}
