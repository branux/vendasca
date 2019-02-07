using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;
using System.ComponentModel;

using Projeto_Yakult_CA.Classe;
using Projeto_Yakult_CA.Model;
using static Projeto_Yakult_CA.Model.ResumoVendaModel;

using Projeto_Yakult_CA.ViewModel;
using System.Diagnostics;

namespace Projeto_Yakult_CA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResumoVendasView : ContentPage
    {
        private ResumovendaViewModel ViewModel { get; set; }

        public ResumoVendasView(ClienteModel cliente )
        {
            InitializeComponent();

            if (cliente != null)
            {
                this.Title = cliente.Nome;
            }
            else
            {
                this.Title = "Venda Avulso.";
            }
            this.ViewModel = new ResumovendaViewModel();
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Produtos>(this, "FinalizarPedido",
            (msg) =>
            {
                Navigation.PushAsync(new RegVendasView(null, msg));

            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Produtos>(this, "FinalizarPedido");
        }


      
    }



}