using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projeto_Yakult_CA.Interfaces;
using Projeto_Yakult_CA.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto_Yakult_CA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarClientePageView : ContentPage
    {

        public CadastrarClientePageView(ClienteModel cliente = null)
        {
            InitializeComponent();
            imgPerfil.WidthRequest = 70;
            imgPerfil.HeightRequest = 70;
            BindingContext = new ViewModel.CadastroClienteViewModel(cliente);
        }

    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<ClienteModel>(this, "CadastroCliente", (msg) =>
            {

                DisplayAlert("Cadastro de Cliente ",
                    string.Format(
                        @"Nome : {0} Telefone : {1} Endereço: {2} Complemento: {3} Bairro : {4}  Cidade : {5} Estado : {6} Rota : {7}",
                        msg.Nome,msg.Telefone,msg.Logradouro,msg.Complemento,msg.Bairro,msg.Localidade,msg.UF,msg.Rota), "OK"
                        );
            });

            MessagingCenter.Subscribe<ClienteModel>(this, "ErroCEP", (msg) =>
            {
                DisplayAlert("CEP Inválido ",
                    "CEP Inválido! " + msg.Cep
                    , "OK");
            });

            MessagingCenter.Subscribe<ClienteModel>(this, "NomeInvalido", (msg) =>
            {
                DisplayAlert("Campo Nome Inválido! ",
                    "O Campo Nome não pode ser vazio " 
                    , "OK");

                txtNomeCliente.Focus();
            });

            MessagingCenter.Subscribe<ClienteModel>(this, "TelefoneInvalido", (msg) =>
            {
                DisplayAlert("Campo Telefone Inválido! ",
                    "O Campo Telefone não pode ser vazio "
                    , "OK");

                txtTelefone.Focus();
            });

            MessagingCenter.Subscribe<ClienteModel>(this, "RotaInvalido", (msg) =>
            {
                DisplayAlert("Campo Rota Inválido! ",
                    "O Campo Rota não pode ser vazio "
                    , "OK");

                txtNomeCliente.Focus();
            });


        }



        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<ClienteModel>(this, "CadastroCliente");
        }

        private void CEPEntryChangedFocus(object sender, EventArgs e)
        {

        }
        private void Cadastrar_Clicked(object sender, EventArgs e)
        {

        }
    }
}