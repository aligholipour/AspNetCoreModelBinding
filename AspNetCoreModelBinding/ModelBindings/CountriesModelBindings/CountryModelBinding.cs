using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreModelBinding.ModelBindings.CountriesModelBindings
{
    public class CountryModelBinding : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null)
                throw new ArgumentNullException(nameof(bindingContext));

            var data = bindingContext.HttpContext.Request.RouteValues;

            var result = data.TryGetValue("countries", out var country);
            if (result)
            {
                var countryArray = country.ToString().Split(",");
                bindingContext.Result = ModelBindingResult.Success(countryArray);
            }

            return Task.CompletedTask;
        }
    }
}
