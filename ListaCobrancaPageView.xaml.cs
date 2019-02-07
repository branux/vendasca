using Projeto_Yakult_CA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto_Yakult_CA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaCobrancaPageView : ContentPage
	{
        public List<ListagemClientes> ListaCliente { get; set; }

        public ListaCobrancaPageView (UsuarioModel UserLogin)
		{
			InitializeComponent ();
                        
            BindingContext = new ViewModel.ClientesViewModel(UserLogin);

        }

        private async void LstClientes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _cliente = (ClienteModel)e.Item;
            var escolha = await DisplayActionSheet("Ações de Cobrança", "Cancelar", "Fechar", "Receber Pagamento", "");

            if (escolha == "Receber Pagamento")
            {
                Navigation.PushAsync(new RegVendasView(_cliente));
            }

        }

        
    }
}