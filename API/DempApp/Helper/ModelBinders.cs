﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DempApp.Helper
{
    public class DataDescriptorModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            if (!bindingContext.HttpContext.Request.Headers.TryGetValue("x-descriptor", out var header))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
            //bindingContext.Result = ModelBindingResult.Success(JsonConvert.DeserializeObject<DataDescriptor>(header.ToString()));
            return Task.CompletedTask;
        }
    }
    public class ModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //if (context.Metadata.ModelType == typeof(DataDescriptor))
            //    return new DataDescriptorModelBinder();

            return null;
        }
    }
}
