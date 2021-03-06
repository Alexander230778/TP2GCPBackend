﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BEGR_Requerimiento
    {
        public BEGR_Requerimiento()
        {
            LST_RECU = new List<BEGCP9_Recurso>();
            RequerimientoRecurso = new List<GCP_RequerimientoRecurso>();
        }
        public int key { get; set; }
        public int lir_Codigo { get; set; }
        public int rfc_Codigo { get; set; }
        public string lir_Nombre { get; set; }
        public string lir_Resumen { get; set; }
        public DateTime lir_FechaCreacion { get; set; }
        public string lir_FechaEntrega { get; set; }
        public bool lir_EsFuncional { get; set; }
        public bool lir_RequiereDocumentar { get; set; }
        public int GPP_Proyecto_pro_Codigo { get; set; }
        public string est_Estado { get; set; }
        public int lir_Prioridad { get; set; }
        public List<BEGCP9_Recurso> LST_RECU { get; set; }
        public int est_Codigo { get; set; }
        public int lir_Dias { get; set; }
        public string pri_Prioridad { get; set; }
        public decimal lir_CostoInicial { get; set; }
        public decimal lir_CostoAsignado { get; set; }
        public bool lir_Aprobado { get; set; }
        public int lir_Esfuerzo { get; set; }
        public string lir_Desde { get; set; }
        public string lir_Hasta { get; set; }
        public decimal lir_CostoFinal { get; set; }
        public string lir_ImpactoRiesgo { get; set; }
        public int acci { get; set; }

        //Datos para la bandeja de técnicos
        public int lit_Codigo { get; set; }
        public string pro_Nombre { get; set; }
        public string rfc_Asunto { get; set; }
        public int lir_TiempoDesarrollo { get; set; }
        public List<GCP_RequerimientoRecurso> RequerimientoRecurso { get; set; }
    }
    public class requerimentRequest
    {
        public requerimentRequest()
        {
            RequerimientoRecurso = new List<GCP_RequerimientoRecurso>();
        }
        public int lir_Codigo { get; set; }
        public string title { get; set; }
        public string delivery { get; set; }
        public string description { get; set; }
        public int prioridad { get; set; }
        public bool isFunctional { get; set; }
        public bool requireDocumentation { get; set; }
        public int rfc_Codigo { get; set; }
        public int lit_Codigo { get; set; }
        public int est_Codigo { get; set; }
        public int lir_TiempoDesarrollo { get; set; }
        public List<GCP_RequerimientoRecurso> RequerimientoRecurso { get; set; }
    }
    public class requirementResponse
    {
        public bool success { get; set; }
        public BEGR_Requerimiento data { get; set; }
        public string message { get; set; }
    }
    public class GCP_RequerimientoRecurso
    {
        public int lir_Codigo { get; set; }
        public int key { get; set; }
        public int ltr_tipo { get; set; }
        public int lrr_Cantidad { get; set; }
        public int acci { get; set; }
    }

}
