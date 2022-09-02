using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AspNetCoreModelBinding.ModelBindings.PersonModelBindings
{
    public class PersonBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(Person))
                return new BinderTypeModelBinder(typeof(PersonModelBinder));

            return null;
        }
    }
}
