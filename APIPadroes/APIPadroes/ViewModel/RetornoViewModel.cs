namespace APIPadroes.ViewModel
{
    public class RetornoViewModel<T>
    {
        public T Data { get; private set; }

        public List<string> Erros { get; private set; } = new(); //Novidade, nao precisa fazer isso no construtor, e o comondo new ja consegue inferir o tipo

        public RetornoViewModel(T data, List<string> erros)
        {
            Data = data;
            Erros = erros;
        }

        public RetornoViewModel(T data)
        {
            Data = data;
        }

        public RetornoViewModel(List<string> erros)
        {
             Erros = erros;
        }

        public RetornoViewModel(string erro)
        {
            Erros.Add(erro);
        }

    }
}
