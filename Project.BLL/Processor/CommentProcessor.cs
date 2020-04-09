using AutoMapper;
using Project.BLL.UserModel;
using Project.DAL;
using Project.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Processor
{
    public class CommentProcessor
    {
        readonly RecordContext _context = new RecordContext();

        public CommentEntity CommentToCommentEntity(Comment source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentEntity>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Comment, CommentEntity>(source);
        }

        public Comment CommentEntityToComment(CommentEntity source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentEntity, Comment>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<CommentEntity, Comment>(source);
        }

        public List<CommentEntity> GetAllComment(int eventId)
        {
            List<CommentEntity> final = new List<CommentEntity>();
            var temp = _context.Comments.Where(e => e.EventId == eventId).ToList();
            foreach (var item in temp)
            {
                final.Add(CommentToCommentEntity(item));
            }
            return final.OrderBy(c => c.CommentDate).ToList();
        }

        public void CreateComment(CommentEntity comment)
        {
            _context.Comments.Add(CommentEntityToComment(comment));
            _context.SaveChanges();
        }
    }
}
