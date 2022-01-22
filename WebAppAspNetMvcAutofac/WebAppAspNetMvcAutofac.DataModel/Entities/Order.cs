using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Common.Entity;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class Order : EntityBase, IDataContext
    {
        

        /// <summary>
        /// Услуга
        /// </summary>
        [Required]
        [Display(Name = "Услуга", Order = 5)]
        public string Procedure { get; set; }

        /// <summary>
        /// Описание услуги
        /// </summary>
        
        [Display(Name = "Описание услуги", Order = 20)]
        public string Description { get; set; }
        /// <summary>
        /// Связь с таблицей Client
        /// </summary>
        [ScaffoldColumn(false)]
        public virtual ICollection<Client> Clients { get; set; }


    }
}