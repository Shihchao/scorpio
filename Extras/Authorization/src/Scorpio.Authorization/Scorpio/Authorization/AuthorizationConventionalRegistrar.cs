﻿using Microsoft.Extensions.DependencyInjection;
using Scorpio.Conventional;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Scorpio.Authorization.Permissions;
using Scorpio.DependencyInjection;
using Scorpio.DependencyInjection.Conventional;

namespace Scorpio.Authorization
{
    internal class AuthorizationConventionalRegistrar : IConventionalRegistrar
    {
        public void Register(IConventionalRegistrationContext context)
        {
            context.Services.RegisterConventionalDependencyInject(context.Types, config =>
            {
                config.Where(t =>t.IsStandardType() && t.IsAssignableTo<IPermissionDefinitionProvider>()).AsSelf().Lifetime(ServiceLifetime.Singleton);
                config.Where(t => t.IsStandardType() && t.IsAssignableTo<IPermissionGrantingProvider>()).AsSelf().Lifetime(ServiceLifetime.Singleton);
            });
        }
    }
}
