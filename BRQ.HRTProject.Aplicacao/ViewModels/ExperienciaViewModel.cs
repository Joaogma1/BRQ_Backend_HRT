﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class ExperienciaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Instituicao { get; set; }
        public string Descricao { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime? DtInicio { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime? DtFim { get; set; }

        [JsonProperty(PropertyName = "idTipoExperiencia")]
        public int FkTipoExperiencia { get; set; }

        [JsonProperty(PropertyName = "idPessoa")]
        public int FkPessoa { get; set; }

        public TipoExperienciaViewModel FkTipoExperienciaNavigation { get; set; }
    }
}
