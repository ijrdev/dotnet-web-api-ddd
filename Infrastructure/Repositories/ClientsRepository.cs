﻿using Interfaces.Repositories;
using System;

namespace Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        public void AddClient()
        {
            Console.WriteLine("REPOSITORY");

            //throw new System.NotImplementedException();
        }

        public void UpdateClient()
        {
            throw new System.NotImplementedException();
        }
    }
}
