using System;
using System.Collections.Generic;
using System.Linq;
using TicketSystem.Models;

namespace TicketSystem.Service
{
    public class RoleService
    {
        //Test Data
        List<RoleModel> Roles = new List<RoleModel>()
        {
                new RoleModel()
                {
                    Name="QA",
                    Delete=true,
                    Create=true,
                    Update=true,
                },

                new RoleModel()
                {
                    Name="RD",
                    Resolve=true
                },
        };

        public RoleModel GetRole(string Name) => Roles.Where(x => x.Name.Equals(Name)).FirstOrDefault();
    }

}
