﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithCategory()
        {
            using (var context = new Context())
            {
                return context.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
