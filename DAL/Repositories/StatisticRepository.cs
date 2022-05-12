using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        public void Create(UserStatistics entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserStatistics Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserStatistics> GetAll()
        {
            throw new NotImplementedException();
        }

        public float GetTasksFinishedRateForTheme(int id)
        {
            throw new NotImplementedException();
        }

        public float GetThemesFinishedRateForCourse(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserStatistics entity)
        {
            throw new NotImplementedException();
        }
    }
}
