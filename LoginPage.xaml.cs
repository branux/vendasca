using Projeto_Yakult_CA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projeto_Yakult_CA
{
    public partial class LoginPage : ContentPage
    {
       

        public LoginPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<UsuarioModel>(this, "FalhaLogin",
            async (exc) =>
            {
                await DisplayAlert("Login", "Login Inválido", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<UsuarioModel>(this, "FalhaLogin");
        }

        //private void btnLogin_Clicked(object sender, EventArgs e)
        //{
        //    if ((txtusuario.Text == "caio" || txtusuario.Text == "william" || txtusuario.Text == "adm") && txtsenha.Text == "123")
        //    {
        //        //Navigation.PushAsync(new NavigationPage(new MasterPage()) );   
        //        MessagingCenter.Send<UsuarioModel>(new UsuarioModel(), "SucessoLogin");
        //        //Application.Current.MainPage = new MasterPage();
        //    }
        //    else
        //    {
        //        DisplayAlert("Login", "Usuário Inválido", "OK");
        //    }
        //}
    }
}
