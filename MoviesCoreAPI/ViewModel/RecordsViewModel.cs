using MoviesCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCoreAPI.ViewModel
{
    public class RecordsViewModel
    {
        public int RecordID { get; set; }
        public int Rate { get; set; }
        public MoviesViewModel Movie { get; set; }
        public UsersViewModel User { get; set; }

        public static implicit operator RecordsViewModel(Records record)
        {
            return new RecordsViewModel
            {
                RecordID = record.RecordID,
                Rate = record.Rate,
                Movie = record.Movie,
                User = record.User
            };
        }

        public static implicit operator Records(RecordsViewModel recordViewModel)
        {
            return new Records
            {
                RecordID = recordViewModel.RecordID,
                Rate = recordViewModel.Rate,
                Movie = recordViewModel.Movie,
                User = recordViewModel.User
            };
        }
    }
}
