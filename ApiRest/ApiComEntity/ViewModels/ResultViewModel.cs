namespace ApiComEntity.ViewModels
{
    public class ResultViewModel<T>
    {
        public T Data { get; private set; } 

        public List<string> Erros { get; private set; } = new(); //Novidade, nao precisa fazer isso no construtor, e o comondo new ja consegue inferir o tipo


        public ResultViewModel(T data, List<string> erros)
        {
            Data = data;
            Erros = erros;  
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(List<string> erros)
        {            
            Erros = erros;
        }

        public ResultViewModel(string erro)
        {
            Erros.Add(erro);
        }

        public ResultViewModel()
        {

        }

    }
}
