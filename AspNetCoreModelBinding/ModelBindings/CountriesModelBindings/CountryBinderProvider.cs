using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AspNetCoreModelBinding.ModelBindings.CountriesModelBindings
{
    public class CountryBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(Country))
                return new BinderTypeModelBinder(typeof(CountryModelBinding));

            return null;
        }
    }
}
