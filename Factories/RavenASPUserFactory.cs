﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using SharpRaven;
using SharpRaven.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using SharpRaven.Logging;
using System.Text;
using Auditor.Features;
using SharpRaven.Features;
using Microsoft.AspNet.Hosting;

namespace SharpRaven.Factories
{
    public class RavenASPUserFactory : SentryUserFactory
    {
        protected readonly IServiceProvider Services;
        public RavenASPUserFactory(IServiceProvider serviceProvider)
        {
            Services = serviceProvider;
        }

        protected override SentryUser OnCreate(SentryUser user)
        {
            var requestContext = Services.GetRequiredService<IHttpContextAccessor>();

            if (requestContext.Value == null) return null;
            var context = requestContext.Value;

            user.Username = context.User.Identity.Name;

            return user;
        }
    }
}