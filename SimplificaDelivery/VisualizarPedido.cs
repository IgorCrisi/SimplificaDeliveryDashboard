using iTextSharp.text.pdf;
using iTextSharp.text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplificaDelivery
{
    public partial class VisualizarPedido : Form
    {
        public string ID { get; private set; }
        public VisualizarPedido(string id)
        {
            InitializeComponent();
            this.Load += new EventHandler(loadData);
            ID = id;
        }

        private async void loadData(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:3333/pedidos/" + ID;
            PedidoData data = await GetPedido(apiUrl);
            setPedido(data);
        }

        private async Task<PedidoData> GetPedido(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PedidoData>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro ao chamar API: {e.Message}");
                    return null;
                }
            }
        }

        private void setPedido(PedidoData data)
        {
            if (data != null)
            {
                ingredienteList.View = View.Details;
                ingredienteList.Columns.Add("Nome", 200);
                bebidaList.View = View.Details;
                bebidaList.Columns.Add("Nome", 200);
                numerolbl.Text = "Número do pedido: " + data.numero.ToString();
                nomelbl.Text = "Nome do cliente: " + data.nome;
                telefonelbl.Text = "Número de telefone do cliente: " + data.telefone;
                enderecolbl.Text = "Endereço de entrega: ";
                enderecotxt.Text = data.endereco;
                tamanholbl.Text = "Tamanho da marmita: " + data.tamanho;
                if (data.credito)
                {
                    formaPagamentolbl.Text = "Forma de pagamento: Crédito";
                }
                if (data.debito)
                {
                    formaPagamentolbl.Text = "Forma de pagamento: Débito";
                }
                if (data.dinheiro)
                {
                    formaPagamentolbl.Text = "Forma de pagamento: Dinheiro";
                    trocolbl.Text = "Troco para: " + data.troco;
                }
                if (data.pix)
                {
                    formaPagamentolbl.Text = "Forma de pagamento: PIX";
                }
                finalizadolbl.Text = data.finalizado ? "Pedido Finalizado" : "Aguardando Pedido";
                totallbl.Text = "Total: R$" + data.total.ToString();
                string format = "yyyy-MM-ddTHH:mm:ss.fffZ";
                DateTime parsedDate = DateTime.ParseExact(data.created_at, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                string dataCriado = parsedDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                feitoEmlbl.Text = "Pedido feito em " + dataCriado;
                for (global::System.Int32 i = 0; i < data.ingredientes.Count; i++)
                {
                    ingredienteList.Items.Add(data.ingredientes[i]);
                }
                for (global::System.Int32 i = 0; i < data.bebidas.Count; i++)
                {
                    bebidaList.Items.Add(data.bebidas[i]);
                }
            }
            else
            {
                MessageBox.Show("Dados do pedido não encontrados.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void VisualizarPedido_Load(object sender, EventArgs e)
        {

        }

        private void nomelbl_Click(object sender, EventArgs e)
        {

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

        private void imprimirBtn_Click(object sender, EventArgs e)
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
    }
}
