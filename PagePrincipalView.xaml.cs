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
   
    public enum Enum_Status_Cliente
    {
        Ausente,NãoComprou, Visitar,JáVisitado
    };

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagePrincipalView : ContentPage
	{
        public List<ListagemClientes> ListaCliente { get; set; }
        

        public PagePrincipalView(UsuarioModel UserLogin)
		{
			InitializeComponent ();

            this.Title = "Rota de Clientes ";
            BindingContext = new ViewModel.ClientesViewModel(UserLogin);
            

        }

        private async void LstClientes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _cliente = (ClienteModel)e.Item;

            //Navigation.PushAsync(new DetalhesClienteView(_cliente));

            var escolha = await DisplayActionSheet("Ações no cliente", "Cancelar", "Fechar", "Ausente", "Não comprou", "Ver Cadastro", "Registrar Venda", "Registrar Pagamento");


            if (escolha == "Ver Cadastro")
            {
                Navigation.PushAsync(new DetalhesClienteView(_cliente));
            }
            else if (escolha == "Registrar Venda")
            {
                Navigation.PushAsync(new ResumoVendasView(_cliente));
            }
            else if (escolha == "Registrar Pagamento")
            {
                Navigation.PushAsync(new RegVendasView(_cliente));
            }
            else if (escolha == "Ausente")
            {
                _cliente.Status_Cliente = "Ausente";
            }
            else if (escolha == "Não comprou")
            {
                _cliente.Status_Cliente = "Não comprou";
            }



        }

        private void VerCadastro_Clicked(object sender, EventArgs e)
        {
            MenuItem btn_cadastro = (MenuItem)sender;
            ClienteModel _cliente = (ClienteModel)btn_cadastro.CommandParameter;            

            Navigation.PushAsync(new DetalhesClienteView(_cliente));

        }

        private void RegistrarVenda_Clicked(object sender, EventArgs e)
        {
            MenuItem btn_venda = (MenuItem)sender;
            ClienteModel _cliente = (ClienteModel)btn_venda.CommandParameter;

            Navigation.PushAsync(new ResumoVendasView(_cliente));
        }

        private void RegistrarPagamento_Clicked(object sender, EventArgs e)
        {
            MenuItem btn_pagamento = (MenuItem)sender;
            ClienteModel _cliente = (ClienteModel)btn_pagamento.CommandParameter;

            Navigation.PushAsync(new RegVendasView(_cliente));
        }
    }
}