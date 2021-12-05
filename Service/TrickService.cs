using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Service
{
    public class TrickService
    {
        const string cachekey_List = "List";

        IMemoryCache _cache;
        //Test Data
        List<TicketModel> DemoTicket = new List<TicketModel>()
        {
            new TicketModel
            {
                Summary = "bug1",
                Description = "bug1_Descripton"
            },
            new TicketModel
            {
                Summary = "bug2",
                Description = "bug2_Descripton"
            }
        };

        public void Reset(IMemoryCache cache)
        {
            _cache = cache;

            //init
            var list = new List<TicketModel>();
            if (_cache.TryGetValue(cachekey_List, out list) == false)
            {
                SetList(DemoTicket);
            }
        }

        public List<TicketModel> TrickList
        {
            get => GetList();
        }

        public bool SaveChange(List<TicketModel> data)
        {
            SetList(data);
            return true;
        }

        #region Cache
        List<TicketModel> SetList(List<TicketModel> data)
        {
            _cache.Set(cachekey_List, data);
            return data;
        }

        List<TicketModel> GetList()
        {
            var obj = _cache.Get(cachekey_List);
            if (obj != null)
                return obj as List<TicketModel>;

            return new List<TicketModel>();
        }
        #endregion
    }
}
