﻿using System;
using AgeBaseTemplate.Core.Models.Implementations;
using Umbraco.Core.Models;

namespace AgeBaseTemplate.Core.Services.Implementations
{
    public class MasterPageService : IMasterPageService
    {
        public T CreateModel<T>(IPublishedContent content) where T : class
        {
            var contentType = content.GetType();
            var masterType = typeof(MasterPage<>);

            var modelType = masterType.MakeGenericType(contentType);
            return Activator.CreateInstance(modelType, content) as T;
        }
    }
}