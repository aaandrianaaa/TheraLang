﻿using MvcWeb.TheraLang.Entities;
using MvcWeb.TheraLang.Models;
using System.Threading.Tasks;

namespace MvcWeb.TheraLang.Services
{
    public interface IDonationService
    {
        LiqPayCheckoutModel GetLiqPayCheckoutModel(string donationAmount, int projectId);
        Donation GetDonation(string donationId);
        Task AddDonation(int projectId, string donationId, string data, string signature);
    }
}
