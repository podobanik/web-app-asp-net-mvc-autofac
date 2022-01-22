using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Common.Entity;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class Document : EntityBase, IDataContext
    {

  
        
        public Guid Guid { get; set; }
        [Required]
        public byte[] Data { get; set; }

        /// <summary>
        /// Тип файла
        /// </summary>
        [StringLength(100)]
        public string ContentType { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        [Required]
        public DateTime? DateChanged { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        [Required]
        
        public string FileName { get; set; }

       
        
    }
}