﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PracticaAPI.Domain.Entities
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        public string Estado { get; set; }
        public string Titulo { get; set; } 
        public string Descripcion { get; set; } 
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}