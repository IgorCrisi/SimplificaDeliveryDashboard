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
    public partial class CadastroTamanho : Form
    {
        public CadastroTamanho()
        {
            InitializeComponent();
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
                    errorProviderValor.SetError(valortxt, "O campo de valor deve ser preenchido");
                }
                else
                {
                    string apiUrl = "http://localhost:3333/tamanhos/create";
                    var data = new
                    {
                        nome = nomeTxt.Text,
                        valor = valortxt.Text,
                    };
                    await CreateTamanho(apiUrl, data);
                    this.Close();
                }
            }
        }

        private async void cadastrarBtn_Click(object sender, EventArgs e)
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
                string apiUrl = "http://localhost:3333/tamanhos/create";
                var data = new
                {
                    nome = nomeTxt.Text,
                    valor = valortxt.Text,
                };
                await CreateTamanho(apiUrl, data);
                this.Close();
            }
        }

        private async Task CreateTamanho(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonData = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar a API: {e.Message}");
                }
            }
        }
    }
}
