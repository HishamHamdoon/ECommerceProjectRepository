﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Utitlity
{
    public class SD
    {
        public const string Role_User_Customer = "Customer";
        public const string Role_User_Company = "Company";
        public const string Role_User_Admin = "Admin";
        public const string Role_User_Employee = "Employee";


        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";

        public const string StatusShipped= "Shipped";
        public const string StatusCanceled = "Canceled";
        public const string StatusRefund = "Refunded";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved ";
        public const string PaymentStatusDelayedPayment= "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected= "Rejected";
    }
}