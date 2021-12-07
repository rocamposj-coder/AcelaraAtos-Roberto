using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiComEntity.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> RecuperarErros(this ModelStateDictionary modelState)
        {
            var listaErros = new List<string>();

            foreach (var item in modelState.Values)
            {
                foreach(var erro in item.Errors)
                {
                    listaErros.Add(erro.ErrorMessage);
                }
            }

            return listaErros;
        }
    }
}
