using System.Collections.Generic;
using System.Threading.Tasks;
using BlogLab.Model.Blog;

namespace BlogLab.Repository
{
  public interface IBlogRepository
  {
    public Task<Blog> UpsertAsync(BlogCreate blogcreate, int applicationUserId);

    public Task<PagedResults<Blog>> GetAllAsync(BlogPaging blogPaging);

    public Task<Blog> GetAsync(int blogId);

    public Task<List<Blog>> GetAllByUserIdAsync(int applicationUserId);

    public Task<List<Blog>> GetAllFamousAsync();

    public Task<int> DeleteAsync(int blogId);

  }
}
