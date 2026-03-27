using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace EstudiantesApi.Utilidades
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombrepropiedad = bindingContext.ModelName;
            var valor = bindingContext.ValueProvider.GetValue(nombrepropiedad);

            if (valor == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            try
            {
                var tipodestino = bindingContext.ModelMetadata.ModelType;
                var valordeserializado = JsonSerializer.Deserialize(valor.FirstValue!,tipodestino,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                bindingContext.Result = ModelBindingResult.Success(valordeserializado);


            }
            catch
            {
                bindingContext.ModelState.TryAddModelError(nombrepropiedad, "El valor proporcionado no es válido");
            }
            return Task.CompletedTask;
        }

    }
}
