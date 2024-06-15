using Newtonsoft.Json;
using System.Text;

namespace SimplificaDelivery
{
    public partial class CadastroIngrediente : Form
    {
        public CadastroIngrediente()
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
                else
                {
                    string apiUrl = "http://localhost:3333/ingredientes/create";
                    var data = new
                    {
                        nome = nomeTxt.Text,
                    };
                    await CreateIngrediente(apiUrl, data);
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
            else
            {
                string apiUrl = "http://localhost:3333/ingredientes/create";
                var data = new
                {
                    nome = nomeTxt.Text,
                };
                await CreateIngrediente(apiUrl, data);
                this.Close();
            }
        }

        private async Task CreateIngrediente(string url, object data)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
