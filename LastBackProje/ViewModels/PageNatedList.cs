using LastBackProje.Models;

namespace LastBackProje.ViewModels
{
    public class PageNatedList<T>:List<T>
    {
        public PageNatedList(IQueryable<T> query,int currentPAge,int totalPage,int pageItemCount)
        {
            CurrentPAge = currentPAge;
            TotalPAge = totalPage;
            HasPrev = CurrentPAge > 1;
            HasNext=CurrentPAge < TotalPAge;
            Start = CurrentPAge - (int)Math.Ceiling((decimal)(pageItemCount - currentPAge) / 2);
            End = CurrentPAge + (int)Math.Floor((decimal)(pageItemCount-currentPAge)/ 2);

            if (Start <= 0)
            {
                End = End - (Start - 1);
                Start = 1;
            }

            if (End > totalPage)
            {
               if(TotalPAge>pageItemCount)
                {
                    Start = TotalPAge - (pageItemCount - 1);
                }
                else
                {
                    Start = 1;
                }
                End = TotalPAge;
            }


            //if (TotalPAge > pageItemCount)
            //{
            //    if (Start <= 0)
            //    {
            //        End = End - (Start - 1);
            //        Start = 1;
            //    }

            //    if (End > totalPage)
            //    {
            //        Start = TotalPAge - (pageItemCount-1);
            //        End = TotalPAge;
            //    }
            //}

            this.AddRange(query);
        }

        public int Start { get; }

        public int End { get;  }

        public int CurrentPAge { get;  }

        public int TotalPAge { get;  }

        public bool HasPrev { get; }

        public bool HasNext { get; }

        public static PageNatedList<T> Create(IQueryable<T> query, int currentPAge,int elementCount,int pageItemCount)
        {
            int totalPage= (int)Math.Ceiling((decimal)query.Count() / elementCount);
            query = query.Skip((currentPAge - 1) * elementCount).Take(elementCount);

            return new PageNatedList<T>(query,currentPAge,totalPage,pageItemCount);
        }
    }
}
