using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series.Interfaces;

namespace Series
{
    public class SerieRepository : IRepository<Series>
    {
        private List<Series> SerieList = new List<Series>();
       
        public void Insert(Series entity)
        {
            SerieList.Add(entity);
        }

        public List<Series> List()
        {
            return SerieList;
        }

        public int NextID()
        {
            return SerieList.Count;
        }

        public void Remove(int ID)
        {
            SerieList[ID].Delete();
        }

        public Series ReturnByID(int ID)
        {
            return SerieList[ID];
        }

        public void Update(int ID, Series entity)
        {
            SerieList[ID] = entity;
        }
    }
}
