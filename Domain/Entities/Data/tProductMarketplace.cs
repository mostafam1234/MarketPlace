using CoreSystem.DAL.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Data
{
    public class tProductMarketplace
    {
        public int ProductId { get; private set; }
        public int MarketplaceTypeId { get; private set; }
        public string MarketPlaceNumber { get; set; }
        public virtual tProduct Product { get; private set; }
        public virtual tMarketplaceType MarketplaceType { get; private set; }
    }
}
