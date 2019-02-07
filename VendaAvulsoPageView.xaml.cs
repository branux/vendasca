using Projeto_Yakult_CA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Projeto_Yakult_CA.Model.ResumoVendaModel;

namespace Projeto_Yakult_CA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VendaAvulsoPageView : ContentPage
	{
        

        public VendaAvulsoPageView ()
		{
			InitializeComponent ();
            
            this.BindingContext = new ViewModel.VendaAvulsoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Produtos>(this, "FinalizarPedido",
            (msg) =>
            {
                DisplayAlert("Finalizar Pedido",
                       "Deseja Finalizar o Pedido ? "
                       , "OK");

                Navigation.PushAsync(new RegVendasView(null, msg));

            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Produtos>(this, "FinalizarPedido");
        }


        private void OnCalcClicked(object sender, EventArgs e)
        {
          
        }

      

        private void LstProdutos_BindingContextChanged(object sender, EventArgs e)
        {

        }
    }
}