using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace temperatura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btCarregar_Click(object sender, EventArgs e)
        {
            ReiniciarGrafico();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var nomeArquivo = openFileDialog.FileName;
                    tbNomeArquivo.Text = nomeArquivo;
                    var dados = LerArquivoCSV(nomeArquivo);
                    DesenharGrafico(dados);
                }
            }
        }

        private void ReiniciarGrafico()
        {
            grafico.Series.Clear();
        }

        private List<DadoTemperatura> LerArquivoCSV(string nomeArquivo)
        {
            try
            {
                var dados = new List<DadoTemperatura>();

                using (var reader = new StreamReader(nomeArquivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linha = reader.ReadLine();
                        if (linha.Contains("\t\t\t"))
                        {
                            linha = linha.Replace("\t\t\t", ",");
                            var infos = linha.Split(',');
                            if (infos.Length == 2)
                            {
                                var temperatura = double.Parse(infos[0], new CultureInfo("en-US"));
                                var tempo = int.Parse(infos[1]);

                                dados.Add(new DadoTemperatura(tempo, temperatura));
                            }
                        }
                    }
                }

                return dados;
            }
            catch
            {
                MessageBox.Show("Ocooreu um erro ao ler o arquivo. Verifique se o arquivo está em um formato correto");
                return null;
            }
        }

        private void DesenharGrafico(List<DadoTemperatura> dados)
        {
            var series = new Series("Temperatura");
            series.ChartType = SeriesChartType.Line;
            series.IsValueShownAsLabel = true;
            series.Points.DataBindXY(
                dados.Select(item => item.Tempo).ToArray(), 
                dados.Select(item => item.Temperatura).ToArray()
            );
            grafico.Series.Add(series);
        }

        private void grafico_Click(object sender, EventArgs e)
        {

        }
    }
}
