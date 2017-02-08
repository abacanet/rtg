﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace ReverseWebQuest.Common
{
    public class NamespaceHttpControllerSelector : IHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;

        public NamespaceHttpControllerSelector(HttpConfiguration config)
        {
            _configuration = config;
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var controllerName = GetControllerName(routeData);
            if (controllerName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var namespaceName = GetVersion(routeData);
            if (namespaceName == null)
            {
                var path = request.RequestUri.LocalPath.Split('/');
                if (path.Count() >= 3)
                {
                    namespaceName = path[2];
                }
                else throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var controllerKey = $"{namespaceName}.{controllerName}";

            HttpControllerDescriptor controllerDescriptor;
            if (_controllers.Value.TryGetValue(controllerKey, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }

        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);

            var assembliesResolver = _configuration.Services.GetAssembliesResolver();
            var controllerResolver = _configuration.Services.GetHttpControllerTypeResolver();

            var controllerTypes = controllerResolver.GetControllerTypes(assembliesResolver);

            foreach (var controllerType in controllerTypes)
            {
                if (controllerType.Namespace == null) continue;
                var segments = controllerType.Namespace.Split(Type.Delimiter);
                var controllerName =
                    controllerType.Name.Remove(controllerType.Name.Length -
                                               DefaultHttpControllerSelector.ControllerSuffix.Length);
                var controllerKey = $"{segments[segments.Length - 1]}.{controllerName}";

                if (!dictionary.Keys.Contains(controllerKey))
                {
                    dictionary[controllerKey] = new HttpControllerDescriptor(_configuration, controllerType.Name, controllerType);
                }
            }

            return dictionary;
        }

        private T GetRoubeVariable<T>(IHttpRouteData routeData, string name)
        {
            object result;

            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
        }

        private string GetControllerName(IHttpRouteData routeData)
        {
            var subroute = routeData.GetSubRoutes().FirstOrDefault();

            var dataTokenValue = subroute?.Route.DataTokens.First().Value;

            var controllerName =
                ((HttpActionDescriptor[])dataTokenValue)?.First().ControllerDescriptor.ControllerName.Replace("Controller", string.Empty);
            return controllerName;
        }

        private string GetVersion(IHttpRouteData routeData)
        {
            var subRouteDate = routeData.GetSubRoutes().FirstOrDefault();
            if (subRouteDate == null) return null;
            return GetRoubeVariable<string>(subRouteDate, "apiVersion");
        }
    }
}
