using Projeto_Yakult_CA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projeto_Yakult_CA.Model;

namespace Projeto_Yakult_CA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuscarClienteCadView : ContentPage
	{
        private List<ClienteModel> ListaInternaClientes { get; set; }
        private List<ClienteModel> ListaFiltradaClientes { get; set; }
        private List<ClienteModel> ListaFiltradaEndereco { get; set; }

        public BuscarClienteCadView (UsuarioModel UserLogin)
		{
			InitializeComponent ();
            ListaInternaClientes = new ListagemClientes(UserLogin).clientes;
            ListaClientes.ItemsSource = ListaInternaClientes;

            if (TlgSearch.IsToggled == true)
            {
                TxtSearch.Placeholder = "Pesquisa por Cliente";
            }
            else
            {
                TxtSearch.Placeholder = "Pesquisa por Endereço";
            }


        }

       

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TlgSearch.IsToggled == true)
            {
                ListaFiltradaClientes = ListaInternaClientes.Where(a => a.Nome.ToUpper().Contains((e.NewTextValue).ToUpper())).ToList();
                ListaClientes.ItemsSource = ListaFiltradaClientes;
            }
            else
            {
                ListaFiltradaEndereco = ListaInternaClientes.Where(a => a.Logradouro.ToUpper().Contains((e.NewTextValue).ToUpper())).ToList();
                ListaClientes.ItemsSource = ListaFiltradaEndereco;
            }
            
        }

        

        //private void EditarCommand(object sender, EventArgs e)
        //{
        //    Label lblEditar = (Label)sender;
        //    TapGestureRecognizer TapGest = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
        //    ClienteModel _cliente = TapGest.CommandParameter as ClienteModel;

        //    Navigation.PushAsync(new CadastrarClientePageView(_cliente));
        //}

       

        private void TlgSearch_Toggled(object sender, ToggledEventArgs e)
        {
            if (TlgSearch.IsToggled == true)
            {
                TxtSearch.Placeholder = "Pesquisa por Cliente";
            }
            else
            {
                TxtSearch.Placeholder = "Pesquisa por Endereço";
            }

        }

       
        private async void ListaClientes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _cliente = (ClienteModel)e.Item;

            //Navigation.PushAsync(new DetalhesClienteView(_cliente));

            var escolha = await DisplayActionSheet("Cliente Selecionado" , "Cancelar", "Fechar", "Editar Cadastro", "Excluir Cliente");


            if (escolha == "Editar Cadastro")
            {
                Navigation.PushAsync(new CadastrarClientePageView(_cliente));
            }
            else if (escolha == "Excluir Cliente")
            {
               var excluir = await DisplayAlert("Confirma Exclusão ", "Deseja realmente excluir o cliente - " + _cliente.Nome + " ?", "SIM", "NÃO");
                if (excluir)
                {

                }
                
            }

            

        }
    }
}