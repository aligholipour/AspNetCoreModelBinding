using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace AspNetCoreModelBinding.ModelBindings.PersonModelBindings
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null)
                throw new ArgumentNullException(nameof(bindingContext));

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
                return Task.CompletedTask;

            if (!int.TryParse(value, out var id))
            {
                bindingContext.ModelState.AddModelError(modelName, "Person Id must be an integer.");
                return Task.CompletedTask;
            }

            var persons = ReadFromJsonFile();

            var model = persons.Where(x => x.Id == id).SingleOrDefault();

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }

        private List<Person> ReadFromJsonFile()
        {
            FileStream fileStream = new FileStream("PersonResource/persons.json", FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            string result = reader.ReadToEnd();

            var mdoel = JsonSerializer.Deserialize<List<Person>>(result);
            return mdoel;
        }
    }
}
