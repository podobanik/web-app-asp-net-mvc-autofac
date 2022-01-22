using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Common.Entity;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class AvailableDocument : EntityBase, IDataContext
    {
        

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string Name { get; set; }


        /// <summary>
        /// Список клиентов
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Client> Clients { get; set; }
    }
}