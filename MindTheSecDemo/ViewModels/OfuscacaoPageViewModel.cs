using System.Windows.Input;
using MindTheSecDemo.Segurança;
using MindTheSecDemo.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MindTheSecDemo.ViewModels
{
    public class OfuscacaoPageViewModel : BindableBase, INavigatingAware
    {
        public readonly INavigationService _navigationService;

        public string Texto { get; set; }

        private string _textoOfuscado;
        public string TextoOfuscado
        {
            set 
            { 
                _textoOfuscado = value; 
                RaisePropertyChanged(nameof(TextoOfuscado)); 
            }

            get { return _textoOfuscado; }
        }

        private string _textoTransformado;
        public string TextoTransformado
        {
            set
            {
                _textoTransformado = value;
                RaisePropertyChanged(nameof(TextoTransformado));
            }

            get { return _textoTransformado; }
        }

        public ICommand OfuscarTextoCommand { get; set; }
        public ICommand ObterTextoCommand { get; set; }
        public ICommand NavegarPokemonsPageCommand { get; set; }

        public OfuscacaoPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OfuscarTextoCommand = new Command(() => TextoOfuscado = TransformStrings.Transform(Texto));

            ObterTextoCommand = new Command(() => TextoTransformado = TransformStrings.Decode(TextoOfuscado));

            NavegarPokemonsPageCommand = new Command(() => _navigationService.NavigateAsync($"{nameof(PokemonsPage)}"));
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}
