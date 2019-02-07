using Projeto_Yakult_CA.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Projeto_Yakult_CA
{
    public partial class App : Application
    {
        public UsuarioModel _usuario { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new LoginPage());
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<UsuarioModel>(this, "SucessoLogin", 
                (usuario) =>
                {
                    MainPage = new MasterPage(usuario);
                });

            //MessagingCenter.Subscribe<UsuarioModel>(this, "FalhaLogin",
            //   (usuario) =>
            //   {
            //       MainPage = new LoginPage();
            //       //DisplayAlert("Login", "Usuário Inválido", "OK");                   
            //   });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
