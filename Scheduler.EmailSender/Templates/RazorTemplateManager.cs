using RazorEngine;
using RazorEngine.Templating;
using Scheduler.Common.Enums;
using Scheduler.EmailSender.Templates.ViewModels;
using System;
using System.IO;

namespace Scheduler.EmailSender.Templates
{
    class RazorTemplateManager : ITemplateManager
    {
        /// <summary>
        /// The base template path
        /// </summary>
        private readonly string baseTemplatePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="RazorTemplateManager"/> class.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public RazorTemplateManager(string basePath)
        {
            baseTemplatePath = basePath;
        }

        /// <summary>
        /// Resolves the template with the specified key.
        /// </summary>
        /// <param name="key">The key which should be resolved to a template source.</param>
        /// <returns>
        /// The template content.
        /// </returns>
        public ITemplateSource Resolve(ITemplateKey key)
        {
            var template = key.Name;
            var templatePath = $"{AppDomain.CurrentDomain.BaseDirectory}{baseTemplatePath}\\{template}.cshtml";
            var content = File.ReadAllText(templatePath);
            return new LoadedTemplateSource(content, templatePath);
        }

        /// <summary>
        /// Get the key of a template.
        /// This method has to be implemented so that the manager can control the <see cref="T:RazorEngine.Templating.ITemplateKey" /> implementation.
        /// This way the cache api can rely on the unique string given by <see cref="M:RazorEngine.Templating.ITemplateKey.GetUniqueKeyString" />.
        /// </summary>
        /// <param name="name">The name of the tempalte</param>
        /// <param name="resolveType">how the template is resolved</param>
        /// <param name="context">gets the context for the current resolve operation.
        /// Which template is resolving another template? (null = we search a global template)</param>
        /// <returns>
        /// the key for the template
        /// </returns>
        /// <remarks>
        /// For example one template manager reads all template from a single folder, then the <see cref="M:RazorEngine.Templating.ITemplateKey.GetUniqueKeyString" /> can simply return the template name.
        /// Another template manager can read from different folders depending whether we include a layout or including a template.
        /// In that situation the <see cref="M:RazorEngine.Templating.ITemplateKey.GetUniqueKeyString" /> has to take that into account so that templates with the same name can not be confused.
        /// </remarks>
        public ITemplateKey GetKey(string name, ResolveType resolveType, ITemplateKey context)
        {
            return new NameOnlyTemplateKey(name, resolveType, context);
        }

        /// <summary>
        /// Adds a template dynamically to the current manager.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="source"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddDynamic(ITemplateKey key, ITemplateSource source)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generate email body from model.
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="type">Type of email</param>
        /// <returns>Generated body</returns>
        public static string GenerateEmailBody(EmailViewModel model, EmailTypes type)
        {
            try
            {
                string body = Engine.Razor.RunCompile($"_{type}EmailTemplate", null, model);
                string footer = Engine.Razor.RunCompile("_Footer");
                return body + footer;
            }
            catch (Exception ex)
            {
                //TODO Add exception handling.
                throw new NotSupportedException();
            }
        }
    }
}
