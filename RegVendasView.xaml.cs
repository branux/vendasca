using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projeto_Yakult_CA.Model;
using Projeto_Yakult_CA.ViewModel;
using static Projeto_Yakult_CA.Model.ResumoVendaModel;

namespace Projeto_Yakult_CA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegVendasView : ContentPage
    {
        public ClienteModel Cliente { get; set; }
        public ClientesViewModel ViewModel { get; set; }

        public RegVendasView(ClienteModel cliente = null, Produtos produto = null)
        {
            InitializeComponent();
            if (cliente != null)
            {
                Cliente = cliente;
                this.Title = Cliente.Nome;
                txtSaldoAnterior.Text = cliente.Saldo.ToString();
            }

            if (produto != null)
            {
                this.Title = "Venda Avulso";
                txtVlrTotal.Text = produto.ValorTotal;
            }

          
        }

        public decimal CalcTotal = 0;

        public bool credito = true;

        private void Calcular_Clicked(object sender, EventArgs e)
        {
            decimal VlrTotal = Convert.ToDecimal( txtVlrTotal.Text);
            decimal VlrSaldoAnt = Convert.ToDecimal(txtSaldoAnterior.Text);
            decimal VlrPago = Convert.ToDecimal(txtVlrPago.Text);
            
            bool Calcular = true;

            TxtVlrTroco.Text = "";
            txtVlrCalculo.Text = "";            

            if (Calcular)
            {
                CalcTotal = ((VlrTotal + VlrSaldoAnt) - VlrPago) * -1;
                if(CalcTotal > 0)
                {
                    TxtVlrTroco.Text = CalcTotal.ToString("N2");
                    txtVlrCalculo.Text = "0";
                    BtnEnviarTroco.IsEnabled = true;
                    BtnEnviarTroco.Image = "setas_troco.png";
                    Cliente.Saldo = CalcTotal;
                }
                else
                {
                    TxtVlrTroco.Text = "0";
                    txtVlrCalculo.Text = CalcTotal.ToString("N2");
                    Cliente.Saldo = CalcTotal;
                    credito = false;
                }
            }
            
        }
        
        private async void FinalizarPgto_Clicked(object sender, EventArgs e)
        {
            string comp_mensagem = "";

            if (TxtVlrTroco.Text != "0" )
            {
                comp_mensagem = "e troco entregue ao cliente de R$ " + CalcTotal.ToString("N2");
            }
            else
            {
                if (credito)
                {
                    comp_mensagem = "e inserido crédito ao cliente de R$ " + CalcTotal.ToString("N2");
                }
                else
                {
                    comp_mensagem = "e inserido débito ao cliente de R$ " + CalcTotal.ToString("N2");
                }
            }

            await DisplayAlert("Finalizar Pagamento", "Pagamento efetuado " + comp_mensagem, "Finalizar");
            //Navigation.PushAsync(new PagePrincipalView(Cliente));
        }

        private void BtnEnviarTroco_Clicked(object sender, EventArgs e)
        {
            decimal VlrTroco = Convert.ToDecimal(TxtVlrTroco.Text);
            decimal VlrCalculo = Convert.ToDecimal(txtVlrCalculo.Text);

            if (VlrTroco > 0 )
            {
                TxtVlrTroco.Text = "0";
                txtVlrCalculo.Text = VlrTroco.ToString("N2");
                BtnDevolverTroco.IsVisible = true;
                BtnEnviarTroco.IsVisible = false;
            }
            else
            {
                DisplayAlert("Repasse de Troco", "Não existe troco disponível para crédito", "Fechar");
            }
        }

        private void BtnDevolverTroco_Clicked(object sender, EventArgs e)
        {
            decimal VlrTroco = Convert.ToDecimal(TxtVlrTroco.Text);
            decimal VlrCalculo = Convert.ToDecimal(txtVlrCalculo.Text);

            if (VlrCalculo > 0)
            {
                txtVlrCalculo.Text = "0";
                TxtVlrTroco.Text = VlrCalculo.ToString("N2");
                
                BtnDevolverTroco.IsVisible = false;
                BtnEnviarTroco.IsVisible = true;
            }
            else
            {
                DisplayAlert("Devolução do Troco", "Não existe troco disponível para devolução", "Fechar");
                
            }

        }
    }
}