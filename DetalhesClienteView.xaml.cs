using Projeto_Yakult_CA.Dao;
using Projeto_Yakult_CA.Interfaces;
using Projeto_Yakult_CA.Model;
using Projeto_Yakult_CA.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static Projeto_Yakult_CA.ResumoVendasView;

namespace Projeto_Yakult_CA
{

   /* public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }*/


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesClienteView : ContentPage
	{
        private ClienteModel _cliente { get; set; }
       /* public ICommand TirarFotoCommand { get; private set; }
        private ImageSource fotoPerfil = "profile.png";
        private string caminhoFoto = "";
        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set { fotoPerfil = value; OnPropertyChanged(); }
        }*/



        //public List<Produtos> Produto { get; set; }

        public DetalhesClienteView (ClienteModel cliente)
		{
            double saldo_atual = 5.75;
			InitializeComponent();
            this.Title = cliente.Nome;
            imgPerfil.WidthRequest = 70;
            imgPerfil.HeightRequest = 70;

            lblSaldo.Text = cliente.Nome + " seu saldo atual é de R$ " + saldo_atual;
            this._cliente = cliente;
            DefinirComandos();
           /* this.Produto = new List<Produtos>
            {
                new Produtos {NomeProduto = "Yakult", ValorProduto=Produtos.VLR_YAK.ToString("N2"),LocalImagemProduto="yakult.jpg" , QtdeProduto=0},
                new Produtos {NomeProduto = "Yakult 40", ValorProduto=Produtos.VLR_YAK40.ToString("N2"),LocalImagemProduto="yakult40.jpg", QtdeProduto=0},
                new Produtos {NomeProduto = "Yakult 40 Light", ValorProduto=Produtos.VLR_YAKLGHT.ToString("N2"),LocalImagemProduto="yakult40light.jpg",QtdeProduto=0},
                new Produtos {NomeProduto = "Taffman-E", ValorProduto=Produtos.VLR_TAFFMAN.ToString("N2"),LocalImagemProduto="taffman.jpg" ,QtdeProduto=0 }
            };*/

            this.BindingContext = this;
            //tblSecaoCliente.Title = cliente.NomeCliente + " seu saldo atual é de R$ " + saldo_atual;
        }

        private void DefinirComandos() {

        /*    TirarFotoCommand = new Command(() =>
                {

                    DependencyService.Get<ICamera>().TirarFoto();

                    MessagingCenter.Subscribe<string>(this, "caminhoFoto", (caminho) => {
                        caminhoFoto = caminho;
                    });
                });

            MessagingCenter.Subscribe<byte[]>(this, "FotoTirada", (bytes) => {
                FotoPerfil = ImageSource.FromStream(
                    ()=> new MemoryStream(bytes)
                );
                
                imgPerfil.WidthRequest = 300;
                imgPerfil.HeightRequest = 200;

                var objCliente = new ClienteModel();
                objCliente = _cliente;
                objCliente.Caminho_foto = caminhoFoto;
                MessagingCenter.Send<ClienteModel>(objCliente, "SalvarFoto");
                //this.salvarDados(objCliente);

                //var cliente = new ClienteModel();
                //cliente.Nome = "William";
                //cliente.Logradouro = "Alameda Santos, 771";
                //cliente.Caminho_foto = this.caminhoFoto;
                //this.salvarDados(cliente);


            });*/

            MessagingCenter.Subscribe<ClienteModel>(this, "SalvarFoto", (c) =>
            {

                this.salvarDados(c);

            });


        }

        private void salvarDados(ClienteModel cliente) {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao()) {
                var dao = new ClienteDAO(conexao);
                dao.SalvarCliente(cliente);
            }
        }
	}
}