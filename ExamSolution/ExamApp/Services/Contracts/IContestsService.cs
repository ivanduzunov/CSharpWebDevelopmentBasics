using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Services.Contracts
{
    using Models.Contest;

    public interface IContestsService
    {
        IEnumerable<ContestListingModel> All(int id);

        bool Create(string name, int userId);
    }
}
