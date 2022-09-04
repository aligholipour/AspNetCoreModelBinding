using AspNetCoreModelBinding.Models.ExchangeCurrency;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreModelBinding.ModelBindings.ExchangeCurrency
{
    public class ExchangeCurrency : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null)
                throw new ArgumentNullException(nameof(bindingContext));

            var data = bindingContext.HttpContext.Request.RouteValues;
            var currency = data.TryGetValue("currency", out var currencyResult);
            if (currency)
            {
                var currencySeperate = currencyResult.ToString().Split("-");
                var currencyMdoel = new CurrencyModel
                {
                    Amount = Convert.ToDecimal(currencySeperate[0]),
                    From = currencySeperate[1],
                    To = currencySeperate[2],
                };

                bindingContext.Result = ModelBindingResult.Success(currencyMdoel);
            }
            return Task.CompletedTask;
        }
    }
}
