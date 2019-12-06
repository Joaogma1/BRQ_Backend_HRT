using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BRQ.HRTProject.Infra.Core.Validacoes
{
    public class ValidaSenha : ValidationAttribute
    {
        private const string Padrao = @"^.*(?=.{8,})((?=.*[!@#?/$%^&*()\-_=+{};:,<.>]){1})(?=.*\d)((?=.*[a-z]){1})((?=.*[A-Z]){1}).*$";
        public override bool IsValid(object value) => new Regex(Padrao).Match(value.ToString()).Success;
    }
}
