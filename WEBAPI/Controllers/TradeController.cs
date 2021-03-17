using BANCOMVC.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BANCOMVC.EnumConst;

namespace WEBAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        [HttpPost]
        [Route("GetTradeCategories")]
        public List<string> GetTradeCategories(List<Trade> portfolio)
        {
            // valida se existem registros
            if (portfolio.Count < 0) { throw new Exception("Não existem registros"); }

            //processa o retorno
            List<string> tradeCategories = new List<string>();

            foreach (var item in portfolio)
            {
                if (item.Value < 1000000 && item.ClientSector == TradeCategories.ClientSectorPublic)
                {
                    tradeCategories.Add(TradeCategories.categoriesLOWRISK);
                }
                else if (item.Value > 1000000 && item.ClientSector == TradeCategories.ClientSectorPublic)
                {
                    tradeCategories.Add(TradeCategories.categoriesMEDIUMRISK);
                }
                else if (item.Value > 1000000 && item.ClientSector == TradeCategories.ClientSectorPrivate)
                {
                    tradeCategories.Add(TradeCategories.categoriesHIGHRISK);
                }
                else
                    //Criado o retorno vazio, pois não esta especificado a regra para quando o retorno for Private menor que 1000000.
                    tradeCategories.Add("");
            }

            return tradeCategories;
        }

    }
}
