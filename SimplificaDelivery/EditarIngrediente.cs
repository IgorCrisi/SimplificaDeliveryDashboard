using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;

namespace SimplificaDelivery
{
    public partial class EditarIngrediente : Form
    {

        public string ID { get; private set; }

        public EditarIngrediente(string id)
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
                    string apiUrl = "http://localhost:3333/ingredientes/update/" + ID;
                    string novoNome = nomeTxt.Text;

                    bool success = await PatchIngrediente(apiUrl, novoNome);
                    if (success)
                    {
                        this.Close();
                        MessageBox.Show("Ingrediente atualizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar o ingrediente.");
                    }
                }
            }
        }
        private async void loadData(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/ingredientes/" + ID;
            IngredienteData data = await GetIngrediente(apiUrl);
            setIngrediente(data);
        }

        private async Task<IngredienteData> GetIngrediente(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IngredienteData>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return null;
                }
            }
        }

        private void setIngrediente(IngredienteData data)
        {
            if (data != null)
            {
                nomeTxt.Text = data.nome;
            }
            else
            {
                MessageBox.Show("Dados do ingrediente não encontrados.");
            }
        }

        private async void atualizarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nomeTxt.Text))
            {
                errorProvider.SetError(nomeTxt, "O campo de nome deve ser preenchido");
            }
            else
            {
                string apiUrl = "http://localhost:3333/ingredientes/update/" + ID;
                string novoNome = nomeTxt.Text;

                bool success = await PatchIngrediente(apiUrl, novoNome);
                if (success)
                {
                    this.Close();
                    MessageBox.Show("Ingrediente atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o ingrediente.");
                }
            }
        }

        private async Task<bool> PatchIngrediente(string url, string nome)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        nome = nome
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

        private void EditarIngrediente_Load(object sender, EventArgs e)
        {

        }
    }
}
