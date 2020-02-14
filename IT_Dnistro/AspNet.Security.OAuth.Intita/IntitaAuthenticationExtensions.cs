using System;
using AspNet.Security.OAuth.Intita;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet.Security.OAuth.Intita
{
    public static class IntitaAuthenticationExtensions
    {
        /// <summary>
        /// Adds <see cref="IntitaAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Intita authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddIntita([NotNull] this AuthenticationBuilder builder)
        {
            return builder.AddIntita(IntitaAuthenticationDefaults.AuthenticationScheme, options => { });
        }

        /// <summary>
        /// Adds <see cref="IntitaAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Intita authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="configuration">The delegate used to configure the OpenID 2.0 options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddIntita(
            [NotNull] this AuthenticationBuilder builder,
            [NotNull] Action<IntitaAuthenticationOptions> configuration)
        {
            return builder.AddIntita(IntitaAuthenticationDefaults.AuthenticationScheme, configuration);
        }

        /// <summary>
        /// Adds <see cref="IntitaAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Intita authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Intita options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddIntita(
            [NotNull] this AuthenticationBuilder builder, [NotNull] string scheme,
            [NotNull] Action<IntitaAuthenticationOptions> configuration)
        {
            return builder.AddIntita(scheme, IntitaAuthenticationDefaults.DisplayName, configuration);
        }

        /// <summary>
        /// Adds <see cref="IntitaAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Intita authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="caption">The optional display name associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Intita options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddIntita(
            [NotNull] this AuthenticationBuilder builder,
            [NotNull] string scheme, [CanBeNull] string caption,
            [NotNull] Action<IntitaAuthenticationOptions> configuration)
        {
            return builder.AddOAuth<IntitaAuthenticationOptions, IntitaAuthenticationHandler>(scheme, caption, configuration);
        }
    }
}
