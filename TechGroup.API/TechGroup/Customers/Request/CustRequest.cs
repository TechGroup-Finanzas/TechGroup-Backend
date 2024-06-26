﻿namespace TechGroup.API.TechGroup.Customers.Request
{
    public class CustRequest
    {
        public int id_user {get;set;}
        public string name { get; set; }
        public string lastname { get; set; }
        public string Dni { get; set; }
        public DateOnly birthdate{get;set;}
        public string phone{get;set;}
        public string email { get; set; }
        public string rate_type{get;set;}
        public string capitalization {get;set;}
        public double rate{get;set;}
        public string period{get;set;}
        public double limit{get;set;}
        public string status{get;set;}
        public DateOnly payment_date { get; set; }
    }
}
