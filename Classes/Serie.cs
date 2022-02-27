using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    public class Serie : MainEntity
    {
        private Genre Genre { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        public Serie (int ID, Genre Genre, string Title, string Description, int Year)
        {
            this.ID = ID;
            this.Genre = Genre;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
