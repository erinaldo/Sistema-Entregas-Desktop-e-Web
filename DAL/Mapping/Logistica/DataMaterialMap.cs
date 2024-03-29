﻿using DAL.Entities;
using DAL.Entities.Logistica;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping.Logistica
{
  public  class DataMaterialMap : ClassMap<DataMaterial>
    {     
        public DataMaterialMap()
        {
            Id(p => p.DataId).GeneratedBy.Sequence("datamaterial_seq");
            Map(p => p.DataEntrada);
            Map(p => p.Entrada);
            Map(p => p.Fabrica);
            Map(p => p.Obra);
            Map(p => p.MaterialId);
            Table("datamaterial");
        }
      
    }
}
