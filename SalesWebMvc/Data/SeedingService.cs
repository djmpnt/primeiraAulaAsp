﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;



        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() || 
                _context.SalesRecords.Any())
            {
                return; //o Banco de Dados já foi populado!
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");
           

            Seller s1 = new Seller(1, "Bob Marley", "bob@gmail.com", new DateTime(1998, 04, 21), 1000.00, d4);
            Seller s2 = new Seller(2, "Camila Barbosa", "camilabarb@gmail.com", new DateTime(1991, 03, 21), 5000.00, d3);
            Seller s3 = new Seller(3, "John Doe", "johndoe@gmail.com", new DateTime(1989, 02, 02), 4000.00, d1);
            Seller s4 = new Seller(4, "Petter Kim", "petterkim@gmail.com", new DateTime(1985, 08, 15), 17000.00, d2);

            SalesRecords r1 = new SalesRecords(1, new DateTime(2018, 09, 25), 5000.0, Models.Enums.SaleStatus.Billed, s1);
            SalesRecords r2 = new SalesRecords(2, new DateTime(2018, 01, 15), 12000.0, Models.Enums.SaleStatus.Billed, s2);
            SalesRecords r3 = new SalesRecords(3, new DateTime(2018, 05, 05), 30000.0, Models.Enums.SaleStatus.Billed, s3);
            SalesRecords r4 = new SalesRecords(4, new DateTime(2018, 02, 10), 1000.0, Models.Enums.SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecords.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();


        }

    }

}
