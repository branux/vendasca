using Projeto_Yakult_CA.Model;
using Projeto_Yakult_CA.ViewModel;
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
	public partial class MasterPage : MasterDetailPage
	{
        private UsuarioModel UserLogin { get; set; }

        public MasterPage (UsuarioModel usuario)
		{
			InitializeComponent ();
            UserLogin = usuario;
            // navegação inicial
            Detail = new NavigationPage( new PagePrincipalView(UserLogin));
            //this.Detail.Navigation.PushAsync(new PagePrincipalView(usuario));
        }

        private void PaginaPrincipal_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PagePrincipalView(UserLogin) {Title = "Rota de Clientes" });
            IsPresented = false;
        }
        private void VendaAvulso_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new VendaAvulsoPageView() { Title = "Venda Avulso" });
            IsPresented = false;
        }
        private void ListaCobranca_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ListaCobrancaPageView(UserLogin) { Title = "Lista de Cobrança Geral" });
            IsPresented = false;
        }
        private void CadastrarCliente_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Abas.Aba_CadastroCliente(UserLogin) { Title = "Cadastrar / Buscar Cliente" });
            IsPresented = false;
        }

        private void Resumovendas_Clicked(object sender, EventArgs e)
        {

        }

        private void Estoque_Clicked(object sender, EventArgs e)
        {

        }

        private void Financeiro_Clicked(object sender, EventArgs e)
        {

        }

        private void TransmitirVenda_Clicked(object sender, EventArgs e)
        {

        }
    }
}