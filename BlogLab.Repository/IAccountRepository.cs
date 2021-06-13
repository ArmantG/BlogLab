using System;
using System.Threading;
using System.Threading.Tasks;
using BlogLab.Model.Account;
using Microsoft.AspNetCore.Identity;

namespace BlogLab.Repository
{
  public interface IAccountRepository
  {
    public Task<IdentityResult> CreateAsync(ApplicationUserIdentity user,
                                            CancellationToken cancellationToken);

    public Task<ApplicationUserIdentity> GetByUsernameAsync(string NormalizedUsername,
                                                            CancellationToken cancellationToken);

  }
}
