namespace Rolê_Top.ViewModel
{
    public class RespostaViewModel : BaseViewModel
    {
        public string Mensagem{get;set;}

        public RespostaViewModel()
        {}

        public RespostaViewModel(string mensagem)
        {
            this.Mensagem = mensagem;
        }
        
    }
}